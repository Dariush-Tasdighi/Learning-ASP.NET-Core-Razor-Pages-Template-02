using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.RoleManager
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Domain.SeedWork.Constant.SystemicRole.Admin)]
	public class IndexModel : Infrastructure.BasePageModelWithDatabase
	{
		public IndexModel
			(Persistence.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<IndexModel> logger) : base(databaseContext: databaseContext)
		{
			Logger = logger;

			ViewModel = new();
		}

		// **********
		private Microsoft.Extensions.Logging.ILogger<IndexModel> Logger { get; }
		// **********

		// **********
		public ViewModels.Shared.PaginationWithDataViewModel
			<ViewModels.Pages.Admin.RoleManager.GetRoleItemInfoViewModel> ViewModel
		{ get; private set; }
		// **********

		// TO DO: Let User Select Page Size
		public async
			System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult>
			OnGetAsync(int pageSize = 10, int pageNumber = 1)
		{
			try
			{
				if (pageNumber > 0)
				{
					// **************************************************
					ViewModel =
						new ViewModels.Shared.PaginationWithDataViewModel
						<ViewModels.Pages.Admin.RoleManager.GetRoleItemInfoViewModel>
						{
							PageInformation = new()
							{
								PageSize = pageSize,
								PageNumber = pageNumber,
							},
						};
					// **************************************************

					// **************************************************
					ViewModel.PageInformation.TotalCount =
						await DatabaseContext.Roles.CountAsync();

					if (ViewModel.PageInformation.TotalCount > 0)
					{
						ViewModel.Data =
							await DatabaseContext.Roles
							.OrderBy(current => current.Ordering)
							.Skip((pageNumber - 1) * pageSize)
							.Take(pageSize)
							.Select(current => new ViewModels.Pages.Admin.RoleManager.GetRoleItemInfoViewModel
							{
								Id = current.Id,
								Name = current.Name,
								IsActive = current.IsActive,
								IsDeleted = current.IsDeleted,
								IsSystemic = current.IsSystemic,
								IsDeletable = current.IsDeletable,
								InsertDateTime = current.InsertDateTime,
								UpdateDateTime = current.UpdateDateTime,
							})
							.AsNoTracking()
							.ToListAsync()
							;
					}
					// **************************************************
				}

				if ((ViewModel == null) || (ViewModel.Data == null) || (ViewModel.Data.Any() == false))
				{
					return RedirectToPage(pageName: "/admin/rolemanager/create");
				}
			}
			catch (System.Exception ex)
			{
				Logger.LogError(message: ex.Message);

				//System.Console.WriteLine(value: ex.Message);

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
