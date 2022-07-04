namespace Persistence.Configurations.Menus
{
	public class MenuConfiguration :
		object, Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Models.Menus.Menu>
	{
		public MenuConfiguration() : base()
		{
		}

		public void Configure
			(Microsoft.EntityFrameworkCore.Metadata
			.Builders.EntityTypeBuilder<Domain.Models.Menus.Menu> builder)
		{
			// **************************************************
			builder
				.Property(current => current.Title)
				.HasMaxLength(maxLength: Domain.Models.Menus.Menu.TitleMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Icon)
				.HasMaxLength(maxLength: Domain.Models.Menus.Menu.IconMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: false)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Link)
				.HasMaxLength(maxLength: Domain.Models.Menus.Menu.LinkMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.HasOne(current => current.Parent)
				.WithMany(other => other.Children)
				.HasForeignKey(current => current.ParentId)
				.OnDelete(deleteBehavior: Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
				;
			// **************************************************

			// **************************************************
			//builder
			//	.HasIndex(current => new { current.Title, current.ParentId })
			//	.IsUnique(unique: true)
			//	;
			// **************************************************
		}
	}
}
