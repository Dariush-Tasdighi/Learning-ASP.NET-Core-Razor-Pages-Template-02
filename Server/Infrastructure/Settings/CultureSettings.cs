namespace Infrastructure.Settings
{
	public class CultureSettings : object
	{
		public CultureSettings() : base()
		{
		}

		// **********
		public string? DefaultCultureName { get; set; }
		// **********

		// **********
		public string[]? SupportedCultureNames { get; set; }
		// **********
	}
}
