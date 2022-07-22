namespace ViewModels.Pages.Admin.UserManager
{
	public class DeleteUserViewModel : object
	{
		public DeleteUserViewModel() : base()
		{
		}

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Id),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.Guid? Id { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Username),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? Username { get; set; }
		// **********

		//// **********
		//[System.ComponentModel.DataAnnotations.Display
		//	(Name = nameof(Resources.DataDictionary.Username),
		//	ResourceType = typeof(Resources.DataDictionary))]

		//[System.ComponentModel.DataAnnotations.Compare
		//	(otherProperty: nameof(Username),
		//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.Compare))]
		//public string? ConfirmUsername { get; set; }
		//// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.LastName),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? FullName { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Role),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? Role { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsActive),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsActive { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.InsertDateTime),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.DateTime? InsertDateTime { get; set; }
		// **********
	}
}
