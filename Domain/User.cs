namespace Domain;

public class User :
	Seedwork.Entity,
	Dtat.Seedwork.Abstractions.IEntityIdIsSetable,
	Dtat.Seedwork.Abstractions.IEntityHasIsActive,
	Dtat.Seedwork.Abstractions.IEntityHasIsSystemic,
	Dtat.Seedwork.Abstractions.IEntityHasIsUndeletable,
	Dtat.Seedwork.Abstractions.IEntityHasUpdateDateTime
{
	#region Static(s)
	public static readonly System.Guid
		SuperUserId = new(g: "CC75D635-EF6D-4E86-907A-BC532CDC3ACC");
	#endregion /Static(s)

	#region Constructor
	public User(string emailAddress) : base()
	{
		UpdateDateTime = InsertDateTime;

		EmailAddress = emailAddress;
		EmailAddressVerificationKey = System.Guid.NewGuid();

		CreatedPages =
			new System.Collections.Generic.List<Page>();

		LoginLogs =
			new System.Collections.Generic.List<LoginLog>();
	}
	#endregion /Constructor

	#region Properties

	#region UpdateDateTime Property
	/// <summary>
	/// تاریخ و زمان ویرایش اطلاعات
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.UpdateDateTime))]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.DateTime UpdateDateTime { get; private set; }
	#endregion /UpdateDateTime Property

	#region LastLoginDateTime Property
	/// <summary>
	/// آخرین زمان ورود به سامانه
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.LastLoginDateTime))]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.DateTime? LastLoginDateTime { get; set; }
	#endregion /LastLoginDateTime Property

	#region RoleId Property
	/// <summary>
	/// نقش کاربر
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Role))]
	public System.Guid? RoleId { get; set; }

	/// <summary>
	/// نقش کاربر
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Role))]
	public virtual Role? Role { get; set; }
	#endregion /RoleId Property

	#region IsActive Property
	/// <summary>
	/// وضعیت
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsActive))]
	public bool IsActive { get; set; }
	#endregion /IsActive Property

	#region IsSystemic Property
	/// <summary>
	/// سیستمی
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsSystemic))]
	public bool IsSystemic { get; set; }
	#endregion /IsSystemic Property

	#region IsProgrammer Property
	/// <summary>
	/// برنامه‌نویس
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsProgrammer))]
	public bool IsProgrammer { get; set; }
	#endregion /IsProgrammer Property

	#region IsUndeletable Property
	/// <summary>
	/// غیر قابل حذف
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsUndeletable))]
	public bool IsUndeletable { get; set; }
	#endregion /IsUndeletable Property

	#region IsProfilePublic Property
	/// <summary>
	/// پروفایل به صورت عمومی قابل روئت خواهد بود
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsProfilePublic))]
	public bool IsProfilePublic { get; set; }
	#endregion /IsProfilePublic Property

	#region IsVisibleInContactUsPage Property
	/// <summary>
	/// امکان نمایش در صفحه تماس با ما
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsVisibleInContactUsPage))]
	public bool IsVisibleInContactUsPage { get; set; }
	#endregion /IsVisibleInContactUsPage Property

	#region IsEmailAddressVerified Property
	/// <summary>
	/// نشانی پست الکترونیکی تایید شده است
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsEmailAddressVerified))]
	public bool IsEmailAddressVerified { get; set; }
	#endregion /IsEmailAddressVerified Property

	#region IsCellPhoneNumberVerified Property
	/// <summary>
	/// شماره تلفن همراه تایید شده است
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsCellPhoneNumberVerified))]
	public bool IsCellPhoneNumberVerified { get; set; }
	#endregion /IsCellPhoneNumberVerified Property

	#region Username Property
	/// <summary>
	/// شناسه کاربری
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Username))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Constants.MaxLength.Username,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string? Username { get; set; }
	#endregion /Username Property

	#region Password Property
	/// <summary>
	/// گذرواژه
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Password))]

	[System.ComponentModel.DataAnnotations.MinLength
		(length: Constants.FixedLength.DatabasePassword,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Constants.FixedLength.DatabasePassword,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string? Password { get; set; }
	#endregion /Password Property

	#region FirstName Property
	/// <summary>
	/// نام
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.FirstName))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Constants.MaxLength.FirstName,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string? FirstName { get; set; }
	#endregion /FirstName Property

	#region LastName Property
	/// <summary>
	/// نام خانوادگی
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.LastName))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Constants.MaxLength.LastName,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string? LastName { get; set; }
	#endregion /LastName Property

	#region TitleInContactUsPage Property
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.TitleInContactUsPage))]
	public string? TitleInContactUsPage { get; set; }
	#endregion /TitleInContactUsPage Property

	#region EmailAddress Property
	/// <summary>
	/// نشانی پست الکترونیکی
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.DisplayNameInContactUsPage))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Constants.MaxLength.Name,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string? DisplayNameInContactUsPage { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.EmailAddress))]

	[System.ComponentModel.DataAnnotations.Required
		(ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Constants.MaxLength.EmailAddress,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

	[System.ComponentModel.DataAnnotations.RegularExpression
		(pattern: Constants.RegularExpression.EmailAddress,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.EmailAddress))]
	public string EmailAddress { get; set; }
	#endregion /EmailAddress Property

	#region EmailAddressVerificationKey Property
	/// <summary>
	/// کد تایید نشانی پست الکترونیکی
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.EmailAddressVerificationKey))]
	public System.Guid EmailAddressVerificationKey { get; private set; }
	#endregion /EmailAddressVerificationKey Property

	#region CellPhoneNumber Property
	/// <summary>
	/// شماره تلفن همراه
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.CellPhoneNumber))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Constants.FixedLength.CellPhoneNumber,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

	[System.ComponentModel.DataAnnotations.RegularExpression
		(pattern: Constants.RegularExpression.CellPhoneNumber,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.CellPhoneNumber))]
	public string? CellPhoneNumber { get; set; }
	#endregion /CellPhoneNumber Property

	#region CellPhoneNumberVerificationKey Property
	/// <summary>
	/// کد تایید شماره تلفن همراه
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.CellPhoneNumberVerificationKey))]

	[System.ComponentModel.DataAnnotations.MinLength
		(length: Constants.MinLength.CellPhoneNumberVerificationKey,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MinLength))]

	[System.ComponentModel.DataAnnotations.MaxLength
		(length: Constants.MaxLength.CellPhoneNumberVerificationKey,
		ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
	public string? CellPhoneNumberVerificationKey { get; private set; }
	#endregion /CellPhoneNumberVerificationKey Property

	#region Description Property
	/// <summary>
	/// توضیحات
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Description))]
	public string? Description { get; set; }
	#endregion /Description Property

	#region AdminDescription Property
	/// <summary>
	/// توضیحات مدیریتی
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.AdminDescription))]
	public string? AdminDescription { get; set; }
	#endregion /AdminDescription Property

	#endregion /Properties

	#region Methods

	#region SetUpdateDateTime Method
	public void SetUpdateDateTime()
	{
		UpdateDateTime =
			Dtat.Utility.Now;
	}
	#endregion /SetUpdateDateTime Method

	#region SetId Method
	public void SetId(System.Guid id)
	{
		Id = id;
	}
	#endregion SetId Method

	#endregion /Methods

	#region Collections

	#region CreatedPages
	/// <summary>
	/// صفحات ایجاد کرده
	/// </summary>
	public virtual System.Collections.Generic.IList<Page> CreatedPages { get; private set; }
	#endregion /CreatedPages

	#region LoginLogs
	/// <summary>
	/// ورودهای موفق کاربر
	/// </summary>
	public virtual System.Collections.Generic.IList<LoginLog> LoginLogs { get; private set; }
	#endregion /LoginLogs

	#endregion /Collections
}
