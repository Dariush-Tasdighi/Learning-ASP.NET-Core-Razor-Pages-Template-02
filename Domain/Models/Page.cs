//namespace Domain.Models
//{
//	public class Page : SeedWork.Entity,
//		SeedWork.IEntityHasIsActive, SeedWork.IEntityHasIsSystemic,
//		SeedWork.IEntityHasIsUpdatable, SeedWork.IEntityHasOrdering,
//		SeedWork.IEntityHasIsDeletable, SeedWork.IEntityHasLogicalDelete
//	{
//		public Page() : base()
//		{
//		}

//		// **********
//		[System.ComponentModel.DataAnnotations.Required
//		(AllowEmptyStrings = false,
//			ErrorMessageResourceType = typeof(Resources.Messages.Validations),
//			ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
//		[System.ComponentModel.DataAnnotations.StringLength
//			(maximumLength: TitleMaximumLength, MinimumLength = TitleMinimumLength)]
//		[System.ComponentModel.DataAnnotations.Display
//		(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.Title))]
//		public string? Title { get; set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//		(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.Body))]
//		public string? Body { get; set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.StringLength
//			(maximumLength: DescriptionMaximumLength)]
//		[System.ComponentModel.DataAnnotations.Display
//		(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.Description))]
//		public string? Description { get; set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.StringLength
//			(maximumLength: AuthorMaximumLength)]
//		[System.ComponentModel.DataAnnotations.Display
//		(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.Author))]
//		public string? Author { get; set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//		(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.Layout))]
//		public string? Layout { get; set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.StringLength
//			(maximumLength: KeywordsMaximumLength)]
//		[System.ComponentModel.DataAnnotations.Display
//		(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.Keywords))]
//		public string? Keywords { get; set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//		(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.IsCommentingEnabled))]
//		public bool IsCommentingEnabled { get; set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//		(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.DoesSearchEnginesIndexIt))]
//		public bool DoesSearchEnginesIndexIt { get; set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//		(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.ImageUrl))]
//		public string? ImageUrl { get; set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//		(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.Hits))]
//		public int Hits { get; set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//		(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.PublishStartDateTime))]
//		public System.DateTime? PublishStartDateTime { get; set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//		(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.PublishFinishDateTime))]
//		public System.DateTime? PublishFinishDateTime { get; set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//		(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.IsActive))]
//		public bool IsActive { get; set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//		(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.CreatorUserId))]
//		public System.Guid CreatorUserId { get; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//		(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.UpdaterUserId))]
//		public System.Guid UpdaterUserId { get; private set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//		(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.UpdateDateTime))]
//		public System.DateTime UpdateDateTime { get; private set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//		(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.IsUpdatable))]
//		public bool IsUpdatable { get; set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//		(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.RemoverUserId))]
//		public System.Guid RemoverUserId { get; private set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//		(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.DeleteDateTime))]
//		public System.DateTime DeleteDateTime { get; private set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//		(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.IsDeletable))]
//		public bool IsDeletable { get; set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//		(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.Deleted))]
//		public bool Deleted { get; private set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//		(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.IsSystemic))]
//		public bool IsSystemic { get; set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//		(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.Parent))]
//		public System.Guid? ParentId { get; set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//		(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.Category))]
//		public string? Category { get; set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//		(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.Ordering))]
//		public int Ordering { get; set; }
//		// **********

//		public void SetUpdateDateTime()
//		{
//			UpdateDateTime = SeedWork.Utility.Now;
//		}
//	}
//}
