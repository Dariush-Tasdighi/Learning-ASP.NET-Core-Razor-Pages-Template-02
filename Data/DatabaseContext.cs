using Microsoft.EntityFrameworkCore;

namespace Data;

public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
{
	public DatabaseContext
		(Microsoft.EntityFrameworkCore.DbContextOptions<DatabaseContext> options) : base(options: options)
	{
		Database.EnsureCreated();
	}

	public Microsoft.EntityFrameworkCore.DbSet<Domain.Role> Roles => Set<Domain.Role>();

	public Microsoft.EntityFrameworkCore.DbSet<Domain.User> Users => Set<Domain.User>();

	public Microsoft.EntityFrameworkCore.DbSet<Domain.Page> Pages => Set<Domain.Page>();

	public Microsoft.EntityFrameworkCore.DbSet<Domain.LoginLog> LoginLogs => Set<Domain.LoginLog>();

	public Microsoft.EntityFrameworkCore.DbSet<Domain.MenuItem> MenuItems => Set<Domain.MenuItem>();

	public Microsoft.EntityFrameworkCore.DbSet<Domain.Permission> Permissions => Set<Domain.Permission>();

	public Microsoft.EntityFrameworkCore.DbSet<Domain.PageCategory> PageCategories => Set<Domain.PageCategory>();

	public Microsoft.EntityFrameworkCore.DbSet<Domain.ApplicationHandler> ApplicationHandlers => Set<Domain.ApplicationHandler>();

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
