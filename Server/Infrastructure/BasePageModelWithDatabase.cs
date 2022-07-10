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

		protected async
			System.Threading.Tasks.Task DisposeDatabaseContextAsync()
		{
			if (DatabaseContext != null)
			{
				await DatabaseContext.DisposeAsync();

				DatabaseContext = null;
			}
		}
	}
}
