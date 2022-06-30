namespace Server.Pages.Admin.RoleManager
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

		public void OnGet()
		{
		}
	}
}
