namespace ViewModels.Pages.Admin.ApplicationHandlers;

public class IndexItemViewModel : object
{
	public IndexItemViewModel() : base()
	{
		Name = string.Empty;
		Path = string.Empty;
	}

	// **********
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.Id))]
	public System.Guid Id { get; set; }
	// **********

	// **********
	public bool IsActive { get; set; }
	// **********

	// **********
	public string Name { get; set; }
	// **********

	// **********
	public string Path { get; set; }
	// **********

	// **********
	public string? Title { get; set; }
	// **********

	// **********
	public int Ordering { get; set; }
	// **********

	// **********
	public System.DateTime InsertDateTime { get; set; }
	// **********

	// **********
	public System.DateTime UpdateDateTime { get; set; }
	// **********
}
