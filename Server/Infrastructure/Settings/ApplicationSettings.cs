namespace Infrastructure.Settings
{
	public class ApplicationSettings : object
	{
		public static readonly string KeyName = nameof(ApplicationSettings);

		public ApplicationSettings() : base()
		{
			IconSettings =
				new IconSettings();

			ToastSettings =
				new ToastSettings();

			CultureSettings =
				new CultureSettings();

			FileManagerSettings =
				new FileManagerSettings();

			TablesDefaultSettings =
				new TablesDefaultSettings();
		}

		// **********
		public string? Version { get; set; }
		// **********

		// **********
		public string? MasterPassword { get; set; }
		// **********

		// **********
		public string[]? ActivationKeys { get; set; }
		// **********

		// **********
		public IconSettings IconSettings { get; set; }
		// **********

		// **********
		public ToastSettings ToastSettings { get; set; }
		// **********

		// **********
		public CultureSettings CultureSettings { get; set; }
		// **********

		// **********
		public FileManagerSettings FileManagerSettings { get; set; }
		// **********

		// **********
		public TablesDefaultSettings TablesDefaultSettings { get; set; }
		// **********
	}
}
