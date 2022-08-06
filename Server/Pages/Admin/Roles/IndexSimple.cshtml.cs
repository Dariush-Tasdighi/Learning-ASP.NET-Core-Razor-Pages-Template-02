using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.Roles
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Infrastructure.Constant.Role.Admin)]
	public class IndexSimpleModel : Infrastructure.BasePageModelWithDatabase
	{
		public IndexSimpleModel
			(Data.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<IndexModel> logger) :
			base(databaseContext: databaseContext)
		{
			Logger = logger;

			ViewModel =
				new System.Collections.Generic.List<Domain.Role>();
		}

		// **********
		private Microsoft.Extensions.Logging.ILogger<IndexModel> Logger { get; }
		// **********

		// **********
		public System.Collections.Generic.IList<Domain.Role> ViewModel { get; private set; }
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
