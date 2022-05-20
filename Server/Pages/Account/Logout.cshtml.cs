namespace Server.Pages.Account
{
	public class LogoutModel : Infrastructure.BasePageModel
	{
		public LogoutModel() : base()
		{
		}

		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnGet()
		{
			await Infrastructure.Security.Utility.Logout(httpContext: HttpContext);

			return RedirectToPage(pageName: "/Index");
		}
	}
}
