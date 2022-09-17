namespace Data.Configurations;

internal class PermissionConfiguration : object,
	Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Permission>
{
	public PermissionConfiguration() : base()
	{
	}

	public void Configure(Microsoft.EntityFrameworkCore
		.Metadata.Builders.EntityTypeBuilder<Domain.Permission> builder)
	{
		// **************************************************
		// **************************************************
		// **************************************************
		builder
			.HasIndex(current => new { current.RoleId, current.ApplicationHandlerId })
			.IsUnique(unique: true)
			;
		// **************************************************
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************
		// **************************************************
		builder
			.HasOne(current => current.Role)
			.WithMany(other => other.Permissions)
			.HasForeignKey(current => current.RoleId)
			.OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
			;
		// **************************************************
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************
		// **************************************************
		builder
			.HasOne(current => current.ApplicationHandler)
			.WithMany(other => other.Permissions)
			.HasForeignKey(current => current.ApplicationHandlerId)
			.OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
			;
		// **************************************************
		// **************************************************
		// **************************************************
	}
}
