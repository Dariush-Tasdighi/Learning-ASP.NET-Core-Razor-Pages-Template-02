using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.RoleManager
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
		public ViewModels.Pages.Admin.RoleManager.DeleteRoleViewModel ViewModel { get; private set; }
		// **********

		public async System.Threading.Tasks.Task OnGetAsync(System.Guid? id)
		{
			try
			{
				if (id.HasValue)
				{
					ViewModel =
						await DatabaseContext.Roles
						.Where(current => current.Id == id.Value)
						//.Where(current => current.IsDeleted == false)
						.Select(current => new ViewModels.Pages.Admin.RoleManager.DeleteRoleViewModel
						{
							Id = current.Id,
							Name = current.Name,
							IsActive = current.IsActive,
							IsSystemic = current.IsSystemic,
							IsDeletable = current.IsDeletable,
							InsertDateTime = current.InsertDateTime,
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
						await DatabaseContext.Roles
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
					//else if (foundedItem.IsSystemic || (foundedItem.IsDeletable == false))
					{
						string errorMessage = string.Format
							(Resources.Messages.Errors.UnableTo,
							Resources.DataDictionary.Delete,
							Resources.DataDictionary.Role);

						AddPageError(message: errorMessage);

						return Page();
					}
					else
					{
						//foundedItem.IsActive = false;
						foundedItem.IsDeleted = true;

						DatabaseContext.Roles.Update(entity: foundedItem);

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
