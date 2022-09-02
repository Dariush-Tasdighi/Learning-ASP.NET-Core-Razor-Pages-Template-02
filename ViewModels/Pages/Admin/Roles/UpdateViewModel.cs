namespace ViewModels.Pages.Admin.Roles;

public class UpdateViewModel : CreateViewModel
{
	public UpdateViewModel() : base()
	{
	}

	// **********
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Id))]

	[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
		(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
	public System.Guid Id { get; set; }
	// **********
}

//namespace ViewModels.Pages.Admin.Roles
//{
//	public class UpdateViewModel : object
//	{
//		public UpdateViewModel() : base()
//		{
//			Ordering = 10_000;
//		}

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//			(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.Id))]

//		[System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated
//			(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
//		public System.Guid Id { get; set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//			(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.IsActive))]
//		public bool IsActive { get; set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//			(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.Ordering))]

//		[System.ComponentModel.DataAnnotations.Required
//			(AllowEmptyStrings = false,
//			ErrorMessageResourceType = typeof(Resources.Messages.Validations),
//			ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

//		[System.ComponentModel.DataAnnotations.Range
//			(minimum: 1, maximum: 100_000,
//			ErrorMessageResourceType = typeof(Resources.Messages.Validations),
//			ErrorMessageResourceName = nameof(Resources.Messages.Validations.Range))]
//		public int Ordering { get; set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//			(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.Name))]

//		[System.ComponentModel.DataAnnotations.Required
//			(AllowEmptyStrings = false,
//			ErrorMessageResourceType = typeof(Resources.Messages.Validations),
//			ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

//		[System.ComponentModel.DataAnnotations.MaxLength
//			(length: Domain.SeedWork.Constants.MaxLength.Name,
//			ErrorMessageResourceType = typeof(Resources.Messages.Validations),
//			ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]
//		public string? Name { get; set; }
//		// **********

//		// **********
//		[System.ComponentModel.DataAnnotations.Display
//			(ResourceType = typeof(Resources.DataDictionary),
//			Name = nameof(Resources.DataDictionary.Description))]

//		[System.ComponentModel.DataAnnotations.DataType
//			(System.ComponentModel.DataAnnotations.DataType.MultilineText)]
//		public string? Description { get; set; }
//		// **********
//	}
//}
