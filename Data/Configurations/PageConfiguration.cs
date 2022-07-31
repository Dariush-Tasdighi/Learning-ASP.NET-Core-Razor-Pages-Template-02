using Microsoft.EntityFrameworkCore;

namespace Data.Configurations
{
	internal class PageConfiguration :
		object, Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Page>
	{
		public PageConfiguration() : base()
		{
		}

		public void Configure
			(Microsoft.EntityFrameworkCore.Metadata
			.Builders.EntityTypeBuilder<Domain.Page> builder)
		{
			// **************************************************
			builder
				.Property(current => current.Title)
				.HasMaxLength(maxLength: Domain.Page.TitleMaxLength)
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
				.HasMaxLength(maxLength: Domain.Page.AuthorMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Description)
				.HasMaxLength(maxLength: Domain.Page.DescriptionMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Category)
				.HasMaxLength(maxLength: Domain.Page.CategoryMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Copyright)
				.HasMaxLength(maxLength: Domain.Page.CopyrightMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Classification)
				.HasMaxLength(maxLength: Domain.Page.ClassificationMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Introduction)
				.HasMaxLength(maxLength: Domain.Page.IntroductionMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.ImageUrl)
				.HasMaxLength(maxLength: Domain.Page.ImageUrlMaxLength)
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
