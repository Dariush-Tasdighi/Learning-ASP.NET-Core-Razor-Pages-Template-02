namespace Domain.Models
{
	public class User : SeedWork.Entity,
		SeedWork.IEntityHasIsActive, SeedWork.IEntityHasUpdateDateTime, SeedWork.IEntityHasLogicalDelete//, SeedWork.IEntityHasIsDeletable
	{
		#region Constructor(s)
		public User(string username) : base()
		{
			Username = username;

			//Ordering = SeedWork.Constant.Default.Ordering;
		}
		#endregion /Constructor(s)

		#region Property(ies)
		// **********
		// **********
		// **********
		// **********
		/// <summary>
		/// نقش
		/// </summary>
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
		/// <summary>
		/// نام کاربری
		/// </summary>
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
		/// <summary>
		/// گذرواژه
		/// </summary>
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
		/// <summary>
		/// جنسیت
		/// </summary>
		public Enumerations.Gender Gender { get; set; }
		// **********

		// **********
		/// <summary>
		/// نام
		/// </summary>
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
		/// <summary>
		/// نام خانوادگی
		/// </summary>
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
		/// <summary>
		/// تاریخ تولد
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.BirthDate),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.DateOnly? BirthDate { get; set; }
		//public System.DateTime? BirthDate { get; set; }
		// **********

		// **********
		/// <summary>
		/// کد ملی
		/// </summary>
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
		/// <summary>
		/// آدرس پست الکترونیک
		/// </summary>
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
		/// <summary>
		/// وضعیت (مورد تایید بودن/نبودن) آدرس پست الکترونیکی
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsEmailAddressVerified),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool? IsEmailAddressVerified { get; set; }
		// **********

		// **********
		/// <summary>
		/// شماره تلفن همراه
		/// </summary>
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
		/// <summary>
		/// وضعیت (مورد تایید بودن/نبودن) شماره تلفن همراه
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsCellPhoneNumberVerified),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool? IsCellPhoneNumberVerified { get; set; }
		// **********

		// **********
		/// <summary>
		/// توضیحات
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Description),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? Description { get; set; }
		// **********

		// **********
		/// <summary>
		/// کد تایید ارسال شده به آدرس پست الکترونیکی
		/// </summary>
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
		/// <summary>
		/// تاریخ-زمان انقضا کد تایید ارسال شده به آدرس پست الکترونیکی
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.EmailAddressVerificationKeyExpireDateTime),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.DateTime? EmailAddressVerificationKeyExpireDateTime { get; set; }
		// **********

		// **********
		/// <summary>
		/// کد تایید ارسال شده به شماره تلفن همراه
		/// </summary>
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
		/// <summary>
		/// تاریخ-زمان انقضا کد تایید ارسال شده به شماره تلفن همراه
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.CellPhoneNumberVerificationKeyExpireDateTime),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.DateTime? CellPhoneNumberVerificationKeyExpireDateTime { get; set; }
		// **********

		// **********
		/// <summary>
		/// وضعیت (فعال/غیر فعال بودن) کاربر
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsActive),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsActive { get; set; }
		// **********

		// **********
		/// <summary>
		/// کاربر تایید شده است
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsVerified),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsVerified { get; set; }
		// **********

		// **********
		/// <summary>
		/// کاربر حذف شده است
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsDeleted),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsDeleted { get; set; }
		// **********

		// **********
		/// <summary>
		/// تاریخ-زمان تایید کاربر
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.VerifyDateTime),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.DateTime? VerifyDateTime { get; set; }
		// **********

		// **********
		/// <summary>
		/// تاریخ-زمان آخرین بروزرسانی
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.UpdateDateTime),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.DateTime? UpdateDateTime { get; private set; }
		// **********

		// **********
		///// <summary>
		///// ترتیب نمایش
		///// </summary>
		//[System.ComponentModel.DataAnnotations.Display
		//	(Name = nameof(Resources.DataDictionary.Ordering),
		//	ResourceType = typeof(Resources.DataDictionary))]
		//public uint Ordering { get; set; }
		// **********
		#endregion /Property(ies)

		#region Method(s)
		public void SetUpdateDateTime()
		{
			UpdateDateTime = SeedWork.Utility.Now;
		}
		#endregion /Method(s)
	}
}
