namespace Data.Configurations;

internal class ApplicationHandlerConfiguration : object,
	Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.ApplicationHandler>
{
	public void Configure(Microsoft.EntityFrameworkCore.Metadata
		.Builders.EntityTypeBuilder<Domain.ApplicationHandler> builder)
	{

		// **************************************************
		builder
			.Property(current => current.Name)
			.HasMaxLength(maxLength: Constants.MaxLength.Name)
			.IsRequired(required: true)
			.IsUnicode(unicode: false)
			;
		// **************************************************

		// **************************************************
		builder
			.Property(current => current.Path)
			.HasMaxLength(maxLength: Constants.MaxLength.Path)
			.IsRequired(required: true)
			.IsUnicode(unicode: false)
			;
		// **************************************************

		// **************************************************
		// **************************************************
		// **************************************************
		builder
			.HasIndex(current => new { current.Name, current.Path })
			.IsUnique(unique: true)
			;
		// **************************************************
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************
		// **************************************************
		builder
			.HasIndex(current => new { current.Name, current.Path })
			.IsUnique(unique: true)
			;
		// **************************************************
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************
		// **************************************************
		builder
			.HasMany(current => current.Permissions)
			.WithOne(other => other.ApplicationHandler)
			.IsRequired(required: false)
			.HasForeignKey(other => other.ApplicationHandlerId)
			.OnDelete(deleteBehavior:
				Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
			;
		// **************************************************
		// **************************************************
		// **************************************************
	}
}
