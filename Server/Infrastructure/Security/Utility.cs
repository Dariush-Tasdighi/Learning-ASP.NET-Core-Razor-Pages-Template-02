namespace Infrastructure.Security
{
	public static class Utility
	{
		//public const string AuthenticationScheme = "Cookies";

		public const string AuthenticationScheme =
			Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme;

		static Utility()
		{
		}
	}
}
