namespace Infrastructure.Settings
{
	public class ApplicationSettings : object
	{
		public static readonly string KeyName = nameof(ApplicationSettings);

		public ApplicationSettings() : base()
		{
		}

		public string? Version { get; set; }

		public string[]? ActivationKeys { get; set; }

		public CultureSettings? CultureSettings { get; set; }

		public FileManagerSettings? FileManagerSettings { get; set; }
	}
}
