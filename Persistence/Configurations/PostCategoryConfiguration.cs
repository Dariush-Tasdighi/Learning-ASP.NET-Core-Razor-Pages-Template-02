using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
	internal class PostCategoryConfiguration :
		Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Models.PostCategory>
	{
		public PostCategoryConfiguration() : base()
		{
		}


		public void Configure
			(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Models.PostCategory> builder)
		{
			// **************************************************
			builder
				.Property(current => current.Title)
				.HasMaxLength(Domain.Models.PostCategory.TitleMaxLength)
				.IsRequired()
				.IsUnicode(true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Description)
				.HasMaxLength(Domain.Models.PostCategory.DescriptionMaxLength)
				.IsRequired(false)
				.IsUnicode(true)
				;
			// **************************************************

			// **************************************************
			builder
				.HasMany(current => current.SubCategories)
				.WithOne(other => other.Parent)
				.HasForeignKey(other => other.ParentId)
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

			//**************************************************
			builder
				.HasIndex(current => new { current.ParentId, current.Title })
				//.HasDatabaseName(name: $"IX_{ nameof(Domain.Models.PostCategory.ParentId) }_{ nameof(Domain.Models.PostCategory.Title) }")
				.IsUnique(unique: true)
				;
			//**************************************************
		}
	}
}
