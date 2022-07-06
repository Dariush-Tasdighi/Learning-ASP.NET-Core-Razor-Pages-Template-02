namespace ViewModels.Pages.Admin.RoleManager
{
	public class CreateRoleViewModel : Base.RoleExtendedViewModel
	{
		public CreateRoleViewModel() : base()
		{
		}

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Description),
			ResourceType = typeof(Resources.DataDictionary))]

		[System.ComponentModel.DataAnnotations.MaxLength
			(length: Domain.Models.Users.Role.DescriptionMaxLength,
			ErrorMessageResourceType = typeof(Resources.Messages.Validations),
			ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
		public string? Description { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Ordering),
			ResourceType = typeof(Resources.DataDictionary))]
		public int Ordering { get; set; }
		// **********
	}
}
