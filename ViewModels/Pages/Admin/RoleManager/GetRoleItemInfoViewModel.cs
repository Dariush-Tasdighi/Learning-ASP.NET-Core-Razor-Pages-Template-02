namespace ViewModels.Pages.Admin.RoleManager
{
	public class GetRoleItemInfoViewModel : Base.RoleExtendedViewModel
	{
		public GetRoleItemInfoViewModel() : base()
		{
		}

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsDeleted),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsDeleted { get; set; }
		// **********
		
		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsSystemic),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsSystemic { get; set; }
		// **********
	}
}
