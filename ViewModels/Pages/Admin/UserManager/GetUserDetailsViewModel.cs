namespace ViewModels.Pages.Admin.UserManager
{
	public class GetUserDetailsViewModel : object
	{
		public GetUserDetailsViewModel() : base()
		{
		}

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Role),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? Role { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Username),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? Username { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Gender),
			ResourceType = typeof(Resources.DataDictionary))]
		public Domain.Models.Enumerations.Gender? Gender { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.FirstName),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? FirstName { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.LastName),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? LastName { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.BirthDate),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.DateTime? BirthDate { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.NationalCode),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? NationalCode { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.EmailAddress),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? EmailAddress { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsEmailAddressVerified),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool? IsEmailAddressVerified { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.CellPhoneNumber),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? CellPhoneNumber { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsCellPhoneNumberVerified),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool? IsCellPhoneNumberVerified { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Description),
			ResourceType = typeof(Resources.DataDictionary))]
		public string? Description { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsActive),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsActive { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsVerified),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsVerified { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.IsDeleted),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool IsDeleted { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.VerifyDateTime),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.DateTime? VerifyDateTime { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.UpdateDateTime),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.DateTime? UpdateDateTime { get; init; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.InsertDateTime),
			ResourceType = typeof(Resources.DataDictionary))]
		public System.DateTime? InsertDateTime { get; init; }
		// **********
	}
}
