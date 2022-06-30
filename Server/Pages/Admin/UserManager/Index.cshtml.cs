using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.UserManager
{
	//[Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
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
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Shared.PaginationWithDataViewModel
			<ViewModels.Pages.Admin.UserManager.GetUserItemViewModel> ViewModel
		{ get; set; }
		// **********

		public async
			System.Threading.Tasks.Task
			OnGetAsync(int pageSize = 10, int pageNumber = 1)
		{
			if (DatabaseContext is not null)
			{
				try
				{
					if (pageNumber > 0)
					{
						ViewModel =
							new ViewModels.Shared.PaginationWithDataViewModel
							<ViewModels.Pages.Admin.UserManager.GetUserItemViewModel>
							{
								PageInformation = new()
								{
									PageSize = pageSize,
									PageNumber = pageNumber,
								},
							};

						ViewModel.PageInformation.TotalCount =
							await DatabaseContext.Users.CountAsync();

						// **************************************************
						if (ViewModel.PageInformation.TotalCount > 0)
						{
							ViewModel.Data =
								await DatabaseContext.Users
								.Skip((pageNumber - 1) * pageSize)
								.Take(pageSize)
								.Select(current => new ViewModels.Pages.Admin.UserManager.GetUserItemViewModel
								{
									Id = current.Id,
									Username = current.Username,
									IsActive = current.IsActive,
									IsDeleted = current.IsDeleted,
									IsVerified = current.IsVerified,
									//EmailAddress = current.EmailAddress,
									InsertDateTime = current.InsertDateTime,
								})
								.ToListAsync()
								;
						}
						// **************************************************

						if ((ViewModel == null) || (ViewModel.Data == null) || (ViewModel.Data.Any() == false))
						{
							// To DO: Show an Error Message or Redirect to...!
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
		}
	}
}
