namespace Persistence.Configurations
{
	internal class UserConfiguration :
		object, Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.User>
	{
		public UserConfiguration() : base()
		{
		}

		public void Configure
			(Microsoft.EntityFrameworkCore.Metadata
			.Builders.EntityTypeBuilder<Domain.User> builder)
		{
			// **************************************************
			builder
				.Property(current => current.EmailAddress)
				.IsUnicode(unicode: false)
				;

			builder
				.HasIndex(current => new { current.EmailAddress })
				//.IsUnique(unique: true)
				.IsUnique(unique: false)
				;
			// **************************************************

			// **************************************************
			builder
				.HasIndex(current => new { current.EmailAddressVerificationKey })
				.IsUnique(unique: true)
				;
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Username)
				.IsUnicode(unicode: false)
				;

			builder
				.HasIndex(current => new { current.Username })
				.IsUnique(unique: false)
				//.IsUnique(unique: true)
				;

			//builder.HasIndex(current => current.Username)
			//	.IsUnique(unique: true)
			//	// HasFilter -> using Microsoft.EntityFrameworkCore;
			//	.HasFilter("[Username] IS NOT NULL");
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.CellPhoneNumber)
				.IsUnicode(unicode: false)
				;

			builder
				.HasIndex(current => new { current.CellPhoneNumber })
				//.IsUnique(unique: true)
				.IsUnique(unique: false)
				;

			//builder.HasIndex(current => current.CellPhoneNumber)
			//	.IsUnique(unique: true)
			//	// HasFilter -> using Microsoft.EntityFrameworkCore;
			//	.HasFilter("[CellPhoneNumber] IS NOT NULL");
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.CellPhoneNumberVerificationKey)
				.IsUnicode(unicode: false)
				;

			builder
				.HasIndex(current => new { current.CellPhoneNumberVerificationKey })
				.IsUnique(unique: true)
				;

			//builder.HasIndex(current => current.CellPhoneNumberVerificationKey)
			//	.IsUnique(unique: true)
			//	// HasFilter -> using Microsoft.EntityFrameworkCore;
			//	.HasFilter("[CellPhoneNumberVerificationKey] IS NOT NULL");
			// **************************************************

			// **************************************************
			builder
				.Property(current => current.Password)
				.IsUnicode(unicode: false)
				;
			// **************************************************

			// **************************************************
			// **************************************************
			// **************************************************
			var user =
				new Domain.User(emailAddress: "DariushT@GMail.com", roleId: Domain.Role.UserRoleId)
				{
					//Id,
					//Role,
					//RoleId,
					//EmailAddress,
					//InsertDateTime,
					//UpdateDateTime,
					//EmailAddressVerificationKey
					//CellPhoneNumberVerificationKey,

					Ordering = 0,

					IsActive = true,
					IsSystemic = true,
					IsUndeletable = true,
					IsProfilePublic = true,
					IsEmailAddressVerified = true,
					IsCellPhoneNumberVerified = true,

					Description = null,
					AdminDescription = null,

					Username = "Dariush",
					FullName = "داریوش تصدیقی",
					CellPhoneNumber = "09121087461",
					Password =
						Dtat.Security.Cryptography.GetSha256(text: "1234512345"),
				};

			user.SetId(id: Domain.User.SuperUserId);

			builder.HasData(data: user);
			// **************************************************
			// **************************************************
			// **************************************************
		}
	}
}
