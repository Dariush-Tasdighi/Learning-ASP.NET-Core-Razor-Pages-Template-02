namespace Server.Pages.Security.User
{
	[Microsoft.AspNetCore.Authorization.Authorize]
	public class ChangeCellPhoneNumberModel : Infrastructure.BasePageModel
	{
		public ChangeCellPhoneNumberModel() : base()
		{
			ViewModel = new();
		}

		[Microsoft.AspNetCore.Mvc.BindProperty]
		protected ViewModels.Pages.Account.Users.ChangeCellPhoneNumberViewModel ViewModel { get; set; }

		public void OnGet()
		{
		}
	}
}
