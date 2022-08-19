namespace Infrastructure
{
	public static class Convert : object
	{
		static Convert()
		{
		}

		public static string? DigitsToUnicode(string? value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				return value;
			}

			var currentUICultureName =
				System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToUpper();

			switch (currentUICultureName)
			{
				case "FA-IR":
				case "AR-SU":
				{
					var result =
						value
						.Replace("0", "۰")
						.Replace("1", "۱")
						.Replace("2", "۲")
						.Replace("3", "۳")
						.Replace("4", "۴")
						.Replace("5", "۵")
						.Replace("6", "۶")
						.Replace("7", "۷")
						.Replace("8", "۸")
						.Replace("9", "۹")
						;

					return result;
				}

				default:
				{
					return value;
				}
			}
		}
	}
}
