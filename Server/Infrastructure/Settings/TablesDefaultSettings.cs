namespace Infrastructure.Settings
{
	public class TablesDefaultSettings : object
	{
		public TablesDefaultSettings() : base()
		{
			//PageSize = 10;

			DisplayDateTimeFormat = "yyyy/MM/dd [HH:mm:ss]";

			TableHeaderStyle = "table-primary";
			TableFooterStyle = "table-secondary";
			TableStyle = "table table-bordered table-sm table-striped table-hover";
		}

		// **********
		public string TableStyle { get; set; }
		// **********

		// **********
		public string TableHeaderStyle { get; set; }
		// **********

		// **********
		public string TableFooterStyle { get; set; }
		// **********

		// **********
		public string DisplayDateTimeFormat { get; set; }
		// **********

		// **********
		public string? NoIcon { get; set; }
		// **********

		// **********
		public string? YesIcon { get; set; }
		// **********

		// **********
		public string? NextPageIcon { get; set; }
		// **********

		// **********
		public string? PreviousPageIcon { get; set; }
		// **********

		// **********
		//public int? PageSize { get; set; }
		// **********
	}
}
