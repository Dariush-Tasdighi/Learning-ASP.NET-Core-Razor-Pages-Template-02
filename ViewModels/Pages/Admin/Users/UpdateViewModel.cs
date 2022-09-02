namespace ViewModels.Pages.Admin.Users;

public class UpdateViewModel : CommonViewModel
{
	public UpdateViewModel() : base()
	{
	}

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(Name = nameof(Resources.DataDictionary.Id),
		ResourceType = typeof(Resources.DataDictionary))]
	public System.Guid? Id { get; set; }
	// **********
}
