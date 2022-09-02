//using System.Linq;
//using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Server.Pages.Admin.PageManager
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Infrastructure.Constants.Role.Admin)]
	public class IndexModel : Infrastructure.BasePageModelWithDatabaseContext
	{
		public IndexModel
			(Data.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<IndexModel> logger) : base(databaseContext: databaseContext)
		{
			Logger = logger;
		}

		// **********
		private Microsoft.Extensions.Logging.ILogger<IndexModel> Logger { get; }
		// **********

		// TO DO: Let Users Select Page Size
		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult>
			OnGetAsync(int pageSize = 10, int pageNumber = 1)
		{
			try
			{
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
