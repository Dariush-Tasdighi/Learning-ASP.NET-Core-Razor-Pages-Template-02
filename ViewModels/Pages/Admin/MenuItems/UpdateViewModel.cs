namespace ViewModels.Pages.Admin.MenuItems;

public class UpdateViewModel : CreateViewModel
{
	public UpdateViewModel() : base()
	{
	}

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Id))]
	public System.Guid? Id { get; set; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Parent))]
	public string? ParentTitle { get; set; }
	// **********

}
