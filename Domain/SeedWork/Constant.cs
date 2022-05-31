namespace Domain.SeedWork
{
	public static class Constant
	{
		static Constant()
		{
		}

		public static class MaxLength
		{
			static MaxLength()
			{
			}

			public const int LastName = 30;
			public const int FirstName = 20;

			public const int Username = 20;
			public const int Password = 20;
			public const int PasswordInDatabase = 128;

			public const int NationalCode = 10;

			public const int EmailAddress = 254;
			public const int EmailAddressVerificationKey = 64;

			public const int CellPhoneNumber = 14;
			public const int CellPhoneNumberVerificationKey = 10;
		}

		/// <summary>
		/// https://regex101.com/
		/// </summary>
		public static class RegularExpression
		{
			static RegularExpression()
			{
			}

			public const string Username =
				@"^[a-zA-Z0-9_]{6,20}$";

			public const string Password =
				@"^[a-zA-Z0-9_]{8,20}$";

			public const string NationalCode =
				@"^\d{10}$";

			public const string CellPhoneNumber =
				@"^00989\d{9}$";

			public const string EmailAddress =
				@"^[a-zA-Z0-9_.-]+@[a-zA-Z0-9_.-]+$";

			public const string IP =
				@"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

			public const string Url =
				@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";
		}
	}
}
