using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
	public class MenuItemConfiguration :
		object, Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Models.MenuItem>
	{
		public MenuItemConfiguration() : base()
		{
		}

		public void Configure
			(Microsoft.EntityFrameworkCore.Metadata
			.Builders.EntityTypeBuilder<Domain.Models.MenuItem> builder)
		{
			// **************************************************
			builder
				.Property(current => current.Title)
				.HasMaxLength(maxLength: Domain.Models.MenuItem.TitleMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Icon)
				.HasMaxLength(maxLength: Domain.Models.MenuItem.IconMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: false)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Link)
				.HasMaxLength(maxLength: Domain.Models.MenuItem.LinkMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.HasOne(current => current.Parent)
				.WithMany(other => other.SubMenus)
				.HasForeignKey(current => current.ParentId)
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
				.HasDatabaseName(name: $"IX_{ nameof(Domain.Models.MenuItem.ParentId) }_{ nameof(Domain.Models.MenuItem.Title) }")
				.IsUnique(unique: true)
				;
			// **************************************************
		}
	}
}
