using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.RoleManager
{
	//[Microsoft.AspNetCore.Authorization.Authorize
	//	(Roles = Domain.SeedWork.Constant.SystemicRole.Admin)]
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

		public async System.Threading.Tasks.Task OnGetAsync(System.Guid id)
		{
			try
			{
				ViewModel =
					await DatabaseContext.Roles
					.Where(current => current.Id == id)
					//.Where(current => current.IsDeleted == false)
					.Select(current => new ViewModels.Pages.Admin.RoleManager.DeleteRoleViewModel
					{
						Id = current.Id,
						Name = current.Name,
						IsActive = current.IsActive,
						IsSystemic = current.IsSystemic,
						IsUndeletable = current.IsUndeletable,
						InsertDateTime = current.InsertDateTime,
					})
					.FirstOrDefaultAsync();
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
						//.Where(current => current.IsDeleted == false)
						.FirstOrDefaultAsync();

					if (foundedItem == null)
					{
						string errorMessage = string.Format
							(Resources.Messages.Errors.NotFound,
							Resources.DataDictionary.Role);

						AddToastError(message: errorMessage);

						return RedirectToPage("./Index");
					}
					else if (foundedItem.IsUndeletable)
					{
						string errorMessage = string.Format
							(Resources.Messages.Errors.UnableTo,
							Resources.DataDictionary.Delete,
							Resources.DataDictionary.Role);

						AddToastError(message: errorMessage);

						return RedirectToPage("./Index");
					}
					else
					{
						DatabaseContext.Remove(entity: foundedItem);

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
