using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
	internal class UserConfiguration :
		object, Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.Models.User>
	{
		public UserConfiguration() : base()
		{
		}

		public void Configure
			(Microsoft.EntityFrameworkCore.Metadata
			.Builders.EntityTypeBuilder<Domain.Models.User> builder)
		{
			// **************************************************
			builder
				.Property(current => current.Username)
				.HasMaxLength(maxLength: Domain.SeedWork.Constant.MaxLength.Username)
				.IsRequired(required: true)
				.IsUnicode(unicode: false)
				;

			builder
				.Property(current => current.Password)
				.HasMaxLength(maxLength: Domain.SeedWork.Constant.MaxLength.PasswordInDatabase)
				.IsRequired(required: false)
				.IsUnicode(unicode: false)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.FirstName)
				.HasMaxLength(maxLength: Domain.SeedWork.Constant.MaxLength.FirstName)
				.IsRequired(required: false)
				.IsUnicode(unicode: true)
				;

			builder
				.Property(current => current.LastName)
				.HasMaxLength(maxLength: Domain.SeedWork.Constant.MaxLength.LastName)
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
				.HasMaxLength(maxLength: Domain.SeedWork.Constant.MaxLength.EmailAddress)
				.IsRequired(required: false)
				.IsUnicode(unicode: false)
				;

			builder
				.Property(current => current.EmailAddressVerificationKey)
				.HasMaxLength(maxLength: Domain.SeedWork.Constant.MaxLength.EmailAddressVerificationKey)
				.IsUnicode(unicode: false)
				.IsRequired(required: false)
				//.IsFixedLength(fixedLength: true)
				;
			// **************************************************


			// **************************************************
			builder
				.Property(current => current.CellPhoneNumber)
				.HasMaxLength(maxLength: Domain.SeedWork.Constant.MaxLength.CellPhoneNumber)
				.IsRequired(required: false)
				.IsUnicode(unicode: false)
				;

			builder
				.Property(current => current.CellPhoneNumberVerificationKey)
				.HasMaxLength(maxLength: Domain.SeedWork.Constant.MaxLength.CellPhoneNumberVerificationKey)
				.IsUnicode(unicode: false)
				.IsRequired(required: false)
				//.IsFixedLength(fixedLength: true)
				;
			// **************************************************


			// **************************************************
			builder
				.HasIndex(user => new { user.Username })
				.IsUnique(unique: true)
				;
			// **************************************************

			// **************************************************
			// true با IsUnique در صورت برابر بودن مقدار
			// در صورت مقدار ندادن به هر یک از این دو فیلد، برای دو کاربر در زمان ثبت یا ویرایش با خطا مواجه خواهیم شد
			// **************************************************
			//builder
			//	.HasIndex(user => new { user.CellPhoneNumber })
			//	.IsUnique(unique: false)
			//	;

			//builder
			//	.HasIndex(user => new { user.EmailAddress })
			//	.IsUnique(unique: false)
			//	;
			// **************************************************
		}
	}
}
