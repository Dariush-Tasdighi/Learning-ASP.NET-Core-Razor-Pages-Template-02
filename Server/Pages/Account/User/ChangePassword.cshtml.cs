namespace Server.Pages.Security.User
{
	[Microsoft.AspNetCore.Authorization.Authorize]
	public class ChangePasswordModel : Infrastructure.BasePageModel
	{
		public ChangePasswordModel() : base()
		{
			ViewModel = new();
		}

		[Microsoft.AspNetCore.Mvc.BindProperty]
		protected ViewModels.Pages.Account.Users.ChangePasswordViewModel ViewModel { get; set; }

		public void OnGet()
		{
		}
	}
}
