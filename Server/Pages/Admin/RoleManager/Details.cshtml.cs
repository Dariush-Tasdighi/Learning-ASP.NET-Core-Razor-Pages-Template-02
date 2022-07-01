using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.RoleManager
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
			ViewModel = new();
		}

		// **********
		private Microsoft.Extensions.Logging.ILogger<DetailsModel> Logger { get; }
		// **********

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Pages.Admin.RoleManager.GetRoleItemDetailsViewModel ViewModel { get; set; }
		// **********

		public async
			System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult>
			OnGetAsync(System.Guid? id)
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
						await DatabaseContext.Roles
						.Where(current => current.Id == id.Value)
						.Select(current => new ViewModels.Pages.Admin.RoleManager.GetRoleItemDetailsViewModel
						{
							Id = current.Id,
							Name = current.Name,
							IsActive = current.IsActive,
							IsDeleted = current.IsDeleted,
							IsSystemic = current.IsSystemic,
							Description = current.Description,
							IsDeletable = current.IsDeletable,
							InsertDateTime = current.InsertDateTime,
							UpdateDateTime = current.UpdateDateTime,
						}).FirstOrDefaultAsync();

					if (ViewModel.Id.HasValue)
					{
						// Might Not Be Used
						ViewModel.NumberOfUserWithThisRole =
							await DatabaseContext.Users
							.Where(current => current.RoleId == ViewModel.Id)
							.CountAsync();
					}
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
