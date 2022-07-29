using Microsoft.EntityFrameworkCore;

namespace Data.Configurations
{
	internal class PostCategoryConfiguration :
		object, Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.PostCategory>
	{
		public PostCategoryConfiguration() : base()
		{
		}


		public void Configure
			(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.PostCategory> builder)
		{
			// **************************************************
			builder
				.Property(current => current.Title)
				.HasMaxLength(Domain.SeedWork.Constant.MaxLength.Title)
				.IsRequired()
				.IsUnicode(true)
				;
			// **************************************************


			// **************************************************
			builder
				.HasMany(current => current.SubCategories)
				.WithOne(other => other.Parent)
				.IsRequired(required: false)
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
				//.HasDatabaseName(name: $"IX_{ nameof(Domain.PostCategory.ParentId) }_{ nameof(Domain.PostCategory.Title) }")
				.IsUnique(unique: true)
				;
			//**************************************************
		}
	}
}
