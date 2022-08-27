using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.Users
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Infrastructure.Constants.Role.Admin)]
	public class CreateModel : Infrastructure.BasePageModelWithDatabaseContext
	{
		#region Constructor(s)
		public CreateModel(Data.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<CreateModel> logger) :
			base(databaseContext: databaseContext)
		{
			Logger = logger;

			ViewModel = new();

			RolesViewModel = new System.Collections.Generic.List
				<ViewModels.Pages.Admin.Roles.CommonViewModel>();
		}
		#endregion /Constructor(s)

		#region Property(ies)
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
		#endregion /Property(ies)

		#region OnGet
		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync()
		{
			try
			{
				await SetAccessibleRole();

				return Page();
			}
			catch (System.Exception ex)
			{
				Logger.LogError
					(message: Domain.SeedWork.Constants.Logger.ErrorMessage, args: ex.Message);

				AddToastError
					(message: Resources.Messages.Errors.UnexpectedError);

				return RedirectToPage(pageName: "Index");
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
				var foundedAny =
					await
					DatabaseContext.Users
					.Where(current => current.EmailAddress.ToLower() == ViewModel.EmailAddress.ToLower())
					.Where(current => current.IsEmailAddressVerified)
					.AnyAsync();

				if (foundedAny)
				{
					// **************************************************
					var errorMessage = string.Format
						(Resources.Messages.Errors.AlreadyExists,
						Resources.DataDictionary.EmailAddress);

					AddPageError
						(message: errorMessage);
					// **************************************************

					return Page();
				}

				// **************************************************
				var hashedPassword =
					Dtat.Security.Hashing.GetSha256
					(text: ViewModel.Password);

				var fixedDescription =
					Dtat.Utility.FixText
					(text: ViewModel.AdminDescription);

				Domain.User user =
					new(emailAddress: ViewModel.EmailAddress)
					{
						Password = hashedPassword,
						RoleId = ViewModel.RoleId,
						IsEmailAddressVerified = true,
						Ordering = ViewModel.Ordering,
						IsActive = ViewModel.IsActive,
						AdminDescription = fixedDescription,
						IsProgrammer = ViewModel.IsProgrammer,
						IsUndeletable = ViewModel.IsUndeletable,
						CellPhoneNumber = ViewModel.CellPhoneNumber,
					};

				var entityEntry =
					await
					DatabaseContext.AddAsync(entity: user);

				var affectedRow =
					await
					DatabaseContext.SaveChangesAsync();
				// **************************************************

				// **************************************************
				var successMessage = string.Format
					(Resources.Messages.Successes.Created,
					Resources.DataDictionary.User);

				AddToastSuccess(message: successMessage);
				// **************************************************

				return RedirectToPage(pageName: "Index");
			}
			catch (System.Exception ex)
			{
				Logger.LogError
					(message: Domain.SeedWork.Constants.Logger.ErrorMessage, args: ex.Message);

				AddToastError
					(message: Resources.Messages.Errors.UnexpectedError);

				return RedirectToPage(pageName: "Index");
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
				.ThenBy(current => current.Name)
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
