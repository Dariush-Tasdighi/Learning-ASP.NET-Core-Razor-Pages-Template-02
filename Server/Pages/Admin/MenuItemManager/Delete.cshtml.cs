using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Server.Pages.Admin.MenuItemManager;

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
	public ViewModels.Pages.Admin.MenuItemManager.DetailsOrDeleteViewModel ViewModel { get; set; }
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
				await DatabaseContext.MenuItems
				.Where(current => current.Id == id.Value)
				.Select(current => new ViewModels.Pages.Admin.MenuItemManager.DetailsOrDeleteViewModel
				{
					Id = current.Id,
					Link = current.Link,
					Title = current.Title,
					IsActive = current.IsActive,
					IsPublic = current.IsPublic,
					InsertDateTime = current.InsertDateTime,
					NumberOfSubMenus = current.SubMenus.Count(),
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
			// **************************************************
			if (id.HasValue == false)
			{
				AddToastError
					(message: Resources.Messages.Errors.IdIsNull);

				return RedirectToPage(pageName: "Index");
			}
			// **************************************************

			// **************************************************
			var hasAnyChildren =
					await
					DatabaseContext.MenuItems
					.Where(x => x.ParentId == id.Value)
					.AnyAsync();

			if (hasAnyChildren)
			{
				// **************************************************
				var errorMessage = string.Format
					(Resources.Messages.Errors.CascadeDelete,
					Resources.DataDictionary.MenuItem);

				AddToastError(message: errorMessage);
				// **************************************************

				return RedirectToPage(pageName: "Index");
			}
			// **************************************************

			// **************************************************
			var foundedItem =
				await
				DatabaseContext.MenuItems
				.Where(current => current.Id == id.Value)
				.FirstOrDefaultAsync();


			if (foundedItem == null)
			{
				string errorMessage = string.Format
					(Resources.Messages.Errors.NotFound,
					Resources.DataDictionary.MenuItem);

				AddToastError(message: errorMessage);

				return RedirectToPage("./Index");
			}
			else if (foundedItem.IsUndeletable)
			{
				string errorMessage = string.Format
					(Resources.Messages.Errors.UnableTo,
					Resources.ButtonCaptions.Delete,
					Resources.DataDictionary.MenuItem);

				AddPageError(message: errorMessage);

				return Page();
			}

			// **************************************************
			//Logical Delete
			foundedItem.IsDeleted = true;
			foundedItem.SetUpdateDateTime();

			var affectedRows =
				await
				DatabaseContext.SaveChangesAsync();
			// **************************************************

			// **************************************************
			var successMessage = string.Format
				(Resources.Messages.Successes.Deleted,
				Resources.DataDictionary.MenuItem);

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
