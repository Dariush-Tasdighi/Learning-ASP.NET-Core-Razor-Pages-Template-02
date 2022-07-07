namespace Domain.Models.Users
{
	public class Role : SeedWork.Entity, SeedWork.IEntityHasIsActive, SeedWork.IEntityHasIsDeletable,
		SeedWork.IEntityHasUpdateDateTime, SeedWork.IEntityHasIsSystemic, SeedWork.IEntityHasLogicalDelete
	{
		#region Constant(s)
		public const byte NameMaxLength = 50;

		public const byte DescriptionMaxLength = 100;
		#endregion /Constant(s)

		#region Constructor(s)
		public Role() : base()
		{
			//Ordering = 10000;
			IsDeletable = true;
			Users = new System.Collections.Generic.List<User>();
		}
		#endregion /Constructor(s)

		#region Property(ies)
		// **********
		/// <summary>
		/// نام
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Name),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? Name { get; set; }
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
		/// فعال/غیر فعال بودن
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsActive),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsActive { get; set; }
		// **********

		// **********
		/// <summary>
		/// (حذف (منطقی
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsDeleted),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsDeleted { get; set; }
		// **********

		// **********
		/// <summary>
		/// ترتیب نمایش
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Ordering),
			ResourceType = typeof(Resources.DataDictionary))]
		public int Ordering { get; set; }
		// **********

		// **********
		/// <summary>
		/// قابل حذف بودن/نبودن
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsDeletable),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsDeletable { get; set; }
		// **********

		// **********
		/// <summary>
		/// سیستمی بودن/نبودن
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsSystemic),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsSystemic { get; set; }
		// **********

		// **********
		/// <summary>
		/// آخرین زمان بروزرسانی
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.UpdateDateTime),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.DateTime? UpdateDateTime { get; private set; }
		// **********

		// **********
		/// <summary>
		/// کاربران دارای این نقش
		/// </summary>
		public virtual System.Collections.Generic.IList<User> Users { get; set; }
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
