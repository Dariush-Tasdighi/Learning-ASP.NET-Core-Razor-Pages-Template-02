namespace Server.Pages.Admin.MenuManager
{
	public class DeleteModel : Infrastructure.BasePageModelWithDatabase
	{
		public DeleteModel
			(Persistence.DatabaseContext databaseContext) : base(databaseContext: databaseContext)
		{
		}

		public void OnGet(System.Guid? id)
		{
		}
	}
}
