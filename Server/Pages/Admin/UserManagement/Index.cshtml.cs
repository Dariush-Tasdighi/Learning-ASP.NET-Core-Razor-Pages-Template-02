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

		public void OnGet(int pageSize = 10, int pageNumber = 1)
		{
			if (DatabaseContext is not null)
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

				ViewModel.Data =
					DatabaseContext.Users
					//.Where(current => string.IsNullOrWhiteSpace(category) || current.Category.ToLower() == category.ToLower())
					.Skip((pageNumber - 1) * pageSize)
					.Take(pageSize)
					.ToList();

				ViewModel.PageInformation.TotalCount =
					DatabaseContext.Users
					//.Where(current => string.IsNullOrWhiteSpace(category) || current.Category.ToLower() == category.ToLower())
					.Count();

				//return result;
			}
		}
	}
}
