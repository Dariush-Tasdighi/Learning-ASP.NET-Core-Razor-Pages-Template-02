using Domain;
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

		public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }

		public Microsoft.EntityFrameworkCore.DbSet<Role> Roles { get; set; }

		public Microsoft.EntityFrameworkCore.DbSet<Page> Pages { get; set; }

		public Microsoft.EntityFrameworkCore.DbSet<MenuItem> MenuItems { get; set; }

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

		protected override void ConfigureConventions
			(Microsoft.EntityFrameworkCore.ModelConfigurationBuilder builder)
		{
			builder.Properties<System.DateOnly>()
				.HaveConversion<Conventions.DateTimeConventions.DateOnlyConverter>()
				.HaveColumnType(typeName: nameof(System.DateTime.Date))
				;

			builder.Properties<System.DateOnly?>()
				.HaveConversion<Conventions.DateTimeConventions.NullableDateOnlyConverter>()
				.HaveColumnType(typeName: nameof(System.DateTime.Date))
				;
		}
	}
}
