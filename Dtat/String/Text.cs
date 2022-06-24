namespace Dtat.String
{
	public static class Text : object
	{
		static Text()
		{
		}

		public static string? Fix(string? text)
		{
			string? value = null;

			if (text == null)
			{
				return value;
			}

			text = text.Trim();

			if (text == string.Empty)
			{
				return value;
			}

			while (text.Contains("  "))
			{
				value = text.Replace("  ", " ");
			}

			return value;
		}

		public static string? RemoveSpaces(string? text)
		{
			string? value = null;

			if (text == null)
			{
				return value;
			}

			value = text.Replace(oldValue: " ", newValue: string.Empty);

			return value;
		}
	}
}
