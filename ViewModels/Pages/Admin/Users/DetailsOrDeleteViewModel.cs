namespace ViewModels.Pages.Admin.Users
{
	public class DetailsOrDeleteViewModel : object
	{
		public DetailsOrDeleteViewModel() : base()
		{
		}

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Id))]
		public System.Guid Id { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Role))]
		public string? Role { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.IsActive))]
		public bool? IsRoleActive { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.IsActive))]
		public bool IsActive { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.IsProfilePublic))]
		public bool IsProfilePublic { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.IsEmailAddressVerified))]
		public bool IsEmailAddressVerified { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.IsCellPhoneNumberVerified))]
		public bool IsCellPhoneNumberVerified { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Username))]
		public string? Username { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.FullName))]
		public string? FullName { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.EmailAddress))]
		public string? EmailAddress { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.CellPhoneNumber))]
		public string? CellPhoneNumber { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Ordering))]
		public int Ordering { get; init; }
		// **********

		//// **********
		//[System.ComponentModel.DataAnnotations.Display
		//	(ResourceType = typeof(Resources.DataDictionary),
		//	Name = nameof(Resources.DataDictionary.Description))]
		//public string? Description { get; init; }
		//// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.AdminDescription))]
		public string? AdminDescription { get; init; }
		// **********
	}
}
