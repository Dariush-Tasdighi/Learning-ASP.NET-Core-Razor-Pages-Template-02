namespace Domain.Models.Menus
{
	public class Menu : Domain.SeedWork.Entity,
		SeedWork.IEntityHasIsActive, SeedWork.IEntityHasIsDeletable, SeedWork.IEntityHasLogicalDelete
	{
		#region Constant(s)
		public const int LinkMaxLength = 500;
		public const byte TitleMaxLength = 50;
		public const byte IconMaxLength = 100;
		#endregion /Constant(s)

		#region Constructor
		public Menu() : base()
		{
			IconPosition = Enumerations.IconPosition.Left;
			Children = new System.Collections.Generic.List<Menu>();
		}
		#endregion /Constructor(s)

		#region Property(ies)
		// **********
		// **********
		// **********
		/// <summary>
		/// والد
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Menu),
			ResourceType = typeof(Resources.DataDictionary))]
		public virtual Menu? Parent { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Menu),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.Guid? ParentId { get; set; }
		// **********
		// **********
		// **********

		// **********
		/// <summary>
		/// عنوان منو
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Title),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? Title { get; set; }
		// **********

		// **********
		/// <summary>
		/// مسیر
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Link),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? Link { get; set; }
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
		/// فعال/غیر فعال بودن منو
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsActive),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsActive { get; set; }
		// **********

		// **********
		/// <summary>
		/// سطح دسترسی منو
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsPublic),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsPublic { get; set; }
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
		/// حذف شده/نشده
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsDeleted),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsDeleted { get; set; }
		// **********

		// **********
		/// <summary>
		/// آیکون
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Icon),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? Icon { get; set; }
		// **********

		// **********
		/// <summary>
		/// جایگاه آیکن نسبت به متن
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IconPosition),
			ResourceType = typeof(Resources.DataDictionary))]
		public Enumerations.IconPosition? IconPosition { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.UpdateDateTime),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.DateTime? UpdateDateTime { get; private set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.SubMenus),
			ResourceType = typeof(Resources.DataDictionary))]
		public virtual System.Collections.Generic.IList<Menu> Children { get; set; }
		// **********
		#endregion Property(ies)

		#region Method(s)
		public void SetUpdateDateTime()
		{
			UpdateDateTime = Domain.SeedWork.Utility.Now;
		}
		#endregion /Method(s)
	}
}
