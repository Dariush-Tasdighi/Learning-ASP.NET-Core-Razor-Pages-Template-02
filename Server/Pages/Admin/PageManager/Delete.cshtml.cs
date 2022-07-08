using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.PageManager
{
	public class DeleteModel : Infrastructure.BasePageModelWithDatabase
	{
		public DeleteModel
			(Persistence.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<DeleteModel> logger) : base(databaseContext: databaseContext)
		{
			Logger = logger;
		}

		private Microsoft.Extensions.Logging.ILogger<DeleteModel> Logger { get; }

		public async System.Threading.Tasks.Task OnGetAsync(System.Guid? id)
		{
			{
				try
				{
					if (id.HasValue)
					{
					}
				}
				catch (System.Exception ex)
				{
					Logger.LogError(message: ex.Message);

					AddToastError(message: Resources.Messages.Errors.UnexpectedError);
				}
				finally
				{
					await DisposeDatabaseContextAsync();
				}
			}
		}

		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnPostDeleteAsync(System.Guid? id)
		{
			try
			{
				if (id.HasValue)
				{
				}
			}
			catch (System.Exception ex)
			{
				Logger.LogError(message: ex.Message);

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
