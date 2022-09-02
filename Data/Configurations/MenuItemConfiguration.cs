using Microsoft.EntityFrameworkCore;

namespace Data.Configurations
{
	internal class MenuItemConfiguration :
		object, Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.MenuItem>
	{
		public MenuItemConfiguration() : base()
		{
		}

		public void Configure
			(Microsoft.EntityFrameworkCore.Metadata
			.Builders.EntityTypeBuilder<Domain.MenuItem> builder)
		{
			// **************************************************
			builder
				.Property(current => current.Title)
				.HasMaxLength(maxLength: Constants.MaxLength.Title)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Icon)
				.HasMaxLength(maxLength: Domain.MenuItem.IconMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: false)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Link)
				.HasMaxLength(maxLength: Domain.MenuItem.LinkMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.HasOne(current => current.Parent)
				.WithMany(other => other.SubMenus)
				.HasForeignKey(current => current.ParentId)
				.IsRequired(required: false)
				.OnDelete(deleteBehavior: Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
				;
			// **************************************************

			// **************************************************
			builder
				.HasIndex(current => new { current.Ordering })
				.IsClustered(clustered: false)
				.IsUnique(unique: false)
				;
			// **************************************************

			// **************************************************
			builder
				.HasIndex(current => new { current.ParentId, current.Title })
				//.HasDatabaseName(name: $"IX_{ nameof(Domain.MenuItem.ParentId) }_{ nameof(Domain.MenuItem.Title) }")
				.IsUnique(unique: true)
				;
			// **************************************************
		}
	}
}
