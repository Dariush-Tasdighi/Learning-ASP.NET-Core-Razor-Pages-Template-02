namespace ViewModels.Pages.Admin.UserManager
{
	public class UpdateUserViewModel : object
	{
		public UpdateUserViewModel() : base()
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
			(Name = nameof(Resources.DataDictionary.IsUndeletable),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsUndeletable { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsProgrammer),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsProgrammer { get; set; }
		// **********

		// **********
		//[System.ComponentModel.DataAnnotations.Display
		//	(Name = nameof(Resources.DataDictionary.Role),
		//	ResourceType = typeof(Resources.DataDictionary))]
		//public string? Role { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Role),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.Guid? RoleId { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Ordering),
			ResourceType = typeof(Resources.DataDictionary))]

		[System.ComponentModel.DataAnnotations.Range
			(minimum: Domain.SeedWork.Constant.Minimum.Ordering,
			maximum: Domain.SeedWork.Constant.Maximum.Ordering,
			ErrorMessageResourceType = typeof(Resources.Messages.Validations),
			ErrorMessageResourceName = nameof(Resources.Messages.Validations.Range))]
		public int Ordering { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.AdminDescription),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? AdminDescription { get; set; }
		// **********
	}
}
