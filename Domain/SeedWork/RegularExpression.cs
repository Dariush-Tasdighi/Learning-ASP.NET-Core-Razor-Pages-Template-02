namespace Domain.SeedWork
{
	/// <summary>
	/// https://regex101.com/
	/// </summary>
	public static class RegularExpression
	{
		static RegularExpression()
		{
		}

		public const string NationalCode =
			@"^\d{10}$";

		public const string CellPhoneNumber =
			@"^00989\d{9}$";

		public const string Username =
			@"^[a-zA-Z][a-zA-Z0-9_]{7,20}$";

		public const string AToZDigitsUnderline =
			@"^[a-zA-Z][a-zA-Z0-9_]*$";

		public const string EmailAddress =
			@"^[a-zA-Z0-9_.-]+@[a-zA-Z0-9_.-]+$";

		public const string Password =
			@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,20}$";

		public const string ApplicationSecretKey =
			@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{16,64}$";

		public const string IP =
			@"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

		public const string Url =
			@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";
	}
}
