namespace Persistence
{
	public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
	{
		public DatabaseContext
			(Microsoft.EntityFrameworkCore.DbContextOptions<DatabaseContext> options) : base(options: options)
		{
			Database.EnsureCreated();
		}

		protected override void OnConfiguring
			(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}

		public Microsoft.EntityFrameworkCore.DbSet<Domain.Cms.Account.User>? Users { get; set; }

		protected override void OnModelCreating
			(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly
					(typeof(Configurations.Account.UserConfiguration).Assembly);
		}
	}
}
