using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Server.Pages.Admin.UserManagement
{
	public class IndexModel : Infrastructure.BasePageModelWithDatabase
	{
		public IndexModel
			(Persistence.DatabaseContext databaseContext) : base(databaseContext: databaseContext)
		{
			ViewModel = new();
		}

		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Shared.PaginationWithDataViewModel<Domain.Account.User> ViewModel { get; set; }

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
							<Domain.Account.User>
							{
								PageInformation = new()
								{
									PageSize = pageSize,
									PageNumber = pageNumber,
								},
							};

						ViewModel.PageInformation.TotalCount =
							await DatabaseContext.Users.CountAsync();

						if (ViewModel.PageInformation.TotalCount > 0)
						{
							ViewModel.Data =
								await DatabaseContext.Users
								.Skip((pageNumber - 1) * pageSize)
								.Take(pageSize)
								.ToListAsync();
						}
					}
					else
					{
						return;
					}
				}
				catch (System.Exception ex)
				{
					// Log ex.Message, Show Unexpected Error

					AddToastError(message: ex.Message);
				}
				finally
				{
					if (DatabaseContext is not null)
					{
						await DatabaseContext.DisposeAsync();

						DatabaseContext = null;
					}
				}
			}
		}
	}
}
