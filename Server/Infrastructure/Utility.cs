namespace Infrastructure
{
	public static class Utility
	{
		static Utility()
		{
		}

		public static string? FixText(string? text)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return null;
			}

			text =
				text.Trim();

			while (text.Contains("  "))
			{
				text =
					text.Replace("  ", " ");
			}

			return text;
		}

		public static string? RemoveSpaces(string? text)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return null;
			}

			text =
				text.Trim();

			text = text.Replace(oldValue: " ", newValue: string.Empty);

			return text;
		}

		public static string? RemoveSpacesAndMakeTextCaseInsensitive(string? text)
		{
			text = RemoveSpaces(text: text);

			if (string.IsNullOrWhiteSpace(value: text))
			{
				return text;
			}

			text = text.ToLower();

			return text;
		}
	}
}
