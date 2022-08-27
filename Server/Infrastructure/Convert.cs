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
				System.Threading.Thread.CurrentThread
				.CurrentUICulture.Parent.Name.ToUpper();

			switch (currentUICultureName)
			{
				case "FA":
				case "AR":
				{
					var result =
						value
						.Replace(oldChar: '0', newChar: '۰')
						.Replace(oldChar: '1', newChar: '۱')
						.Replace(oldChar: '2', newChar: '۲')
						.Replace(oldChar: '3', newChar: '۳')
						.Replace(oldChar: '4', newChar: '۴')
						.Replace(oldChar: '5', newChar: '۵')
						.Replace(oldChar: '6', newChar: '۶')
						.Replace(oldChar: '7', newChar: '۷')
						.Replace(oldChar: '8', newChar: '۸')
						.Replace(oldChar: '9', newChar: '۹')
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
