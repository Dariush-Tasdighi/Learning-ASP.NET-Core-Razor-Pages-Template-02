namespace ViewModels.Pages.Admin.Users
{
	public class DeleteDetailsViewModel : object
	{
		public DeleteDetailsViewModel() : base()
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
			(Name = nameof(Resources.DataDictionary.Role),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? Role { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.FullName),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? FullName { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.EmailAddress),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? EmailAddress { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsActive),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsActive { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsEmailAddressVerified),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsEmailAddressVerified { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Ordering),
			ResourceType = typeof(Resources.DataDictionary))]
		public int? Ordering { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.AdminDescription),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? AdminDescription { get; set; }
		// **********
	}
}
