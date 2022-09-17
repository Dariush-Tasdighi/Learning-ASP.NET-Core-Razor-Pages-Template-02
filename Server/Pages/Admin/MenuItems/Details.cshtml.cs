using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Server.Pages.Admin.MenuItems;

[Microsoft.AspNetCore.Authorization
	.Authorize(Roles = Constants.Role.Admin)]
public class DetailsModel : Infrastructure.BasePageModelWithDatabaseContext
{
	public DetailsModel(Data.DatabaseContext databaseContext,
		Microsoft.Extensions.Logging.ILogger<DetailsModel> logger) :
		base(databaseContext: databaseContext)
	{
		Logger = logger;
		ViewModel = new();
	}

	// **********
	private Microsoft.Extensions.Logging.ILogger<DetailsModel> Logger { get; }
	// **********

	// **********
	public ViewModels.Pages.Admin.MenuItems.DetailsOrDeleteViewModel ViewModel { get; set; }
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
				.Select(current => new ViewModels.Pages.Admin.MenuItems.DetailsOrDeleteViewModel
				{
					Id = current.Id,
					Link = current.Link,
					Icon = current.Icon,
					Title = current.Title,
					Ordering = current.Ordering,
					IsPublic = current.IsPublic,
					IsActive = current.IsActive,
					ParentTitle = current.Parent.Title,
					IsDeleted = current.IsDeleted,
					IconPosition = current.IconPosition,
					IsUndeletable = current.IsUndeletable,
					UpdateDateTime = current.UpdateDateTime,
					InsertDateTime = current.InsertDateTime,
					NumberOfSubMenus = current.SubMenus.Count,
				}).FirstOrDefaultAsync();

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
}
