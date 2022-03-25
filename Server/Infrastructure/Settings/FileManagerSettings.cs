namespace Infrastructure.Settings
{
	public class FileManagerSettings : object
	{
		public FileManagerSettings() : base()
		{
		}

		public bool DeleteItemsEnabled { get; set; }

		public bool UploadFilesEnabled { get; set; }

		public bool CreateDirectoryEnabled { get; set; }
	}
}
