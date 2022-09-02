namespace ViewModels.Pages.Account
{
	public class LoginViewModel : object
	{
		public LoginViewModel() : base()
		{
		}

		// **********
		//[System.ComponentModel.DataAnnotations.Display
		//	(Name = "Username")]

		//[System.ComponentModel.DataAnnotations.Display
		//	(Name = "Username",
		//	ResourceType = typeof(Resources.DataDictionary))]

		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Username),
			ResourceType = typeof(Resources.DataDictionary))]

		//[System.ComponentModel.DataAnnotations.Required]

		//[System.ComponentModel.DataAnnotations.Required
		//	(AllowEmptyStrings = false)]

		//[System.ComponentModel.DataAnnotations.Required
		//	(AllowEmptyStrings = false,
		//	ErrorMessage = "You did not specify Username!")]

		//[System.ComponentModel.DataAnnotations.Required
		//	(AllowEmptyStrings = false,
		//	ErrorMessage = "You did not specify {0}!")]

		//[System.ComponentModel.DataAnnotations.Required
		//	(AllowEmptyStrings = false,
		//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		//	ErrorMessageResourceName = "Required")]

		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false,
			ErrorMessageResourceType = typeof(Resources.Messages.Validations),
			ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

		//[System.ComponentModel.DataAnnotations.MaxLength
		//	(length: 20,
		//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

		[System.ComponentModel.DataAnnotations.MaxLength
			(length: Constants.MaxLength.Username,
			ErrorMessageResourceType = typeof(Resources.Messages.Validations),
			ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

		//[System.ComponentModel.DataAnnotations.RegularExpression
		//	(pattern: @"^[a-zA-Z0-9_]{6,20}$",
		//	ErrorMessageResourceType = typeof(Resources.Messages.Validations),
		//	ErrorMessageResourceName = nameof(Resources.Messages.Validations.Username))]

		[System.ComponentModel.DataAnnotations.RegularExpression
			(pattern: Constants.RegularExpression.Username,
			ErrorMessageResourceType = typeof(Resources.Messages.Validations),
			ErrorMessageResourceName = nameof(Resources.Messages.Validations.Username))]
		public string? Username { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Password),
			ResourceType = typeof(Resources.DataDictionary))]

		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false,
			ErrorMessageResourceType = typeof(Resources.Messages.Validations),
			ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

		[System.ComponentModel.DataAnnotations.MaxLength
			(length: Constants.MaxLength.Password,
			ErrorMessageResourceType = typeof(Resources.Messages.Validations),
			ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

		[System.ComponentModel.DataAnnotations.RegularExpression
			(pattern: Constants.RegularExpression.Password,
			ErrorMessageResourceType = typeof(Resources.Messages.Validations),
			ErrorMessageResourceName = nameof(Resources.Messages.Validations.Password))]

		[System.ComponentModel.DataAnnotations.DataType
			(dataType: System.ComponentModel.DataAnnotations.DataType.Password)]
		public string? Password { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.RememberMe),
			ResourceType = typeof(Resources.DataDictionary))]
		public bool RememberMe { get; set; }
		// **********
	}
}
