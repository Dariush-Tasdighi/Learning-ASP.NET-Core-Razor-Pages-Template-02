namespace Server.Pages.Admin.UserManagement
{
	public class UpdateModel : Infrastructure.BasePageModelWithDatabase
	{
		public UpdateModel
			(Persistence.DatabaseContext databaseContext) : base(databaseContext: databaseContext)
		{

		}
		public void OnGet()
		{
		}
	}
}
