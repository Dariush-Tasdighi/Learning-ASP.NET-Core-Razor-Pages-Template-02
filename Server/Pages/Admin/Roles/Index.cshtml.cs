using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.Roles
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Infrastructure.Constant.Role.Admin)]
	public class IndexModel : Infrastructure.BasePageModelWithDatabase
	{
		public IndexModel
			(Data.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<IndexModel> logger) :
			base(databaseContext: databaseContext)
		{
			Logger = logger;

			ViewModel =
				new System.Collections.Generic.List
				<ViewModels.Pages.Admin.Roles.IndexItemViewModel>();
		}

		// **********
		private Microsoft.Extensions.Logging.ILogger<IndexModel> Logger { get; }
		// **********

		// **********
		public System.Collections.Generic.IList
			<ViewModels.Pages.Admin.Roles.IndexItemViewModel> ViewModel
		{ get; private set; }
		// **********

		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync()
		{
			try
			{
				ViewModel =
					await
					DatabaseContext.Roles
					.OrderBy(current => current.Ordering)
					.ThenBy(current => current.Name)
					.Select(current => new ViewModels.Pages.Admin.Roles.IndexItemViewModel
					{
						Id = current.Id,
						Name = current.Name,
						IsActive = current.IsActive,
						Ordering = current.Ordering,
						UserCount = current.Users.Count,
						InsertDateTime = current.InsertDateTime,
						UpdateDateTime = current.UpdateDateTime,
					})
					.ToListAsync()
					;
			}
			catch (System.Exception ex)
			{
				Logger.LogError
					(message: ex.Message);

				AddPageError(message:
					Resources.Messages.Errors.UnexpectedError);
			}
			finally
			{
				await DisposeDatabaseContextAsync();
			}

			return Page();
		}
	}
}
