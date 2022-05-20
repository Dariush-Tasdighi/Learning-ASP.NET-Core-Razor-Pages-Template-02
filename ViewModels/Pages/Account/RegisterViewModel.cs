namespace ViewModels.Pages.Account
{
	public class RegisterViewModel : object
	{
		public RegisterViewModel() : base()
		{
		}

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Username),
			ResourceType = typeof(Resources.DataDictionary))]

		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false,
			ErrorMessage = "You did not specify {0}!")]

		[System.ComponentModel.DataAnnotations.StringLength
			(maximumLength: 20,
			ErrorMessage = "The maximum length of {0} is {1}!")]

		[System.ComponentModel.DataAnnotations.RegularExpression
			(pattern: Domain.SeedWork.RegularExpression.Username,
			ErrorMessage = "{0} is not valid!")]
		public string? Username { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.Password),
			ResourceType = typeof(Resources.DataDictionary))]

		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false,
			ErrorMessage = "You did not specify {0}!")]

		[System.ComponentModel.DataAnnotations.StringLength
			(maximumLength: 20,
			ErrorMessage = "The maximum length of {0} is {1}!")]

		[System.ComponentModel.DataAnnotations.RegularExpression
			(pattern: Domain.SeedWork.RegularExpression.Password,
			ErrorMessage = "{0} is not valid!")]

		[System.ComponentModel.DataAnnotations.DataType
			(dataType: System.ComponentModel.DataAnnotations.DataType.Password)]
		public string? Password { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.ConfirmPassword),
			ResourceType = typeof(Resources.DataDictionary))]

		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false,
			ErrorMessage = "You did not specify {0}!")]

		[System.ComponentModel.DataAnnotations.DataType
			(dataType: System.ComponentModel.DataAnnotations.DataType.Password)]

		[System.ComponentModel.DataAnnotations.Compare
			(otherProperty: nameof(Password),
			ErrorMessage = "The {0} should be equql to {1}!")]
		public string? ConfirmPassword { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = nameof(Resources.DataDictionary.EmailAddress),
			ResourceType = typeof(Resources.DataDictionary))]

		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false,
			ErrorMessage = "You did not specify {0}!")]

		[System.ComponentModel.DataAnnotations.StringLength
			(maximumLength: 250,
			ErrorMessage = "The maximum length of {0} is {1}!")]

		[System.ComponentModel.DataAnnotations.RegularExpression
			(pattern: Domain.SeedWork.RegularExpression.EmailAddress,
			ErrorMessage = "{0} is not valid!")]

		//[System.ComponentModel.DataAnnotations.DataType
		//	(dataType: System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
		public string? EmailAddress { get; set; }
		// **********
	}
}
