using Microsoft.EntityFrameworkCore;

namespace Persistence
{
	public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
	{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public DatabaseContext
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
			(Microsoft.EntityFrameworkCore.DbContextOptions<DatabaseContext> options) : base(options: options)
		{
			//Database.EnsureDeleted();
			Database.EnsureCreated();
		}

		public Microsoft.EntityFrameworkCore.DbSet<Domain.Models.Menu> Menus { get; set; }

		public Microsoft.EntityFrameworkCore.DbSet<Domain.Models.User> Users { get; set; }

		public Microsoft.EntityFrameworkCore.DbSet<Domain.Models.Role> Roles { get; set; }

		protected override void OnConfiguring
			(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies();

			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating
			(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly
				(typeof(Configurations.UserConfiguration).Assembly);
		}
	}
}
