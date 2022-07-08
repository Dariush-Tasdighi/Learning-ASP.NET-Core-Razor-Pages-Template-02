using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
	public class PageConfiguration :
		object, Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Models.Page>
	{
		public PageConfiguration() : base()
		{
		}

		public void Configure
			(Microsoft.EntityFrameworkCore.Metadata
			.Builders.EntityTypeBuilder<Domain.Models.Page> builder)
		{
			// **************************************************
			builder
				.Property(current => current.Title)
				.HasMaxLength(maxLength: Domain.Models.Page.TitleMaxLength)
				.IsRequired(required: true)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Author)
				.HasMaxLength(maxLength: Domain.Models.Page.AuthorMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Description)
				.HasMaxLength(maxLength: Domain.Models.Page.DescriptionMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Category)
				.HasMaxLength(maxLength: Domain.Models.Page.CategoryMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Copyright)
				.HasMaxLength(maxLength: Domain.Models.Page.CopyrightMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Classification)
				.HasMaxLength(maxLength: Domain.Models.Page.ClassificationMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Introduction)
				.HasMaxLength(maxLength: Domain.Models.Page.IntroductionMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.ImageUrl)
				.HasMaxLength(maxLength: Domain.Models.Page.ImageUrlMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.HasIndex(user => new { user.Ordering })
				.IsClustered(clustered: false)
				.IsUnique(unique: false)
				;
			// **************************************************
		}
	}
}
