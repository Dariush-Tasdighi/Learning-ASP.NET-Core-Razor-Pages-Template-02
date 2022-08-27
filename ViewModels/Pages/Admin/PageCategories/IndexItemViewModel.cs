namespace ViewModels.Pages.Admin.PageCategories;

public class IndexItemViewModel : object
{
	public IndexItemViewModel() : base()
	{
		Name = string.Empty;
	}

	// **********
	public System.Guid Id { get; set; }
	// **********

	// **********
	public bool IsActive { get; set; }
	// **********

	// **********
	public string Name { get; set; }
	// **********

	// **********
	public int Ordering { get; set; }
	// **********

	// **********
	public int PageCount { get; set; }
	// **********

	// **********
	public System.DateTime InsertDateTime { get; set; }
	// **********

	// **********
	public System.DateTime UpdateDateTime { get; set; }
	// **********
}
