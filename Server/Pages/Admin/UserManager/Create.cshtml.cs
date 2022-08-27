using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.UserManager
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Infrastructure.Constants.Role.Admin)]
	public class CreateModel : Infrastructure.BasePageModelWithDatabaseContext
	{
		#region Constructor(s)
		public CreateModel
			(Data.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<CreateModel> logger) : base(databaseContext: databaseContext)
		{
			Logger = logger;

			ViewModel = new();

			RolesViewModel = new System.Collections.Generic.List
				<ViewModels.Pages.Admin.RoleManager.Base.RoleBaseViewModel>();
		}
		#endregion /Constructor(s)

		#region Property(ies)
		// **********
		private Microsoft.Extensions.Logging.ILogger<CreateModel> Logger { get; }
		// **********

		// **********
		public System.Collections.Generic.IList
			<ViewModels.Pages.Admin.RoleManager.Base.RoleBaseViewModel> RolesViewModel
		{ get; private set; }
		// **********
		#endregion /Property(ies)

		#region BindProperty(ies)
		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public string? ReturnUrl { get; set; }
		// **********

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Pages.Admin.UserManager.CreateUserViewModel ViewModel { get; set; }
		// **********
		#endregion /BindProperty(ies)

		#region OnGet
		public async System.Threading.Tasks.Task OnGetAsync(string? returnUrl)
		{
			ReturnUrl = SetReturnUrl(returnUrl: returnUrl);

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
		#endregion /OnGet

		#region OnPost
		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync()
		{
			if (ModelState.IsValid == false)
			{
				return Page();
			}

			try
			{
				bool isEmailAddressFound = false;

				if (string.IsNullOrWhiteSpace(value: ViewModel.EmailAddress) == false)
				{
					isEmailAddressFound =
						await DatabaseContext.Users
						.Where(current => current.EmailAddress != null)
						.Where(current => current.EmailAddress.ToLower() == ViewModel.EmailAddress.Trim().ToLower())
						.Where(current => current.IsEmailAddressVerified)
						.AnyAsync();
				}

				// **************************************************
				if (isEmailAddressFound)
				{
					string errorMessage = string.Format
						(Resources.Messages.Errors.AlreadyExists, Resources.DataDictionary.EmailAddress);

					AddPageError(message: errorMessage);

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
				Domain.User user =
					new(emailAddress: ViewModel.EmailAddress)
					{
						Ordering = ViewModel.Ordering,

						IsActive = ViewModel.IsActive,
 						IsProgrammer = ViewModel.IsProgrammer,
						IsUndeletable = ViewModel.IsUndeletable,
						IsEmailAddressVerified = ViewModel.IsEmailAddressVerified,
						IsCellPhoneNumberVerified = ViewModel.IsCellPhoneNumberVerified,

						CellPhoneNumber = ViewModel.CellPhoneNumber,
						Password = Dtat.Security.Hashing.GetSha256(text: ViewModel.Password),
					};
				// **************************************************

				var isValid =
						Domain.SeedWork.ValidationHelper.IsValid(entity: user);

				var results =
					Domain.SeedWork.ValidationHelper.GetValidationResults(entity: user);

				// **************************************************
				if (isValid)
				{
					var entityEntry =
						await DatabaseContext.AddAsync(entity: user);

					int affectedRow =
						await DatabaseContext.SaveChangesAsync();

					string successMessage = string.Format
						(Resources.Messages.Successes.Created,
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

			ReturnUrl = SetReturnUrl(returnUrl: ReturnUrl);

			return Redirect(url: ReturnUrl);
		}
		#endregion OnPost

		#region SetAccessibleRole
		private async System.Threading.Tasks.Task SetAccessibleRole()
		{
			RolesViewModel =
				await DatabaseContext.Roles
				//.Where(current => current.IsDeleted == false)
				.OrderBy(current => current.Ordering)
				.Select(current => new ViewModels.Pages.Admin.RoleManager.Base.RoleBaseViewModel
				{
					Id = current.Id,
					Name = current.Name,
				})
				.ToListAsync()
				;
		}
		#endregion /SetAccessibleRole
	}
}
