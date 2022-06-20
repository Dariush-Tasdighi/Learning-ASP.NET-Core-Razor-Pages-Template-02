namespace Dtat.Security
{
	public static class Cryptography
	{
		static Cryptography()
		{
		}

		public static string? GetSha256(string? text)
		{
			if (string.IsNullOrWhiteSpace(value: text))
			{
				return null;
			}

			var inputBytes =
				System.Text.Encoding.UTF8.GetBytes(s: text);

			var sha =
				System.Security.Cryptography.SHA256.Create();

			var outputBytes =
				sha.ComputeHash(buffer: inputBytes);

			sha.Dispose();
			//sha = null;

			var result =
				System.Convert.ToBase64String(inArray: outputBytes);

			result =
				result.ToLower();

			return result;
		}
	}
}
