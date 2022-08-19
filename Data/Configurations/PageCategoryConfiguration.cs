namespace Data.Configurations
{
	internal class PageCategoryConfiguration : object,
		Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.PageCategory>
	{
		public PageCategoryConfiguration() : base()
		{
		}

		public void Configure
			(Microsoft.EntityFrameworkCore.Metadata.Builders
			.EntityTypeBuilder<Domain.PageCategory> builder)
		{
			// **************************************************
			// **************************************************
			// **************************************************
			builder
				.HasIndex(current => new { current.Name })
				.IsUnique(unique: true)
				;
			// **************************************************
			// **************************************************
			// **************************************************

			// **************************************************
			// **************************************************
			// **************************************************
			//builder
			//	.HasMany(current => current.Pages)
			//	.WithOne(other => other.PageCategory)
			//	.IsRequired(required: true)
			//	.HasForeignKey(other => other.PageCategoryId)
			//	.OnDelete(deleteBehavior:
			//		Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
			//	;
			// **************************************************
			// **************************************************
			// **************************************************
		}
	}
}
