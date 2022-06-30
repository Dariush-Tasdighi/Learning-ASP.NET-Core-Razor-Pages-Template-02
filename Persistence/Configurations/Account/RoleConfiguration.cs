namespace Persistence.Configurations.Account
{
	public class RoleConfiguration :
		object, Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Models.Account.Role>
	{
		public RoleConfiguration() : base()
		{
		}

		public void Configure
			(Microsoft.EntityFrameworkCore.Metadata
			.Builders.EntityTypeBuilder<Domain.Models.Account.Role> builder)
		{
			// **************************************************
			builder
				.Property(current => current.Name)
				.HasMaxLength(maxLength: Domain.Models.Account.Role.NameMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Description)
				.HasMaxLength(maxLength: Domain.Models.Account.Role.DescriptionMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder.HasMany(current => current.Users)
				.WithOne(other => other.Role)
				.HasForeignKey(other => other.RoleId)
				.OnDelete(deleteBehavior: Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
				;
			// **************************************************

			// **************************************************
			builder
				.HasIndex(user => new { user.Name })
				.IsUnique(unique: true)
				;
			// **************************************************
		}
	}
}
