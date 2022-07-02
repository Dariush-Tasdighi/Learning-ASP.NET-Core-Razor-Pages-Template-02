namespace Domain.Models.Account
{
	public class User : SeedWork.Entity,
		SeedWork.IEntityHasIsActive, SeedWork.IEntityHasUpdateDateTime
	{
		public User() : base()
		{
			IsActive = false;
			IsVerified = false;
			// است false ها Boolean مقدار پیش فرض
			// مقداردهی این دو متغیر در "سازنده ی پیش فرض کلاس"، صرفا برای تاکید بیشتر
			// بر "غیر فعال" بودن و "تایید" نشدن کاربر در زمان درخواست "ثبت نام" است
		}

		// **********
		// **********
		// **********
		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Role),
			ResourceType = typeof(Resources.DataDictionary))]
		public virtual Role? Role { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Role),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.Guid? RoleId { get; set; }
		// **********
		// **********
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Username),
			ResourceType = typeof(Resources.DataDictionary))]

		//[System.ComponentModel.DataAnnotations.Required
		//	(AllowEmptyStrings = false,
		//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

		//[System.ComponentModel.DataAnnotations.MaxLength
		//	(length: Domain.SeedWork.Constant.MaxLength.Username,
		//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

		[System.ComponentModel.DataAnnotations.RegularExpression
			(pattern: Domain.SeedWork.Constant.RegularExpression.Username,
			ErrorMessageResourceType = typeof(Resources.Messages.Validations),
			ErrorMessageResourceName = nameof(Resources.Messages.Validations.Username))]
		public string? Username { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Password),
			ResourceType = typeof(Resources.DataDictionary))]

		//[System.ComponentModel.DataAnnotations.Required
		//	(AllowEmptyStrings = false,
		//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

		//[System.ComponentModel.DataAnnotations.MaxLength
		//	(length: Domain.SeedWork.Constant.MaxLength.Password,
		//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

		[System.ComponentModel.DataAnnotations.RegularExpression
			(pattern: Domain.SeedWork.Constant.RegularExpression.Password,
			ErrorMessageResourceType = typeof(Resources.Messages.Validations),
			ErrorMessageResourceName = nameof(Resources.Messages.Validations.Password))]

		[System.ComponentModel.DataAnnotations.DataType
			(dataType: System.ComponentModel.DataAnnotations.DataType.Password)]
		public string? Password { get; set; }
		// **********

		// **********
		public Enumerations.Gender Gender { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.FirstName),
			ResourceType = typeof(Resources.DataDictionary))]

		//[System.ComponentModel.DataAnnotations.MaxLength
		//	(length: Domain.SeedWork.Constant.MaxLength.FirstName,
		//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
		public string? FirstName { get; set; }
		// **********

		// **********
		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.LastName),
			ResourceType = typeof(Resources.DataDictionary))]

		//[System.ComponentModel.DataAnnotations.MaxLength
		//	(length: Domain.SeedWork.Constant.MaxLength.LastName,
		//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
		public string? LastName { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.BirthDate),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.DateTime? BirthDate { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.NationalCode),
			ResourceType = typeof(Resources.DataDictionary))]

		//[System.ComponentModel.DataAnnotations.MaxLength
		//	(length: Domain.SeedWork.Constant.MaxLength.NationalCode,
		//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
		public string? NationalCode { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.EmailAddress),
			ResourceType = typeof(Resources.DataDictionary))]

		//[System.ComponentModel.DataAnnotations.Required
		//	(AllowEmptyStrings = false,
		//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

		//[System.ComponentModel.DataAnnotations.MaxLength
		//	(length: Domain.SeedWork.Constant.MaxLength.EmailAddress,
		//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

		[System.ComponentModel.DataAnnotations.RegularExpression
			(pattern: Domain.SeedWork.Constant.RegularExpression.EmailAddress,
			ErrorMessageResourceType = typeof(Resources.Messages.Validations),
			ErrorMessageResourceName = nameof(Resources.Messages.Validations.EmailAddress))]
		public string? EmailAddress { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsEmailAddressVerified),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool? IsEmailAddressVerified { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.CellPhoneNumber),
			ResourceType = typeof(Resources.DataDictionary))]

		//[System.ComponentModel.DataAnnotations.MaxLength
		//	(length: Domain.SeedWork.Constant.MaxLength.CellPhoneNumber,
		//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

		[System.ComponentModel.DataAnnotations.RegularExpression
			(pattern: Domain.SeedWork.Constant.RegularExpression.CellPhoneNumber,
			ErrorMessageResourceType = typeof(Resources.Messages.Validations),
			ErrorMessageResourceName = nameof(Resources.Messages.Validations.CellPhoneNumber))]
		public string? CellPhoneNumber { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsCellPhoneNumberVerified),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool? IsCellPhoneNumberVerified { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Description),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? Description { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.EmailAddressVerificationKey),
			ResourceType = typeof(Resources.DataDictionary))]

		//[System.ComponentModel.DataAnnotations.MaxLength
		//	(length: Domain.SeedWork.Constant.MaxLength.EmailAddressVerificationKey,
		//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
		public string? EmailAddressVerificationKey { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.EmailAddressVerificationKeyExpireDateTime),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.DateTime? EmailAddressVerificationKeyExpireDateTime { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.CellPhoneNumberVerificationKey),
			ResourceType = typeof(Resources.DataDictionary))]

		//[System.ComponentModel.DataAnnotations.MaxLength
		//	(length: Domain.SeedWork.Constant.MaxLength.CellPhoneNumberVerificationKey,
		//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
		public string? CellPhoneNumberVerificationKey { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.CellPhoneNumberVerificationKeyExpireDateTime),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.DateTime? CellPhoneNumberVerificationKeyExpireDateTime { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsActive),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsActive { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsVerified),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsVerified { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsDeleted),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsDeleted { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.VerifyDateTime),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.DateTime? VerifyDateTime { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.UpdateDateTime),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.DateTime? UpdateDateTime { get; private set; }
		// **********

		public void SetUpdateDateTime()
		{
			UpdateDateTime = SeedWork.Utility.Now;
		}
	}
}
