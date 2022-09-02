using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.Roles;

[Microsoft.AspNetCore.Authorization
	.Authorize(Roles = Constants.Role.Admin)]
public class DeleteModel : Infrastructure.BasePageModelWithDatabaseContext
{
	public DeleteModel
		(Data.DatabaseContext databaseContext,
		Microsoft.Extensions.Logging.ILogger<DeleteModel> logger) :
		base(databaseContext: databaseContext)
	{
		Logger = logger;
		ViewModel = new();
	}

	// **********
	private Microsoft.Extensions.Logging.ILogger<DeleteModel> Logger { get; }
	// **********

	// **********
	[Microsoft.AspNetCore.Mvc.BindProperty]
	public ViewModels.Pages.Admin.Roles.DetailsOrDeleteViewModel ViewModel { get; private set; }
	// **********

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

			ViewModel =
				await
				DatabaseContext.Roles
				.Where(current => current.Id == id.Value)
				.Select(current => new ViewModels.Pages.Admin.Roles.DetailsOrDeleteViewModel()
				{
					Id = current.Id,
					Name = current.Name,
					IsActive = current.IsActive,
					Ordering = current.Ordering,
					UserCount = current.Users.Count,
					Description = current.Description,
					InsertDateTime = current.InsertDateTime,
					UpdateDateTime = current.UpdateDateTime,
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
				(message: Constants.Logger.ErrorMessage, args: ex.Message);

			AddToastError
				(message: Resources.Messages.Errors.UnexpectedError);

			return RedirectToPage(pageName: "Index");
		}
		finally
		{
			await DisposeDatabaseContextAsync();
		}
	}

	public async System.Threading.Tasks.Task
		<Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync(System.Guid? id)
	{
		try
		{
			if (id.HasValue == false)
			{
				AddToastError
					(message: Resources.Messages.Errors.IdIsNull);

				return RedirectToPage(pageName: "Index");
			}

			var hasAnyChildren =
				await
				DatabaseContext.Users
				.Where(current => current.RoleId == id.Value)
				.AnyAsync();

			if (hasAnyChildren)
			{
				// **************************************************
				var errorMessage = string.Format
					(Resources.Messages.Errors.CascadeDelete,
					Resources.DataDictionary.Role);

				AddToastError(message: errorMessage);
				// **************************************************

				return RedirectToPage(pageName: "Index");
			}

			// **************************************************
			var foundedItem =
				await
				DatabaseContext.Roles
				.Where(current => current.Id == id.Value)
				.FirstOrDefaultAsync();

			if (foundedItem == null)
			{
				AddToastError
					(message: Resources.Messages.Errors.ThereIsNotAnyDataWithThisId);

				return RedirectToPage(pageName: "Index");
			}

			DatabaseContext.Remove(entity: foundedItem);

			await DatabaseContext.SaveChangesAsync();
			// **************************************************

			// **************************************************
			var successMessage = string.Format
				(Resources.Messages.Successes.Deleted,
				Resources.DataDictionary.Role);

			AddToastSuccess(message: successMessage);
			// **************************************************

			return RedirectToPage(pageName: "Index");
		}
		catch (System.Exception ex)
		{
			Logger.LogError
				(message: Constants.Logger.ErrorMessage, args: ex.Message);

			AddToastError
				(message: Resources.Messages.Errors.UnexpectedError);

			return RedirectToPage(pageName: "Index");
		}
		finally
		{
			await DisposeDatabaseContextAsync();
		}
	}
}
