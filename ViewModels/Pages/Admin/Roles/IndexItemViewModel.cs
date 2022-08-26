namespace ViewModels.Pages.Admin.Roles;

public class IndexItemViewModel : object
{
	public IndexItemViewModel() : base()
	{
		// Note: Just For Ignoring Warning!
		Name = string.Empty;
	}

	// **********
	/// <summary>
	/// با نگاه جدید نیازی به دستور ذیل نمی‌باشد
	/// </summary>
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
	public int Ordering { get; set; }
	// **********

	// **********
	public int UserCount { get; set; }
	// **********

	// **********
	public System.DateTime InsertDateTime { get; set; }
	// **********

	// **********
	public System.DateTime UpdateDateTime { get; set; }
	// **********
}
