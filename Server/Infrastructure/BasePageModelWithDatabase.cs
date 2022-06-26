namespace Infrastructure
{
	public abstract class BasePageModelWithDatabase : BasePageModel
	{
		public BasePageModelWithDatabase
			(Persistence.DatabaseContext databaseContext) : base()
		{
			DatabaseContext = databaseContext;
		}

		protected Persistence.DatabaseContext? DatabaseContext { get; set; }
	}
}
