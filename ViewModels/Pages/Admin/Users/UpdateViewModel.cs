namespace ViewModels.Pages.Admin.Users;

public class UpdateViewModel : CommonViewModel
{
	#region Constructor
	public UpdateViewModel() : base()
	{
	}
	#endregion /Constructor

	#region Id Property
	/// <summary>
	/// شناسه
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Id))]
	public System.Guid Id { get; set; }
	#endregion /Id Property
}
