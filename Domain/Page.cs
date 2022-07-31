namespace Domain
{
	public class Page :
		SeedWork.Entity,
		SeedWork.IEntityHasIsActive,
		SeedWork.IEntityHasIsSystemic,
		SeedWork.IEntityHasIsUnupdatable,
		SeedWork.IEntityHasIsUndeletable,
		SeedWork.IEntityHasUpdateDateTime,
		SeedWork.IEntityHasDeleteDateTime,
		SeedWork.IEntityHasLogicalDelete
	{
		#region Constant(s)
		public const byte TitleMaxLength = 100;

		public const byte AuthorMaxLength = 200;

		public const byte CategoryMaxLength = 200;

		public const byte DescriptionMaxLength = 100;

		public const int ImageUrlMaxLength = 4000;

		public const int CopyrightMaxLength = 1000;

		public const int IntroductionMaxLength = 4000;

		public const int ClassificationMaxLength = 1000;
		#endregion /Constant(s)

		public Page(string title, System.Guid creatorUserId) : base()
		{
			Title = title;

			CreatorUserId = creatorUserId;

			//SetUpdateDateTime();
			UpdateDateTime = InsertDateTime;
		}

		// **********
		// **********
		// **********
		/// <summary>
		/// آیدی کاربر سازنده صفحه
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.CreatorUser))]
		public System.Guid CreatorUserId { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.CreatorUser))]
		public virtual User? CreatorUser { get; set; }
		// **********
		// **********
		// **********

		// **********
		// **********
		// **********
		/// <summary>
		/// کاربر حذف کننده ی صفحه
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.RemoverUser))]
		public System.Guid? RemoverUserId { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.RemoverUser))]
		public virtual User? RemoverUser { get; set; }
		// **********
		// **********
		// **********

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
		//public virtual Layout Layout { get; set; }
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
		/// رمز عبور
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Password))]
		public string? Password { get; set; }
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
		/// مقدمه
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
		/// آیا صفحه مورد نظر قابل ویرایش است؟
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.IsUpdatable))]
		public bool IsUnupdatable { get; set; }
		// **********

		// **********
		/// <summary>
		/// تاریخ و زمان به روزرسانی صفحه
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.UpdateDateTime))]
		public System.DateTime UpdateDateTime { get; private set; }
		// **********

		// **********
		/// <summary>
		/// آیا صفحه مورد نظر قابل حذف است؟
		/// </summary>
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.IsUndeletable))]
		public bool IsUndeletable { get; set; }
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
		public string? Category { get; set; }
		// **********

		#region Method(s)
		public void SetUpdateDateTime()
		{
			UpdateDateTime = SeedWork.Utility.Now;
		}

		public void SetDeleteDateTime()
		{
			//if (IsDeleted)
			//{
			//	DeleteDateTime = SeedWork.Utility.Now;
			//}

			DeleteDateTime = SeedWork.Utility.Now;
		}
		#endregion /Method(s)
	}
}
