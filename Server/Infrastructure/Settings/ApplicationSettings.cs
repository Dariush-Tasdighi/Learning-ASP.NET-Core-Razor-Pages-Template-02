namespace Infrastructure.Settings
{
	public class ApplicationSettings : object
	{
		public static readonly string KeyName = nameof(ApplicationSettings);

		public ApplicationSettings() : base()
		{
		}

		public string? ActivationKey { get; set; }

		public CultureSettings? CultureSettings { get; set; }
	}
}
