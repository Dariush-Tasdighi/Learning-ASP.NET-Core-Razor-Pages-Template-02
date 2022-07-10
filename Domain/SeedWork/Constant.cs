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

		public static class Maximum
		{
			static Maximum()
			{
			}

			public const uint Ordering = 1000000000;
		}

		public static class Minimum
		{
			static Minimum()
			{
			}

			public const uint Ordering = 1;
		}

		public static class Default
		{
			static Default()
			{
			}

			public const uint Ordering = 10000;
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

		public static class SystemicRole
		{
			static SystemicRole()
			{
			}

			// **********
			public const string User = "User";

			public static readonly System.Guid UserRoleId = new(g: "5149D952-4078-47FF-AC82-E655975B669C");
			// **********


			// **********
			public const string Admin = "Admin";

			public static readonly System.Guid AdminRoleId = new(g: "E33AFE87-6435-42E5-9FB9-159BF656E4DF");
			// **********


			// **********
			public const string Programmer = "Programmer";

			public static readonly System.Guid ProgrammerRoleId = new(g: "95B1F405-6724-4DC6-B623-12770487F0F1");
			// **********

			// **********
			public const string Owner = "Owner";

			public static readonly System.Guid OwnerRoleId = new(g: "C55FA9F0-63CF-453A-A8AB-BE6613EBE0E2");
			// **********
		}
	}
}
