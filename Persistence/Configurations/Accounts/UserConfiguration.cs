namespace Persistence.Configurations
{
	internal class UserConfiguration :
		object, Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Cms.Account.User>
	{
		public UserConfiguration() : base()
		{
		}

		public void Configure
			(Microsoft.EntityFrameworkCore.Metadata
			.Builders.EntityTypeBuilder<Domain.Cms.Account.User> builder)
		{
			// **************************************************
			builder
				.Property(current => current.Username)
				.HasMaxLength(maxLength: Domain.Cms.Account.User.UsernameMaxLength)
				.IsRequired(required: true)
				.IsUnicode(unicode: false)
				;

			builder
				.Property(current => current.Password)
				.HasMaxLength(maxLength: Domain.Cms.Account.User.PasswordLengthInDatabase)
				.IsRequired(required: false)
				.IsUnicode(unicode: false)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.FirstName)
				.HasMaxLength(maxLength: Domain.Cms.Account.User.FirstNameMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;

			builder
				.Property(current => current.LastName)
				.HasMaxLength(maxLength: Domain.Cms.Account.User.LastNameMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Description)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.EmailAddress)
				.HasMaxLength(maxLength: Domain.Cms.Account.User.EmailAddressMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: false)
				;

			builder
				.Property(current => current.EmailAddressVerificationCode)
				.HasMaxLength(maxLength: Domain.Cms.Account.User.EmailAddressVerificationKeyFixLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: false)
				;
			// **************************************************


			// **************************************************
			builder
				.Property(current => current.CellPhoneNumber)
				.HasMaxLength(maxLength: Domain.Cms.Account.User.CellPhoneMaxLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: false)
				;


			builder
				.Property(current => current.CellPhoneVerificationCode)
				.HasMaxLength(maxLength: Domain.Cms.Account.User.CellPhoneVerificationKeyFixLength)
				.IsRequired(required: false)
				.IsUnicode(unicode: false)
				;
			// **************************************************


			// **************************************************
			builder
				.HasIndex(user => new { user.Username })
				.IsUnique(unique: true)
				;
			// **************************************************
		}
	}
}
