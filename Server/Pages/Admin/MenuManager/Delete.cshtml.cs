using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.MenuManager
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Domain.SeedWork.Constant.SystemicRole.Admin)]
	public class DeleteModel : Infrastructure.BasePageModelWithDatabase
	{
		public DeleteModel
			(Persistence.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<DeleteModel> logger) : base(databaseContext: databaseContext)
		{
			Logger = logger;

			ViewModel = new();
		}

		// **********
		private Microsoft.Extensions.Logging.ILogger<DeleteModel> Logger { get; }
		// **********

		// **********
		public ViewModels.Pages.Admin.MenuManager.DeleteMenuRequestViewModel ViewModel { get; private set; }
		// **********

		public async System.Threading.Tasks.Task OnGetAsync(System.Guid? id)
		{
			try
			{
				if (id.HasValue)
				{
					ViewModel =
						await DatabaseContext.Menus
						.Where(current => current.Id == id.Value)
						//.Where(current => current.IsDeleted == false)
						.Select(current => new ViewModels.Pages.Admin.MenuManager.DeleteMenuRequestViewModel
						{
							Id = current.Id,
							Link = current.Link,
							Title = current.Title,
							IsActive = current.IsActive,
							IsPublic = current.IsPublic,
							InsertDateTime = current.InsertDateTime,
							NumberOfSubMenus = current.Children.Count(),
						})
						.FirstOrDefaultAsync();
				}
			}
			catch (System.Exception ex)
			{
				Logger.LogError(message: ex.Message);

				AddToastError(message: Resources.Messages.Errors.UnexpectedError);
			}
			finally
			{
				await DisposeDatabaseContextAsync();
			}
		}


		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnPostDeleteAsync(System.Guid? id)
		{
			try
			{
				if (id.HasValue)
				{
					var foundedItem =
						await DatabaseContext.Menus
						.Where(current => current.Id == id.Value)
						.Where(current => current.IsDeleted == false)
						.FirstOrDefaultAsync();

					if (foundedItem == null)
					{
						string errorMessage = string.Format
							(Resources.Messages.Errors.NotFound,
							Resources.DataDictionary.Role);

						AddToastError(message: errorMessage);

						return RedirectToPage("./Index");
					}
					else if (foundedItem.IsDeletable == false)
					{
						string errorMessage = string.Format
							(Resources.Messages.Errors.UnableTo,
							Resources.DataDictionary.Delete,
							Resources.DataDictionary.Menu);

						AddPageError(message: errorMessage);

						return Page();
					}
					else
					{
						//foundedItem.IsActive = false;
						foundedItem.IsDeleted = true;

						DatabaseContext.Menus.Update(entity: foundedItem);

						await DatabaseContext.SaveChangesAsync();

						return RedirectToPage("./Index");
					}
				}
			}
			catch (System.Exception ex)
			{
				Logger.LogError(message: ex.Message);

				AddToastError(message: Resources.Messages.Errors.UnexpectedError);
			}
			finally
			{
				await DisposeDatabaseContextAsync();
			}

			return Page();
		}
	}
}
