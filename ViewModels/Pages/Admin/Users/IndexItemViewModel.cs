namespace ViewModels.Pages.Admin.Users;

public class IndexItemViewModel : object
{
	#region Constructor
	public IndexItemViewModel() : base()
	{
		EmailAddress = string.Empty;
	}
	#endregion /Constructor

	#region Properties

	#region Id Property
	/// <summary>
	/// شناسه
	/// </summary>
	public System.Guid Id { get; set; }
	#endregion /Id Property

	#region InsertDateTime Property
	/// <summary>
	/// تاریخ و ساعت ایجاد
	/// </summary>
	public System.DateTime InsertDateTime { get; set; }
	#endregion /InsertDateTime Property

	#region UpdateDateTime Property
	/// <summary>
	/// تاریخ و زمان ویرایش اطلاعات
	/// </summary>
	public System.DateTime UpdateDateTime { get; set; }
	#endregion /UpdateDateTime Property

	#region LastLoginDateTime Property
	/// <summary>
	/// آخرین زمان ورود به سامانه
	/// </summary>
	public System.DateTime? LastLoginDateTime { get; set; }
	#endregion /LastLoginDateTime Property

	#region RoleId Property
	/// <summary>
	/// نقش کاربر
	/// </summary>
	public System.Guid? RoleId { get; set; }
	#endregion /RoleId Property

	#region RoleName Property
	/// <summary>
	/// نام نقش کاربر
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Role))]
	public string? RoleName { get; set; }
	#endregion /RoleName Property

	#region IsRoleActive Property
	/// <summary>
	/// نقش انتخاب شده فعال است
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsActive))]
	public bool? IsRoleActive { get; init; }
	#endregion /IsRoleActive Property

	#region IsActive Property
	/// <summary>
	/// وضعیت
	/// </summary>
	public bool IsActive { get; set; }
	#endregion /IsActive Property

	#region IsProgrammer Property
	/// <summary>
	/// برنامه‌نویس
	/// </summary>
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

	#region IsVisibleInContactUsPage Property
	/// <summary>
	/// امکان نمایش در صفحه تماس با ما
	/// </summary>
	public bool IsVisibleInContactUsPage { get; set; }
	#endregion /IsVisibleInContactUsPage Property

	#region IsEmailAddressVerified Property
	/// <summary>
	/// نشانی پست الکترونیکی تایید شده است
	/// </summary>
	public bool IsEmailAddressVerified { get; set; }
	#endregion /IsEmailAddressVerified Property

	#region IsCellPhoneNumberVerified Property
	/// <summary>
	/// شماره تلفن همراه تایید شده است
	/// </summary>
	public bool IsCellPhoneNumberVerified { get; set; }
	#endregion /IsCellPhoneNumberVerified Property

	#region Username Property
	/// <summary>
	/// شناسه کاربری
	/// </summary>
	public string? Username { get; set; }
	#endregion /Username Property

	#region FirstName Property
	/// <summary>
	/// نام
	/// </summary>
	public string? FirstName { get; set; }
	#endregion /FirstName Property

	#region LastName Property
	/// <summary>
	/// نام خانوادگی
	/// </summary>
	public string? LastName { get; set; }
	#endregion /LastName Property

	#region EmailAddress Property
	/// <summary>
	/// نشانی پست الکترونیکی
	/// </summary>
	public string EmailAddress { get; set; }
	#endregion /EmailAddress Property

	#region CellPhoneNumber Property
	/// <summary>
	/// شماره تلفن همراه
	/// </summary>
	public string? CellPhoneNumber { get; set; }
	#endregion /CellPhoneNumber Property

	#endregion /Properties
}
