namespace Data.Configurations;

internal class UserConfiguration : object,
	Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Domain.User>
{
	public UserConfiguration() : base()
	{
	}

	public void Configure
		(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.User> builder)
	{
		// **************************************************
		// **************************************************
		// **************************************************
		builder
			.Property(current => current.EmailAddress)
			.IsUnicode(unicode: false)
			;

		builder
			.HasIndex(current => new { current.EmailAddress })
			.IsUnique(unique: true)
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
			.IsUnique(unique: true)
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
			.IsUnique(unique: true)
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
		// **************************************************
		// **************************************************
		builder
			.HasMany(current => current.CreatedPages)
			.WithOne(other => other.CreatorUser)
			.IsRequired(required: true)
			.HasForeignKey(other => other.CreatorUserId)
			.OnDelete(deleteBehavior:
				Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade)
			;
		// **************************************************

		// **************************************************
		builder
			.HasMany(current => current.LoginLogs)
			.WithOne(other => other.User)
			.IsRequired(required: true)
			.HasForeignKey(other => other.UserId)
			.OnDelete(deleteBehavior:
				Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade)
			;
		// **************************************************
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************
		// **************************************************
		var user =
			new Domain.User(emailAddress: "DariushT@GMail.com")
			{
				//Id,
				//Role,
				//RoleId,
				//LoginLogs,
				//CreatedPages,
				//EmailAddress,
				//InsertDateTime,
				//UpdateDateTime,
				//EmailAddressVerificationKey
				//CellPhoneNumberVerificationKey,

				Ordering = 1,

				IsActive = true,
				IsSystemic = true,
				IsProgrammer = true,
				IsUndeletable = true,
				IsProfilePublic = true,
				IsEmailAddressVerified = true,
				IsVisibleInContactUsPage = true,
				IsCellPhoneNumberVerified = true,

				Description = null,
				AdminDescription = null,
				LastLoginDateTime = null,

				Username = "Dariush",
				FirstName = "داریوش",
				LastName = "تصدیقی",
				CellPhoneNumber = "09121087461",
				TitleInContactUsPage = "مالک پایگاه",

				Password =
					Dtat.Security.Hashing.GetSha256(text: "1234512345"),
			};

		user.SetId(id: Domain.User.SuperUserId);

		builder.HasData(data: user);
		// **************************************************
		// **************************************************
		// **************************************************
	}
}
