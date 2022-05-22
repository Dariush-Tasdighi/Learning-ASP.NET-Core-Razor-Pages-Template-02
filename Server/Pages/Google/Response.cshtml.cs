using System.Linq;
using Microsoft.AspNetCore.Authentication;

namespace Server.Pages.Google
{
	public class ResponseModel : Infrastructure.BasePageModel
	{
		public ResponseModel()
		{
		}

		public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> OnGet()
		{
			var result =
				// AuthenticateAsync -> using Microsoft.AspNetCore.Authentication;
				await HttpContext.AuthenticateAsync
				(scheme: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);

			if(result != null && result.Principal != null)
			{
				var claims =
					result.Principal.Identities
					// FirstOrDefault -> using System.Linq;
					.FirstOrDefault()?.Claims.Select(claim => new
					{
						claim.Issuer,
						claim.OriginalIssuer,
						claim.Type,
						claim.Value
					});

			}

			return RedirectToPage(pageName: "/Index");
		}
	}
}
