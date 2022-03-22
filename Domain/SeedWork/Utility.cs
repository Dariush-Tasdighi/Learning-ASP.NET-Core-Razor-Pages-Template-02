namespace Domain.SeedWork
{
	public static class Utility
	{
		static Utility()
		{
		}

		public static System.DateTime Now
		{
			get
			{
				//var result =
				//	System.DateTime.UtcNow;

				var result =
					System.DateTime.Now;

				return result;
			}
		}

		//public static string FixIP(string ip)
		//{
		//	if (string.IsNullOrWhiteSpace(ip))
		//	{
		//		return null;
		//	}

		//	ip =
		//		ip
		//		.Trim()
		//		.Replace(":", ".")
		//		;

		//	string[] parts = ip.Split('.');

		//	if (parts.Length != 4)
		//	{
		//		return null;
		//	}

		//	string result = string.Empty;

		//	for (int index = 0; index <= parts.Length - 1; index++)
		//	{
		//		result +=
		//			parts[index].PadLeft(totalWidth: 3, '0');

		//		if (index != parts.Length - 1)
		//		{
		//			result += ".";
		//		}
		//	}

		//	return result;
		//}
	}
}
