namespace Infrastructure.Settings
{
	public class FileManagerSettings : object
	{
		public FileManagerSettings() : base()
		{
			DisplayDateTimeFormat = "yyyy/MM/dd [HH:mm:ss]";

			TableHeaderStyle = "table-primary";
			TableFooterStyle = "table-secondary";
			TableStyle = "table table-bordered table-sm table-striped table-hover";
		}

		public bool DeleteItemsEnabled { get; set; }

		public bool UploadFilesEnabled { get; set; }

		public bool CreateDirectoryEnabled { get; set; }



		public string TableStyle { get; set; }

		public string TableHeaderStyle { get; set; }

		public string TableFooterStyle { get; set; }

		public string DisplayDateTimeFormat { get; set; }
	}
}
