namespace Infrastructure.Settings
{
	public class UserManagementSettings : object
{
	public UserManagementSettings() : base()
	{
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
}
}
