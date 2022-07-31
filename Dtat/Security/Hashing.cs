namespace Dtat.Security
{
	public static class Hashing
	{
		static Hashing()
		{
		}

		public static string GetSha256(string text)
		{
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

			return result;
		}
	}
}
