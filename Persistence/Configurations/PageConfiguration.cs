using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
	public class PageConfiguration :
		object, Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Page>
	{
		public PageConfiguration() : base()
		{
		}

		public void Configure
			(Microsoft.EntityFrameworkCore.Metadata
			.Builders.EntityTypeBuilder<Page> builder)
		{
			// **************************************************
			builder
				.Property(current => current.Title)
				.HasMaxLength(maxLength: Page.TitleMaxLength)
				.IsRequired(required: true)
				.IsUnicode(unicode: true)
				;

			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Password)
				.HasMaxLength(maxLength: Domain.SeedWork.Constant.MaxLength.Password)
				.IsRequired(required: true)
				.IsUnicode(unicode: false)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Author)
				.HasMaxLength(maxLength: Page.AuthorMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Description)
				.HasMaxLength(maxLength: Page.DescriptionMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Category)
				.HasMaxLength(maxLength: Page.CategoryMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Copyright)
				.HasMaxLength(maxLength: Page.CopyrightMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Classification)
				.HasMaxLength(maxLength: Page.ClassificationMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Introduction)
				.HasMaxLength(maxLength: Page.IntroductionMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.ImageUrl)
				.HasMaxLength(maxLength: Page.ImageUrlMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.HasIndex(current => new { current.Ordering })
				.IsClustered(clustered: false)
				.IsUnique(unique: false)
				;
			// **************************************************
		}
	}
}
