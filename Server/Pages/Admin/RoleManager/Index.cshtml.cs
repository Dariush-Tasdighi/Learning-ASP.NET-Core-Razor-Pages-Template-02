using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.RoleManager
{
	public class IndexModel : Infrastructure.BasePageModelWithDatabase
	{
		public IndexModel
			(Persistence.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<IndexModel> logger) : base(databaseContext: databaseContext)
		{
			Logger = logger;

			ViewModel = new();
		}

		private Microsoft.Extensions.Logging.ILogger<IndexModel> Logger { get; }

		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Shared.PaginationWithDataViewModel
			<ViewModels.Pages.Admin.RoleManager.GetRoleItemViewModel> ViewModel
		{ get; set; }

		public async
			System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult>
			OnGetAsync(int pageSize = 10, int pageNumber = 1)
		{
			try
			{
				if (pageNumber > 0)
				{
					ViewModel =
						new ViewModels.Shared.PaginationWithDataViewModel
						<ViewModels.Pages.Admin.RoleManager.GetRoleItemViewModel>
						{
							PageInformation = new()
							{
								PageSize = pageSize,
								PageNumber = pageNumber,
							},
						};

					ViewModel.PageInformation.TotalCount =
						await DatabaseContext.Roles.CountAsync();

					if (ViewModel.PageInformation.TotalCount > 0)
					{
						ViewModel.Data =
							await DatabaseContext.Roles
							.Skip((pageNumber - 1) * pageSize)
							.Take(pageSize)
							.Select(current => new ViewModels.Pages.Admin.RoleManager.GetRoleItemViewModel
							{
								Id = current.Id,
								Name = current.Name,
								IsActive = current.IsActive,
								IsDeleted = current.IsDeleted,
								IsSystemic = current.IsSystemic,
								IsDeletable = current.IsDeletable,
							})
							.ToListAsync()
							;
					}
				}

				if ((ViewModel == null) || (ViewModel.Data == null) || (ViewModel.Data.Any() == false))
				{
					return NotFound();
				}
			}
			catch (System.Exception ex)
			{
				Logger.LogError(message: ex.Message);

				System.Console.WriteLine(value: ex.Message);

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
