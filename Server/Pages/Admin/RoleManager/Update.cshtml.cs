namespace Server.Pages.Admin.RoleManager
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

		public void OnGet()
		{
		}
	}
}
