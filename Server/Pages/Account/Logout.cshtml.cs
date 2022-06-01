using Microsoft.AspNetCore.Authentication;

namespace Server.Pages.Account
{
	[Microsoft.AspNetCore.Authorization.Authorize]
	public class LogoutModel : Infrastructure.BasePageModel
	{
		public LogoutModel() : base()
		{
		}

		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnGet()
		{
			// SignOutAsync -> using Microsoft.AspNetCore.Authentication;
			await HttpContext.SignOutAsync
				(scheme: Infrastructure.Security.Utility.AuthenticationScheme);

			return RedirectToPage(pageName: "/Index");
		}
	}
}
