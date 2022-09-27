namespace ViewModels.Pages.Admin.Users;

public class DetailsOrDeleteViewModel : UpdateViewModel
{
	#region Constructor
	public DetailsOrDeleteViewModel() : base()
	{
	}
	#endregion /Constructor

	#region Properties

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

	#region IsSystemic Property
	/// <summary>
	/// سیستمی
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsSystemic))]
	public bool IsSystemic { get; set; }
	#endregion /IsSystemic Property

	#region IsUndeletable Property
	/// <summary>
	/// غیر قابل حذف
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.IsUndeletable))]
	public bool IsUndeletable { get; set; }
	#endregion /IsUndeletable Property

	#region InsertDateTime Property
	/// <summary>
	/// تاریخ و ساعت ایجاد
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.InsertDateTime))]
	public System.DateTime InsertDateTime { get; set; }
	#endregion /InsertDateTime Property

	#region UpdateDateTime Property
	/// <summary>
	/// تاریخ و زمان ویرایش اطلاعات
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.UpdateDateTime))]
	public System.DateTime UpdateDateTime { get; set; }
	#endregion /UpdateDateTime Property

	#region LastLoginDateTime Property
	/// <summary>
	/// آخرین زمان ورود به سامانه
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.LastLoginDateTime))]
	public System.DateTime? LastLoginDateTime { get; set; }
	#endregion /LastLoginDateTime Property

	#endregion /Properties
}
