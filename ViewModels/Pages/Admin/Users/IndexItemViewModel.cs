namespace ViewModels.Pages.Admin.Users;

public class IndexItemViewModel : object
{
	public IndexItemViewModel() : base()
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
		(Name = nameof(Resources.DataDictionary.Role),
		ResourceType = typeof(Resources.DataDictionary))]
	public string? Role { get; init; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.Ordering),
		ResourceType = typeof(Resources.DataDictionary))]
	public int Ordering { get; init; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.EmailAddress),
		ResourceType = typeof(Resources.DataDictionary))]
	public string? EmailAddress { get; init; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.IsEmailAddressVerified),
		ResourceType = typeof(Resources.DataDictionary))]
	public bool? IsEmailAddressVerified { get; init; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.IsProgrammer),
		ResourceType = typeof(Resources.DataDictionary))]
	public bool IsProgrammer { get; init; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.IsSystemic),
		ResourceType = typeof(Resources.DataDictionary))]
	public bool IsSystemic { get; init; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.IsActive),
		ResourceType = typeof(Resources.DataDictionary))]
	public bool IsActive { get; init; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.IsUndeletable),
		ResourceType = typeof(Resources.DataDictionary))]
	public bool IsUndeletable { get; init; }
	// **********

	// **********
	//[System.ComponentModel.DataAnnotations.Display
	//	(Name = nameof(Resources.DataDictionary.CreatedPagesCountByThisUser),
	//	ResourceType = typeof(Resources.DataDictionary))]
	//public int CreatedPagesCount { get; init; }
	// **********

	//// **********
	//[System.ComponentModel.DataAnnotations.Display
	//	(Name = nameof(Resources.DataDictionary.RemovedPagesCountByThisUser),
	//	ResourceType = typeof(Resources.DataDictionary))]
	//public int RemovedPagesCount { get; init; }
	//// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.LastLoginDateTime),
		ResourceType = typeof(Resources.DataDictionary))]
	public System.DateTime? LastLoginDateTime { get; init; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.UpdateDateTime),
		ResourceType = typeof(Resources.DataDictionary))]
	public System.DateTime? UpdateDateTime { get; init; }
	// **********

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.InsertDateTime),
		ResourceType = typeof(Resources.DataDictionary))]
	public System.DateTime? InsertDateTime { get; init; }
	// **********
}
