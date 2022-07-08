namespace Domain.Models
{
	public class Page : SeedWork.Entity,
		SeedWork.IEntityHasIsActive, SeedWork.IEntityHasIsSystemic,
		SeedWork.IEntityHasIsUpdatable, SeedWork.IEntityHasOrdering,
		SeedWork.IEntityHasIsDeletable, SeedWork.IEntityHasLogicalDelete,
		SeedWork.IEntityHasCreatorUserId, SeedWork.IEntityHasRemoverUserId
	{
		#region Constant(s)
		public const byte TitleMaxLength = 100;
		public const byte DescriptionMaxLength = 100;

		#endregion /Constant(s)

		public Page() : base()
		{
		}

		// **********
		// **********
		// **********
		/// <summary>
		/// طرح زمینه صفحه 
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Layout))]
		public System.Guid LayoutId { get; set; }
		// **********

		// **********
		//[System.ComponentModel.DataAnnotations.Display
		//	(ResourceType = typeof(Resources.DataDictionary),
		//	Name = nameof(Resources.DataDictionary.Layout))]
		//public Layout Layout { get; set; }
		// **********
		// **********
		// **********

		// **********
		/// <summary>
		/// عنوان صفحه
		/// </summary>
		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false,
			ErrorMessageResourceType = typeof(Resources.Messages.Validations),
			ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Title))]
		public string? Title { get; set; }
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
		/// ویژه بودن صفحه
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.IsFeatured))]
		public bool IsFeatured { get; set; }
		// **********

		// **********
		/// <summary>
		/// پیوست داشتن
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.HasAttachment))]
		public bool HasAttachment { get; set; }
		// **********

		// **********
		/// <summary>
		/// تعداد دانلود 
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.DownloadCount))]
		public int DownloadCount { get; set; }
		// **********

		// **********
		/// <summary>
		///  مقدمه
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Introduction))]
		public string? Introduction { get; set; }
		// **********

		// **********
		/// <summary>
		/// فعال بودن اظهار نظر در صفحه
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.IsCommentingEnabled))]
		public bool IsCommentingEnabled { get; set; }
		// **********

		// **********
		/// <summary>
		/// آدرس تصویر
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.ImageUrl))]
		public string? ImageUrl { get; set; }
		// **********

		// **********
		/// <summary>
		/// بدنه
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Body))]
		public string? Body { get; set; }
		// **********

		// **********
		/// <summary>
		///  نمایش کاربر خالق صفحه
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.DisplayCreatorUser))]
		public bool DisplayCreatorUser { get; set; }
		// **********

		// **********
		/// <summary>
		/// آیا موتورهای جستجو آن را فهرست می کنند؟
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.DoesSearchEnginesIndexIt))]
		public bool DoesSearchEnginesIndexIt { get; set; }
		// **********

		// **********
		/// <summary>
		/// آیا موتورهای جستجو از آن پیروی می کنند؟
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.DoesSearchEnginesFollowIt))]
		public bool DoesSearchEnginesFollowIt { get; set; }
		// **********

		// **********
		/// <summary>
		/// نویسنده مطالب صفحه
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Author))]
		public string? Author { get; set; }
		// **********

		// **********
		/// <summary>
		/// طبقه بندی
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Classification))]
		public string? Classification { get; set; }
		// **********

		// **********
		/// <summary>
		/// حق نشر
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Copyright))]
		public string? Copyright { get; set; }
		// **********

		// **********
		/// <summary>
		/// تعداد بازدید
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Hits))]
		public int Hits { get; set; }
		// **********

		// **********
		/// <summary>
		/// تاریخ و زمان شروع انتشار
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.PublishStartDateTime))]
		public System.DateTime? PublishStartDateTime { get; set; }
		// **********

		// **********
		/// <summary>
		/// تاریخ و زمان پایان انتشار
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.PublishFinishDateTime))]
		public System.DateTime? PublishFinishDateTime { get; set; }
		// **********

		// **********
		/// <summary>
		/// فعال بودن صفحه
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.IsActive))]
		public bool IsActive { get; set; }
		// **********

		// **********
		/// <summary>
		/// آیدی کاربر سازنده صفحه
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.CreatorUserId))]
		public System.Guid CreatorUserId { get; set; }
		// **********

		// **********
		/// <summary>
		/// آیدی کاربر ویرایش کننده صفحه
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.UpdaterUserId))]
		public System.Guid? UpdaterUserId { get; private set; }
		// **********

		// **********
		/// <summary>
		/// آیدی کاربر حدف کننده صفحه
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.RemoverUserId))]
		public System.Guid? RemoverUserId { get; set; }
		// **********

		// **********
		/// <summary>
		/// آیا صفحه مورد نظر قابل ویرایش است؟
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.IsUpdatable))]
		public bool IsUpdatable { get; set; }
		// **********

		// **********
		/// <summary>
		/// تاریخ و زمان به روزرسانی صفحه
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.UpdateDateTime))]
		public System.DateTime? UpdateDateTime { get; private set; }
		// **********

		// **********
		/// <summary>
		/// آیا صفحه مورد نظر قابل حذف است؟
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.IsDeletable))]
		public bool IsDeletable { get; set; }
		// **********

		// **********
		/// <summary>
		/// آیا صفحه مورد نظر حذف شده است؟
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.IsDeleted))]
		public bool IsDeleted { get; set; }
		// **********

		// **********
		/// <summary>
		/// تاریخ و زمان حذف صفحه
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.DeleteDateTime))]
		public System.DateTime DeleteDateTime { get; private set; }
		// **********

		// **********
		/// <summary>
		/// سیستمی است؟
		/// </summary>

		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.IsSystemic))]
		public bool IsSystemic { get; set; }
		// **********

		// **********
		public System.Guid? ParentId { get; set; }
		// **********

		// **********
		public string? Category { get; set; }
		// **********

		// **********
		/// <summary>
		/// مرتب سازی
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Ordering))]
		public int Ordering { get; set; }
		// **********

		public void SetUpdateDateTime()
		{
			UpdateDateTime = SeedWork.Utility.Now;
		}

		public void SetDeleteDateTime()
		{
			DeleteDateTime = SeedWork.Utility.Now;
		}
	}
}
