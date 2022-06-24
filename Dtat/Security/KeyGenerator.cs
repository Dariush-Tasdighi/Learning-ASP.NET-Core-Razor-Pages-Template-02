namespace Dtat.Security
{
	public static class KeyGenerator : object
	{
		static KeyGenerator()
		{
		}

		public static string GenerateVerificationKey(int fixLength = 6)
		{
			string result =
				System.Guid
				.NewGuid().ToString().Replace("-", string.Empty)
				[..fixLength];

			return result;
		}
	}
}
