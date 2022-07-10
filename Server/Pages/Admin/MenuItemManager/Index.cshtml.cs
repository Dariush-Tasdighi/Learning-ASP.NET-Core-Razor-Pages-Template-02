using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.MenuItemManager
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Domain.SeedWork.Constant.SystemicRole.Admin)]
	public class IndexModel : Infrastructure.BasePageModelWithDatabase
	{
		#region Constructor(s)
		public IndexModel
			(Persistence.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<IndexModel> logger) : base(databaseContext: databaseContext)
		{
			Logger = logger;

			ViewModel = new ViewModels.Shared.PaginationWithDataViewModel
				<ViewModels.Pages.Admin.MenuItemManager.GetMenuItemViewModel>();
		}
		#endregion Constructor(s)

		#region Property(ies)
		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public System.Guid? ParentId { get; set; }
		// **********

		// **********
		private Microsoft.Extensions.Logging.ILogger<IndexModel> Logger { get; }
		// **********

		// **********
		public ViewModels.Shared.PaginationWithDataViewModel
			<ViewModels.Pages.Admin.MenuItemManager.GetMenuItemViewModel> ViewModel
		{ get; private set; }
		// **********
		#endregion Property(ies)

		#region On Get
		// TO DO: Let Users Select Page Size
		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult>
			OnGetAsync(int pageSize = 10, int pageNumber = 1, System.Guid? id = null)
		{
			try
			{
				ParentId = id;

				if (pageNumber > 0)
				{
					// **************************************************
					ViewModel = new ViewModels.Shared.PaginationWithDataViewModel
						<ViewModels.Pages.Admin.MenuItemManager.GetMenuItemViewModel>
					{
						PageInformation = new()
						{
							PageSize = pageSize,
							PageNumber = pageNumber,
						},
					};
					// **************************************************

					var data =
						DatabaseContext.MenuItems
						//.Where(current => current.IsDeleted == false)
						.Where(current => current.ParentId == ParentId)
						;


					// **************************************************
					ViewModel.PageInformation.TotalCount = await data.CountAsync();

					if (ViewModel.PageInformation.TotalCount > 0)
					{
						ViewModel.Data =
							await data
							.Skip((pageNumber - 1) * pageSize)
							.Take(pageSize)
							.Select(current => new ViewModels.Pages.Admin.MenuItemManager.GetMenuItemViewModel
							{
								Id = current.Id,
								Icon = current.Icon,
								Title = current.Title,
								IsPublic = current.IsPublic,
								IsActive = current.IsActive,
								IsDeleted = current.IsDeleted,
								IsDeletable = current.IsDeletable,
								HasAnySubMenu = current.SubMenus.Any(),
								UpdateDateTime = current.UpdateDateTime,
								InsertDateTime = current.InsertDateTime,
							})
							.AsNoTracking()
							.ToListAsync()
							;
					}
					// **************************************************

					if ((ViewModel == null) || (ViewModel.Data == null) || (ViewModel.Data.Any() == false))
					{
						return RedirectToPage(pageName: "/admin/menuitemmanager/create");
					}
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
		#endregion /On Get
	}
}
