namespace ViewModels.Pages.Admin.Roles
{
	public class CreateViewModel : Common
	{
		public CreateViewModel() : base()
		{
		}

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Description))]

		[System.ComponentModel.DataAnnotations.DataType
			(System.ComponentModel.DataAnnotations.DataType.MultilineText)]
		public string? Description { get; set; }
		// **********
	}
}
