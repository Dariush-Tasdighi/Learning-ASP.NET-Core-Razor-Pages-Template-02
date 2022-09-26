using Microsoft.EntityFrameworkCore;

namespace Data;

public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	public DatabaseContext
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		(Microsoft.EntityFrameworkCore.DbContextOptions<DatabaseContext> options) : base(options: options)
	{
		Database.EnsureCreated();
	}

	public Microsoft.EntityFrameworkCore.DbSet<Domain.Role> Roles { get; set; }

	public Microsoft.EntityFrameworkCore.DbSet<Domain.User> Users { get; set; }

	public Microsoft.EntityFrameworkCore.DbSet<Domain.Page> Pages { get; set; }

	public Microsoft.EntityFrameworkCore.DbSet<Domain.MenuItem> MenuItems { get; set; }

	public Microsoft.EntityFrameworkCore.DbSet<Domain.LoginLog> UserLogins { get; set; }

	public Microsoft.EntityFrameworkCore.DbSet<Domain.PageCategory> PageCategories { get; set; }

	protected override void OnConfiguring
		(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating
		(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly
			(assembly: typeof(Configurations.RoleConfiguration).Assembly);
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
