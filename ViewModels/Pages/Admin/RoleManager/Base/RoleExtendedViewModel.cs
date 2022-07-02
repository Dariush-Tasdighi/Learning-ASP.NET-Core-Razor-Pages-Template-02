namespace ViewModels.Pages.Admin.RoleManager.Base
{
	public abstract class RoleExtendedViewModel : RoleBaseViewModel
	{
		public RoleExtendedViewModel() : base()
		{
		}

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsActive),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsActive { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsDeletable),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsDeletable { get; set; }
		// **********
	}
}
