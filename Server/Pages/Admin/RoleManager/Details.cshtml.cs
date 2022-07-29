using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.RoleManager
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Infrastructure.Constant.Role.Admin)]
	public class DetailsModel : Infrastructure.BasePageModelWithDatabase
	{
		public DetailsModel
			(Data.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<DetailsModel> logger) : base(databaseContext: databaseContext)
		{
			Logger = logger;

			ViewModel = new();
		}

		// **********
		private Microsoft.Extensions.Logging.ILogger<DetailsModel> Logger { get; }
		// **********

		// **********
		public ViewModels.Pages.Admin.RoleManager.GetRoleItemDetailsViewModel ViewModel { get; private set; }
		// **********

		public async
			System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult>
			OnGetAsync(System.Guid id)
		{
			try
			{
				ViewModel =
					await DatabaseContext.Roles
					.Where(current => current.Id == id)
					.Select(current => new ViewModels.Pages.Admin.RoleManager.GetRoleItemDetailsViewModel
					{
						Id = current.Id,
						Name = current.Name,
						Ordering = current.Ordering,
						IsActive = current.IsActive,
						//IsDeleted = current.IsDeleted,
						IsSystemic = current.IsSystemic,
						Description = current.Description,
						IsUndeletable = current.IsUndeletable,
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
