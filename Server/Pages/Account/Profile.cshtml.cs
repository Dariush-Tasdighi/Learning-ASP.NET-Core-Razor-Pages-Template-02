namespace Server.Pages.Account
{
	[Microsoft.AspNetCore.Authorization.Authorize]
	public class ProfileModel : Infrastructure.BasePageModel
	{
		public ProfileModel() : base()
		{
		}

		public void OnGet()
		{
		}
	}
}
