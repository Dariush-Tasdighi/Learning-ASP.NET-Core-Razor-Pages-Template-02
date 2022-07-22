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

			public const int IP = 15;

			public const int Name = 50;
			public const int Title = 50;

			public const int Username = 20;
			public const int FullName = 50;
			public const int Password = 128;
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

			public const string AToZDigitsUnderline =
				@"^[a-zA-Z][a-zA-Z0-9_]*$";

			public const string EmailAddress =
				@"^[a-zA-Z0-9_.-]+@[a-zA-Z0-9_.-]+$";

			public const string CellPhoneNumber =
				@"^00989\d{9}$";

			public const string IP =
				@"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

			public const string Url =
				@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";
		}

		public static class Maximum
		{
			static Maximum()
			{
			}

			public const uint Ordering = 1_000_000_000;
		}

		public static class Minimum
		{
			static Minimum()
			{
			}

			public const uint Ordering = 0;
		}

		public static class Default
		{
			static Default()
			{
			}

			public const uint Ordering = 10_000;
		}
	}
}
