using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.MenuManager
{
	public class UpdateModel : Infrastructure.BasePageModelWithDatabase
	{
		public UpdateModel
			(Persistence.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<UpdateModel> logger) : base(databaseContext: databaseContext)
		{
			Logger = logger;
		}

		private Microsoft.Extensions.Logging.ILogger<UpdateModel> Logger { get; }

		public void OnGet(System.Guid? id)
		{
		}
	}
}
