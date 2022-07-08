using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Server.Pages.Admin.MenuItemManager
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Domain.SeedWork.Constant.SystemicRole.Admin)]
	public class DetailsModel : Infrastructure.BasePageModelWithDatabase
	{
		public DetailsModel
			(Persistence.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<DetailsModel> logger) : base(databaseContext: databaseContext)
		{
			Logger = logger;
		}

		// **********
		private Microsoft.Extensions.Logging.ILogger<DetailsModel> Logger { get; }
		// **********

		// **********
		public ViewModels.Pages.Admin.MenuItemManager.GetMenuItemDetailsViewModel? ViewModel { get; private set; }
		// **********

		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(System.Guid? id)
		{
			try
			{
				if (id == null)
				{
					string errorMessage = string.Format
						(Resources.Messages.Validations.Required,
						Resources.DataDictionary.Id);

					AddPageError(message: errorMessage);
				}
				else
				{
					ViewModel =
						await DatabaseContext.MenuItems
						.Where(current => current.Id == id.Value)
						.Select(current => new ViewModels.Pages.Admin.MenuItemManager.GetMenuItemDetailsViewModel
						{
							//Id = current.Id,
							Link = current.Link,
							Icon = current.Icon,
							Title = current.Title,
							Ordering = current.Ordering,
							IsPublic = current.IsPublic,
							IsActive = current.IsActive,
							Parent = current.Parent.Title,
							IsDeleted = current.IsDeleted,
							IsDeletable = current.IsDeletable,
							IconPosition = current.IconPosition,
							UpdateDateTime = current.UpdateDateTime,
							InsertDateTime = current.InsertDateTime,
							NumberOfSubMenus = current.Children.Count,
						}).FirstOrDefaultAsync();
				}
			}
			catch (System.Exception ex)
			{
				Logger.LogError(message: ex.Message);

				AddPageError(message: Resources.Messages.Errors.UnexpectedError);
			}
			finally
			{
				await DisposeDatabaseContextAsync();
			}

			return Page();
		}
	}
}
