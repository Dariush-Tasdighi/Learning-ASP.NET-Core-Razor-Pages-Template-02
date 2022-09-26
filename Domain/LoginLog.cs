namespace Domain
{
	public class LoginLog : Seedwork.Entity
	{
		public LoginLog(System.Guid userId, string userIP) : base()
		{
			UserIP = userIP;
			UserId = userId;
		}

		// **********
		// **********
		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.User))]

		[System.ComponentModel.DataAnnotations.Required
			(ErrorMessageResourceType = typeof(Resources.Messages.Validations),
			ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]
		public System.Guid UserId { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.User))]
		public virtual User? User { get; set; }
		// **********
		// **********
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.IP))]

		[System.ComponentModel.DataAnnotations.Required
			(ErrorMessageResourceType = typeof(Resources.Messages.Validations),
			ErrorMessageResourceName = nameof(Resources.Messages.Validations.Required))]

		[System.ComponentModel.DataAnnotations.MaxLength
			(length: Constants.MaxLength.IP,
			ErrorMessageResourceType = typeof(Resources.Messages.Validations),
			ErrorMessageResourceName = nameof(Resources.Messages.Validations.MaxLength))]

		[System.ComponentModel.DataAnnotations.RegularExpression
			(pattern: Constants.RegularExpression.IP,
			ErrorMessageResourceType = typeof(Resources.Messages.Validations),
			ErrorMessageResourceName = nameof(Resources.Messages.Validations.IP))]
		public string UserIP { get; set; }
		// **********
	}
}
