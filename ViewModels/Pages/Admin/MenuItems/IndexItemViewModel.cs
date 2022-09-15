namespace ViewModels.Pages.Admin.MenuItems;

public class IndexItemViewModel : object
{
	public IndexItemViewModel() : base()
	{
	}

	// **********
	public System.Guid Id { get; set; }
	// **********

	// **********
	public string? Title { get; set; }
	// **********

	// **********
	public string? Icon { get; set; }
	// **********

	// **********
	public bool IsActive { get; set; }
	// **********

	// **********
	public bool IsPublic { get; set; }
	// **********

	// **********
	public bool IsDeleted { get; set; }
	// **********

	// **********
	public int Ordering { get; set; }
	// **********

	// **********
	public bool IsUndeletable { get; set; }
	// **********

	// **********
	public System.DateTime? UpdateDateTime { get; set; }
	// **********

	// **********
	public System.DateTime InsertDateTime { get; set; }
	// **********

	// **********
	public bool HasAnySubMenu { get; set; }
	// **********
}
