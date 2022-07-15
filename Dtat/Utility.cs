namespace Dtat
{
	public static class Utility : object
	{
		static Utility()
		{
		}

		public static System.DateTime Now
		{
			get
			{
				var currentCulture =
					System.Threading.Thread.CurrentThread.CurrentCulture;

				var currentUICulture =
					System.Threading.Thread.CurrentThread.CurrentUICulture;

				var englishCulture =
					new System.Globalization.CultureInfo(name: "en-US");

				System.Threading.Thread.CurrentThread.CurrentCulture = englishCulture;
				System.Threading.Thread.CurrentThread.CurrentUICulture = englishCulture;

				var result =
					System.DateTime.Now;

				//var result =
				//	System.DateTime.Now.AddMinutes(value: 210);

				System.Threading.Thread.CurrentThread.CurrentCulture = currentCulture;
				System.Threading.Thread.CurrentThread.CurrentUICulture = currentUICulture;

				return result;
			}
		}
	}
}
