using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.Users
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Infrastructure.Constant.Role.Admin)]
	public class UpdateModel : Infrastructure.BasePageModelWithDatabase
	{
		#region Constructor(s)
		public UpdateModel(Data.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<UpdateModel> logger) :
			base(databaseContext: databaseContext)
		{
			Logger = logger;

			ViewModel = new();

			RolesViewModel =
				new System.Collections.Generic.List
				<ViewModels.Pages.Admin.Roles.CommonViewModel>();
		}
		#endregion /Constructor(s)

		#region Property(ies)
		// **********
		private Microsoft.Extensions.Logging.ILogger<UpdateModel> Logger { get; }
		// **********

		// **********
		public System.Collections.Generic.List
			<ViewModels.Pages.Admin.Roles.CommonViewModel> RolesViewModel
		{ get; private set; }
		// **********

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Pages.Admin.Users.UpdateViewModel ViewModel { get; set; }
		// **********
		#endregion /Property(ies)

		#region OnGet
		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(System.Guid? id)
		{
			try
			{
				if (id.HasValue == false)
				{
					AddToastError
						(message: Resources.Messages.Errors.IdIsNull);

					return RedirectToPage(pageName: "Index");
				}

				await SetAccessibleRole();

				ViewModel =
					await
					DatabaseContext.Users
					.Where(current => current.Id == id)
					.Select(current => new ViewModels.Pages.Admin.Users.UpdateViewModel
					{
						Id = current.Id,
						RoleId = current.RoleId,
						Ordering = current.Ordering,
						IsActive = current.IsActive,
						IsProgrammer = current.IsProgrammer,
						EmailAddress = current.EmailAddress,
						IsUndeletable = current.IsUndeletable,
						AdminDescription = current.AdminDescription,
					}).FirstOrDefaultAsync();

				if (ViewModel == null)
				{
					AddToastError
						(message: Resources.Messages.Errors.ThereIsNotAnyDataWithThisId);

					return RedirectToPage(pageName: "Index");
				}
			}
			catch (System.Exception ex)
			{
				Logger.LogError
					(message: Domain.SeedWork.Constants.Logger.ErrorMessage, args: ex.Message);

				AddPageError
					(message: Resources.Messages.Errors.UnexpectedError);
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
			<Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync(System.Guid id)
		{
			if (ModelState.IsValid == false)
			{
				return Page();
			}

			try
			{
				var foundedItem =
					await DatabaseContext.Users
					.Where(current => current.Id == id)
					.FirstOrDefaultAsync();

				if (foundedItem == null)
				{
					AddToastError
						(message: Resources.Messages.Errors.ThereIsNotAnyDataWithThisId);

					return RedirectToPage(pageName: "Index");
				}

				// **************************************************
				string? fixedAdminDescription =
					Dtat.Utility.FixText(text: ViewModel.AdminDescription);

				foundedItem.SetUpdateDateTime();

				foundedItem.RoleId = ViewModel.RoleId;
				foundedItem.IsActive = ViewModel.IsActive;
				foundedItem.Ordering = ViewModel.Ordering;
				foundedItem.IsProgrammer = ViewModel.IsProgrammer;
				foundedItem.IsUndeletable = ViewModel.IsUndeletable;
				foundedItem.AdminDescription = fixedAdminDescription;
				// **************************************************

				//var isValid =
				//	Domain.SeedWork.ValidationHelper.IsValid(entity: foundedItem);

				//var results =
				//	Domain.SeedWork.ValidationHelper.GetValidationResults(entity: foundedItem);

				// **************************************************
				int affectedRows =
						await DatabaseContext.SaveChangesAsync();

				string successMessage = string.Format
					(Resources.Messages.Successes.Updated,
					Resources.DataDictionary.User);
				// **************************************************

				return RedirectToPage(pageName: "Index");
			}
			catch (System.Exception ex)
			{
				Logger.LogError
					(message: Domain.SeedWork.Constants.Logger.ErrorMessage, args: ex.Message);

				AddPageError
					(message: Resources.Messages.Errors.UnexpectedError);

				return Page();
			}
			finally
			{
				await DisposeDatabaseContextAsync();
			}
		}
		#endregion /OnPost

		#region SetAccessibleRole
		private async System.Threading.Tasks.Task SetAccessibleRole()
		{
			RolesViewModel =
				await
				DatabaseContext.Roles
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
