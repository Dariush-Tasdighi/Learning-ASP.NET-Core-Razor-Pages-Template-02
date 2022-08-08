namespace Domain.SeedWork
{
	public static class Constants : object
	{
		static Constants()
		{
		}

		public static class Logger : object
		{
			static Logger()
			{
			}

			public const string ErrorMessage = "Error Message: {Message}";
		}

		public static class Format : object
		{
			static Format()
			{
			}

			public const string Date = "yyyy/MM/dd";
			public const string Time = "HH:mm:ss";
			public const string DateTime = "yyyy/MM/dd - HH:mm:ss";
		}

		public static class FixedLength : object
		{
			static FixedLength()
			{
			}

			public const int NationalCode = 10;
			public const int CellPhoneNumber = 14;
			public const int DatabasePassword = 44;
		}

		public static class MinLength : object
		{
			static MinLength()
			{
			}

			public const int CellPhoneNumberVerificationKey = 6;
		}

		public static class MaxLength : object
		{
			static MaxLength()
			{
			}

			public const int IP = 15;

			public const int Name = 50;
			public const int Title = 50;

			public const int Username = 20;
			public const int FullName = 50;
			public const int Password = 20;

			public const int EmailAddress = 254;

			public const int CellPhoneNumberVerificationKey = 10;
		}

		/// <summary>
		/// https://regex101.com/
		/// </summary>
		public static class RegularExpression : object
		{
			static RegularExpression()
			{
			}

			public const string NationalCode =
				@"^\d{10}$";

			public const string Username =
				@"^[a-zA-Z0-9_]{6,20}$";

			public const string CellPhoneNumber =
				@"^00989\d{9}";

			public const string AToZDigitsUnderline =
				@"^[a-zA-Z][a-zA-Z0-9_]*$";

			public const string EmailAddress =
				@"^[a-zA-Z0-9_.-]+@[a-zA-Z0-9_.-]+$";

			public const string Password =
				@"^[a-zA-Z0-9_]{8,20}$";

			public const string IP =
				@"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

			public const string Url =
				@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";
		}

		public static class Minimum : object
		{
			static Minimum()
			{
			}

			public const int Ordering = 1;
		}

		public static class Maximum : object
		{
			static Maximum()
			{
			}

			public const int Ordering = 100_000;
		}
	}
}
