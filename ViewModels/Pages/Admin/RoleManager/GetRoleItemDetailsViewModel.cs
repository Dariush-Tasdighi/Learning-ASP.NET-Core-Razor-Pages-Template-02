namespace ViewModels.Pages.Admin.RoleManager
{
	public class GetRoleItemDetailsViewModel : Base.RoleExtendedViewModel
	{
		public GetRoleItemDetailsViewModel()
		{
		}

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Description),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? Description { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsDeleted),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsDeleted { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsSystemic),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsSystemic { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.InsertDateTime),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.DateTime InsertDateTime { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.UpdateDateTime),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.DateTime? UpdateDateTime { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Ordering),
			ResourceType = typeof(Resources.DataDictionary))]
		public int Ordering { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.NumberOfUsersWithThisRole),
			ResourceType = typeof(Resources.DataDictionary))]
		public int? NumberOfUserWithThisRole { get; set; }
		// **********
	}
}
