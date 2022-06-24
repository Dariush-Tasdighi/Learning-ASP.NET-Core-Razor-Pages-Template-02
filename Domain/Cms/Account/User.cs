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
		public const int PasswordLengthInDatabase = 64;
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
			IsActive = false;
			IsVerified = false;
			// است false ها Boolean مقدار پیش فرض
			// مقداردهی این دو متغیر در "سازنده ی پیش فرض کلاس"، صرفا برای تاکید بیشتر
			// بر "غیر فعال" بودن و "تایید" نشدن کاربر در زمان درخواست "ثبت نام" است
		}

		// **********
		// **********
		// **********
		public System.Guid? RoleId { get; set; }
		// **********
		// **********
		// **********

		// **********
		public string? Username { get; set; }
		// **********

		// **********
		public string? Password { get; set; }
		// **********

		// **********
		public Enumerations.Gender Gender { get; set; }
		// **********

		// **********
		public string? FirstName { get; set; }
		// **********

		// **********
		public string? LastName { get; set; }
		// **********

		// **********
		public System.DateTime? BirthDate { get; set; }
		// **********

		// **********
		public string? CellPhoneNumber { get; set; }
		// **********

		// **********
		public string? EmailAddress { get; set; }
		// **********

		// **********
		public string? Description { get; set; }
		// **********

		// **********
		public string? EmailVerificationKey { get; set; }
		// **********

		// **********
		public System.DateTime? EmailVerificationKeyExpireDateTime { get; set; }
		// **********

		// **********
		public bool IsActive { get; set; }
		// **********

		// **********
		public bool IsVerified { get; set; }
		// **********

		// **********
		public bool IsDeleted { get; set; }
		// **********

		// **********
		public System.DateTime? VerifyDateTime { get; set; }
		// **********

		// **********
		public System.DateTime? UpdateDateTime { get; private set; }
		// **********

		public void SetUpdateDateTime()
		{
			UpdateDateTime = SeedWork.Utility.Now;
		}
	}
}
