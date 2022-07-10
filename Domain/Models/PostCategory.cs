namespace Domain.Models
{
	public class PostCategory : SeedWork.Entity,
		SeedWork.IEntityHasOrdering, SeedWork.IEntityHasIsActive,
		SeedWork.IEntityHasIsDeletable, SeedWork.IEntityHasLogicalDelete
	{
		#region Constant(s)
		public const byte TitleMaxLength = 25;

		public const byte DescriptionMaxLength = 100;
		#endregion /Constant(s)

		#region Constructor
		public PostCategory() : base()
		{
			//Posts =
			//	new System.Collections.Generic.List<Posts>();

			SubCategories =
				new System.Collections.Generic.List<PostCategory>();
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
			(Name = nameof(Resources.DataDictionary.Parent),
			ResourceType = typeof(Resources.DataDictionary))]
		public virtual PostCategory? Parent { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Parent),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.Guid? ParentId { get; set; }
		// **********
		// **********
		// **********

		// **********
		/// <summary>
		/// عنوان
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Title))]
		public string? Title { get; set; }
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
		/// توضیحات
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Description))]
		public string? Description { get; set; }
		// **********

		// **********
		/// <summary>
		/// اولویت بندی دسته بندی
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Ordering))]
		public uint Ordering { get; set; }
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
		public virtual System.Collections.Generic.IList<PostCategory> SubCategories { get; set; }
		// **********

		// **********
		//public virtual System.Collections.Generic.IList<Post> Posts { get; set; }
		// **********
		#endregion /Property(ies)
	}
}
