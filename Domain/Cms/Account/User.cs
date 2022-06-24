namespace Domain.Cms.Account
{
	public class User : SeedWork.Entity, SeedWork.IEntityHasIsActive, SeedWork.IEntityHasUpdateDateTime
	{
		#region Constant(s)
		public const int UsernameMinLength = 6;
		public const int UsernameMaxLength = 20;
		public const string UsernameRegularExpression = "^[a-zA-Z0-9_-]{8,20}$";


		public const int PasswordMinLength = 8;
		public const int PasswordMaxLength = 20;
		public const int PasswordLengthInDatabase = 40;
		public const string PasswordRegularExpression = "^[a-zA-Z0-9_-]{8,20}$";

		public const int EmailAddressMaxLength = 250;
		public const int EmailAddressVerificationKeyFixLength = 32;

		public const int CellPhoneMaxLength = 11;
		public const int CellPhoneVerificationKeyFixLength = 6;
		public const string CellPhoneRegularExpression = @"09\d{9}";

		public const int LastNameMaxLength = 50;
		public const int FirstNameMaxLength = 50;
		#endregion Constant(s)

		public User() : base()
		{
		}

		//// **********
		//// **********
		//// **********
		//public Role Role { get; set; }
		//// **********

		//// **********
		//public System.Guid RoleId { get; set; }
		//// **********
		//// **********
		//// **********

		// **********
		public string? Username { get; set; }
		// **********

		// **********
		public string? Password { get; set; }
		// **********

		// **********
		public string? FirstName { get; set; }
		// **********

		// **********
		public string? LastName { get; set; }
		// **********

		// **********
		public string? EmailAddress { get; set; }
		// **********

		// **********
		public string? CellPhoneNumber { get; set; }
		// **********

		// **********
		public string? Description { get; set; }
		// **********

		// **********
		public Enumerations.Gender Gender { get; set; }
		// **********

		// **********
		public bool IsActive { get; set; }
		// **********

		// **********
		public bool IsDeleted { get; set; }
		// **********

		// **********
		public bool IsVerified { get; set; }
		// **********

		// **********
		public bool IsCellPhoneVerified { get; set; }
		// **********

		// **********
		public bool IsEmailAddressVerified { get; set; }
		// **********

		// **********
		public string? EmailAddressVerificationCode { get; set; }
		// **********

		// **********
		public string? CellPhoneVerificationCode { get; set; }
		// **********

		// **********
		public System.DateTime UpdateDateTime { get; private set; }
		// **********

		public void SetUpdateDateTime()
		{
			UpdateDateTime = SeedWork.Utility.Now;
		}
	}
}
