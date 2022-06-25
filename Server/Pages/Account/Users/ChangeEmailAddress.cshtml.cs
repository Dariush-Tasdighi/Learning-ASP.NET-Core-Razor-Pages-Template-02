namespace Server.Pages.Account.Users
{
	public class ChangeEmailAddressModel : Infrastructure.BasePageModel
	{
		public ChangeEmailAddressModel() : base()
		{
			ViewModel = new();
		}

		[Microsoft.AspNetCore.Mvc.BindProperty]
		protected ViewModels.Pages.Account.Users.ChangeEmailAddressViewModel ViewModel { get; set; }

		public void OnGet()
		{
		}
	}
}
