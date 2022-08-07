namespace Infrastructure
{
	public abstract class BasePageModelWithDatabase : BasePageModel
	{
		public BasePageModelWithDatabase
			(Data.DatabaseContext databaseContext) : base()
		{
			DatabaseContext = databaseContext;
		}

		protected Data.DatabaseContext DatabaseContext { get; }

		protected async
			System.Threading.Tasks.Task DisposeDatabaseContextAsync()
		{
			if (DatabaseContext != null)
			{
				await DatabaseContext.DisposeAsync();

				//DatabaseContext = null;
			}
		}
	}
}
