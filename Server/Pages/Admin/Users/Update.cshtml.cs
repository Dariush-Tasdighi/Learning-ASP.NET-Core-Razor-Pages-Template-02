using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.Users;

[Microsoft.AspNetCore.Authorization.Authorize
	(Roles = Infrastructure.Constants.Role.Admin)]
public class UpdateModel : Infrastructure.BasePageModelWithDatabaseContext
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
			<ViewModels.Shared.KeyValueViewModel>();
	}
	#endregion /Constructor(s)

	#region Property(ies)
	// **********
	private Microsoft.Extensions.Logging.ILogger<UpdateModel> Logger { get; }
	// **********

	// **********
	public System.Collections.Generic.List
		<ViewModels.Shared.KeyValueViewModel> RolesViewModel
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
				.Where(current => current.Id == id.Value)
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
				})
				.FirstOrDefaultAsync();

			if (ViewModel == null)
			{
				AddToastError
					(message: Resources.Messages.Errors.ThereIsNotAnyDataWithThisId);

				return RedirectToPage(pageName: "Index");
			}

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
			// **************************************************
			var foundedItem =
				await DatabaseContext.Users
				.Where(current => current.Id == ViewModel.Id)
				.FirstOrDefaultAsync();

			if (foundedItem == null)
			{
				AddToastError
					(message: Resources.Messages.Errors.ThereIsNotAnyDataWithThisId);

				return RedirectToPage(pageName: "Index");
			}
			// **************************************************

			// **************************************************
			var fixedAdminDescription =
				Dtat.Utility.FixText
				(text: ViewModel.AdminDescription);

			foundedItem.SetUpdateDateTime();

			foundedItem.RoleId = ViewModel.RoleId;
			foundedItem.IsActive = ViewModel.IsActive;
			foundedItem.Ordering = ViewModel.Ordering;
			foundedItem.IsProgrammer = ViewModel.IsProgrammer;
			foundedItem.IsUndeletable = ViewModel.IsUndeletable;
			foundedItem.AdminDescription = fixedAdminDescription;
			// **************************************************

			var affectedRows =
				await
				DatabaseContext.SaveChangesAsync();

			// **************************************************
			var successMessage = string.Format
				(Resources.Messages.Successes.Updated,
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
	#endregion /OnPost

	#region SetAccessibleRole
	private async System.Threading.Tasks.Task SetAccessibleRole()
	{
		RolesViewModel =
			await
			DatabaseContext.Roles
			.OrderBy(current => current.Ordering)
			.ThenBy(current => current.Name)
			.Select(current => new ViewModels.Shared.KeyValueViewModel
			{
				Id = current.Id,
				Name = current.Name,
			})
			.ToListAsync()
			;
	}
	#endregion /SetAccessibleRole
}
