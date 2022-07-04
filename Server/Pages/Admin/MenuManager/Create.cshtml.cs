namespace Server.Pages.Admin.MenuManager
{
	public class CreateModel : Infrastructure.BasePageModelWithDatabase
	{
		public CreateModel
			(Persistence.DatabaseContext databaseContext) : base(databaseContext: databaseContext)
		{
		}

		public void OnGet(System.Guid? id)
		{
		}
	}
}
