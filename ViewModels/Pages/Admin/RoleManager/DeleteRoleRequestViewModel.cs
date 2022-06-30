namespace ViewModels.Pages.Admin.RoleManager
{
	public class DeleteRoleRequestViewModel : object
	{
		public DeleteRoleRequestViewModel() : base()
		{
		}

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Id))]
		public System.Guid? Id { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Role),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? Name { get; set; }
		// **********

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

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsSystemic),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsSystemic { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.InsertDateTime))]
		public System.DateTime InsertDateTime { get; set; }
		// **********
	}
}
