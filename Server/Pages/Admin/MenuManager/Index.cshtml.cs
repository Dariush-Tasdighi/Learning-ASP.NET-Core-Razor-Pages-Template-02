using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.MenuManager
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
				<ViewModels.Pages.Admin.MenuManager.GetMenuItemViewModel>();
		}
		#endregion Constructor(s)

		#region Property(ies)
		// **********
		private Microsoft.Extensions.Logging.ILogger<IndexModel> Logger { get; }
		// **********

		// **********
		public ViewModels.Shared.PaginationWithDataViewModel
			<ViewModels.Pages.Admin.MenuManager.GetMenuItemViewModel> ViewModel
		{ get; private set; }
		// **********
		#endregion Property(ies)

		#region On Get
		// TO DO: Let Users Select Page Size
		public async System.Threading.Tasks.Task
			OnGetAsync(int pageSize = 10, int pageNumber = 1, System.Guid? id = null)
		{
			try
			{
				if (pageNumber > 0)
				{
					// **************************************************
					ViewModel = new ViewModels.Shared.PaginationWithDataViewModel
						<ViewModels.Pages.Admin.MenuManager.GetMenuItemViewModel>
					{
						PageInformation = new()
						{
							PageSize = pageSize,
							PageNumber = pageNumber,
						},
					};
					// **************************************************

					var data =
						DatabaseContext.Menus
						.Where(current => current.IsDeleted == false)
						.AsQueryable();

					if (id.HasValue)
					{
						data = data
							.Where(current => current.ParentId == id.Value)
							;
					}
					else
					{
						data = data
							.Where(current => current.ParentId == null)
							;
					}

					// **************************************************
					ViewModel.PageInformation.TotalCount = await data.CountAsync();

					if (ViewModel.PageInformation.TotalCount > 0)
					{
						ViewModel.Data =
							await data
							.Skip((pageNumber - 1) * pageSize)
							.Take(pageSize)
							.Select(current => new ViewModels.Pages.Admin.MenuManager.GetMenuItemViewModel
							{
								Id = current.Id,
								Icon = current.Icon,
								Title = current.Title,
								IsPublic = current.IsPublic,
								IsActive = current.IsActive,
								IsDeleted = current.IsDeleted,
								IsDeletable = current.IsDeletable,
								HasAnySubMenu = current.Children.Any(),
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
						// To DO: Show an Error Message and/or Redirect to...!
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
		}
		#endregion /On Get
	}
}
