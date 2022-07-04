namespace Server.Pages.Admin.MenuManager
{
	public class DetailsModel : Infrastructure.BasePageModelWithDatabase
	{
		public DetailsModel
			(Persistence.DatabaseContext databaseContext) : base(databaseContext: databaseContext)
		{
		}

		public void OnGet(System.Guid? id)
		{
		}
	}
}
