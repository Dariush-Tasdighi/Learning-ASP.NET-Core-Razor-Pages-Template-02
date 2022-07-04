namespace Server.Pages.Admin.MenuManager
{
	public class UpdateModel : Infrastructure.BasePageModelWithDatabase
	{
		public UpdateModel
			(Persistence.DatabaseContext databaseContext) : base(databaseContext: databaseContext)
		{
		}

		public void OnGet(System.Guid? id)
		{
		}
	}
}
