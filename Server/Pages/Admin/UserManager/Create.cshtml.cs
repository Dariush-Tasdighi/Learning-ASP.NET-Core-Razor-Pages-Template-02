using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.UserManager
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Domain.SeedWork.Constant.SystemicRole.Admin)]
	public class CreateModel : Infrastructure.BasePageModelWithDatabase
	{
		public CreateModel
			(Persistence.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<CreateModel> logger) : base(databaseContext: databaseContext)
		{
			Logger = logger;

			ViewModel = new();

			RolesViewModel = new System.Collections.Generic.List
				<ViewModels.Pages.Admin.UserManager.GetAccessibleRolesViewModel>();
		}

		// **********
		private Microsoft.Extensions.Logging.ILogger<CreateModel> Logger { get; }
		// **********

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public string? ReturnUrl { get; set; }
		// **********

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Pages.Admin.UserManager.CreateUserViewModel ViewModel { get; set; }
		// **********

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public System.Collections.Generic.IList
			<ViewModels.Pages.Admin.UserManager.GetAccessibleRolesViewModel> RolesViewModel
		{ get; private set; }
		// **********

		public async System.Threading.Tasks.Task OnGetAsync(string? returnUrl)
		{
			ReturnUrl = returnUrl;

			try
			{
				await SetAccessibleRole();
			}
			catch (System.Exception ex)
			{
				Logger.LogError(message: ex.Message);
			}
			finally
			{
				await DisposeDatabaseContextAsync();
			}
		}

		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync()
		{
			if (ModelState.IsValid == false)
			{
				return Page();
			}

			// **************************************************
			string? fixedUsername = Infrastructure.Utility
				.RemoveSpacesAndMakeTextCaseInsensitive(text: ViewModel.Username);

			string? fixedEmailAddress = Infrastructure.Utility
				.RemoveSpacesAndMakeTextCaseInsensitive(text: ViewModel.EmailAddress);
			// **************************************************

			try
			{
				if (ModelState.IsValid is false)
				{
					return Page();
				}

				bool isUsernameFound =
					await DatabaseContext.Users
					.Where(current => current.Username == fixedUsername)
					.AnyAsync();

				bool isEmailAddressFound =
					await DatabaseContext.Users
					.Where(current => current.EmailAddress == fixedEmailAddress)
					.Where(current => current.IsEmailAddressVerified.HasValue && current.IsEmailAddressVerified.Value)
					.Where(current => current.IsDeleted == false)
					.AnyAsync();

				// **************************************************
				if (isUsernameFound)
				{
					string errorMessage = string.Format
						(Resources.Messages.Errors.AlreadyExists, Resources.DataDictionary.Username);

					AddPageError(message: errorMessage);
				}

				if (isEmailAddressFound)
				{
					string errorMessage = string.Format
						(Resources.Messages.Errors.AlreadyExists, Resources.DataDictionary.EmailAddress);

					AddPageError(message: errorMessage);
				}
				// **************************************************

				if (isUsernameFound || isEmailAddressFound)
				{
					return Page();
				}

				// **************************************************
				if (string.IsNullOrWhiteSpace(value: ViewModel.EmailAddress) == false)
				{
					ViewModel.IsEmailAddressVerified = true;
				}

				if (string.IsNullOrWhiteSpace(value: ViewModel.CellPhoneNumber) == false)
				{
					ViewModel.IsCellPhoneNumberVerified = true;
				}
				// **************************************************

				Domain.Models.Users.User user = new()
				{
					RoleId = ViewModel.RoleId,

					Gender = ViewModel.Gender,
					IsActive = ViewModel.IsActive,

					IsVerified = ViewModel.IsVerified,
					VerifyDateTime = Domain.SeedWork.Utility.Now,
					IsEmailAddressVerified = ViewModel.IsEmailAddressVerified,
					IsCellPhoneNumberVerified = ViewModel.IsCellPhoneNumberVerified,

					Username = fixedUsername,
					EmailAddress = fixedEmailAddress,
					CellPhoneNumber = ViewModel.CellPhoneNumber,
					LastName = Infrastructure.Utility.FixText(text: ViewModel.LastName),
					FirstName = Infrastructure.Utility.FixText(text: ViewModel.FirstName),
					Password = Dtat.Security.Cryptography.GetSha256(text: ViewModel.Password),
				};

				var entityEntry =
					await DatabaseContext.AddAsync(entity: user);

				int affectedRow =
					await DatabaseContext.SaveChangesAsync();

				// **************************************************
				if (affectedRow > 0)
				{
					string successMessage = string.Format
						(Resources.Messages.Successes.SuccessfullyCreated,
						Resources.DataDictionary.User);

					AddToastSuccess(message: successMessage);
				}
				// **************************************************
			}
			catch (System.Exception ex)
			{
				Logger.LogError(message: ex.Message);

				//System.Console.WriteLine(value: ex.Message);

				AddPageError(message: Resources.Messages.Errors.UnexpectedError);
			}
			finally
			{
				await SetAccessibleRole();

				await DisposeDatabaseContextAsync();
			}

			if (string.IsNullOrWhiteSpace(value: ReturnUrl))
			{
				return RedirectToPage(pageName: "./Index");
			}
			else
			{
				return Redirect(url: ReturnUrl);
			}
		}

		private async System.Threading.Tasks.Task SetAccessibleRole()
		{
			RolesViewModel =
				await DatabaseContext.Roles
				.Where(current => current.IsDeleted == false)
				.OrderBy(current => current.Ordering)
				.Select(current => new ViewModels.Pages.Admin.UserManager.GetAccessibleRolesViewModel
				{
					Id = current.Id,
					Name = current.Name,
				})
				.ToListAsync()
				;
		}
	}
}
