using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.Users
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Infrastructure.Constant.Role.Admin)]
	public class CreateModel : Infrastructure.BasePageModelWithDatabase
	{
		#region Constructor(s)
		public CreateModel(Data.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<CreateModel> logger) :
			base(databaseContext: databaseContext)
		{
			Logger = logger;
			ViewModel = new();

			//RolesViewModel = new System.Collections.Generic.List
			//	<ViewModels.Pages.Admin.RoleManager.Base.RoleBaseViewModel>();
		}
		#endregion /Constructor(s)

		// **********
		private Microsoft.Extensions.Logging.ILogger<CreateModel> Logger { get; }
		// **********

		// **********
		public System.Collections.Generic.IList
			<ViewModels.Pages.Admin.Roles.CommonViewModel> RolesViewModel
		{ get; private set; }
		// **********

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Pages.Admin.Users.CreateViewModel ViewModel { get; set; }
		// **********

		#region OnGet
		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync()
		{
			try
			{
				await SetAccessibleRole();
			}
			catch (System.Exception ex)
			{
				Logger.LogError
					(message: ex.Message);

				AddPageError(message:
					Resources.Messages.Errors.UnexpectedError);
			}
			finally
			{
				await DisposeDatabaseContextAsync();
			}

			return Page();
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
				bool foundedAny = false;


				foundedAny =
					await DatabaseContext.Users
					.Where(current => current.EmailAddress.ToLower() == ViewModel.EmailAddress.Trim().ToLower())
					.Where(current => current.IsEmailAddressVerified)
					.AnyAsync();

				if (foundedAny)
				{
					// **************************************************
					string errorMessage = string.Format
						(Resources.Messages.Errors.AlreadyExists,
						Resources.DataDictionary.EmailAddress);

					AddPageError
						(message: errorMessage);

					return Page();
					// **************************************************
				}

				if (string.IsNullOrWhiteSpace(value: ViewModel.EmailAddress) == false)
				{
					ViewModel.IsEmailAddressVerified = true;
				}

				if (string.IsNullOrWhiteSpace(value: ViewModel.CellPhoneNumber) == false)
				{
					ViewModel.IsCellPhoneNumberVerified = true;
				}

				// **************************************************
				string hashedPassword =
					Dtat.Security.Hashing.GetSha256(text: ViewModel.Password);

				Domain.User user =
					new(emailAddress: ViewModel.EmailAddress)
					{
						Password = hashedPassword,
						Ordering = ViewModel.Ordering,
						IsActive = ViewModel.IsActive,
						IsProgrammer = ViewModel.IsProgrammer,
						IsUndeletable = ViewModel.IsUndeletable,
						CellPhoneNumber = ViewModel.CellPhoneNumber,
						IsEmailAddressVerified = ViewModel.IsEmailAddressVerified,
						IsCellPhoneNumberVerified = ViewModel.IsCellPhoneNumberVerified,
					};
				// **************************************************

				var isValid = Domain.SeedWork
					.ValidationHelper.IsValid(entity: user);

				var results =
					Domain.SeedWork.ValidationHelper
					.GetValidationResults(entity: user);

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

				return RedirectToPage(pageName: "./Index");
			}
			catch (System.Exception ex)
			{
				Logger.Log
					(logLevel: LogLevel.Error, message: ex.Message);

				AddPageError(message:
					Resources.Messages.Errors.UnexpectedError);

				return Page();
			}
			finally
			{
				await DisposeDatabaseContextAsync();
			}
		}
		#endregion OnPost

		#region SetAccessibleRole
		private async System.Threading.Tasks.Task SetAccessibleRole()
		{
			RolesViewModel =
				await DatabaseContext.Roles
				.OrderBy(current => current.Ordering)
				.Select(current => new ViewModels.Pages.Admin.Roles.CommonViewModel
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
