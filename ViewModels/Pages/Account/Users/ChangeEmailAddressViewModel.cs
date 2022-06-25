namespace ViewModels.Pages.Account.Users
{
	public class ChangeEmailAddressViewModel : object
	{
		public ChangeEmailAddressViewModel() : base()
		{
		}

		public string? CurrentEmailAddress { get; set; }

		public string? NewEmailAddress { get; set; }
	}
}
