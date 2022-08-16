namespace ViewModels.Pages.Admin.Roles
{
	public class CommonViewModel : object
	{
		public CommonViewModel() : base()
		{
		}

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Role))]
		public string? Name { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Id))]
		public System.Guid? Id { get; set; }
		// **********
	}
}
