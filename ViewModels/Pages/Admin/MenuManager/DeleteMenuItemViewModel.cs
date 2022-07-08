namespace ViewModels.Pages.Admin.MenuManager
{
	public class DeleteMenuItemViewModel : object
	{
		public DeleteMenuItemViewModel() : base()
		{
		}

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Id),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.Guid? Id { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Title),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? Title { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Link),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? Link { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsActive),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsActive { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsPublic),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsPublic { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.SubMenus),
			ResourceType = typeof(Resources.DataDictionary))]
		public int NumberOfSubMenus { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.InsertDateTime),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.DateTime InsertDateTime { get; init; }
		// **********
	}
}
