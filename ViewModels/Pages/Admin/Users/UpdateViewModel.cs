namespace ViewModels.Pages.Admin.Users;

public class UpdateViewModel : CommonViewModel
{
	#region Constructor
	public UpdateViewModel() : base()
	{
	}
	#endregion /Constructor

	#region Properties

	#region Id Property
	/// <summary>
	/// شناسه
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Id))]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.Guid Id { get; protected set; }
	#endregion /Id Property

	#endregion /Properties
}
