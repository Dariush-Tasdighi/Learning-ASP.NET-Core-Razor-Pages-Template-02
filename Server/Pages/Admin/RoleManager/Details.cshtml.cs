namespace Server.Pages.Admin.RoleManager
{
	public class DetailsModel : Infrastructure.BasePageModelWithDatabase
	{
		public DetailsModel
			(Persistence.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<DetailsModel> logger) : base(databaseContext: databaseContext)
		{
			Logger = logger;
		}

		private Microsoft.Extensions.Logging.ILogger<DetailsModel> Logger { get; }

		public void OnGet()
		{
		}
	}
}
