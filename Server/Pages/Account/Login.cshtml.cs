using Microsoft.AspNetCore.Authentication;

namespace Server.Pages.Security
{
	public class LoginModel : Infrastructure.BasePageModel
	{
		public LoginModel
			(Infrastructure.Settings.ApplicationSettings applicationSettings) : base()
		{
			ViewModel = new();
			ApplicationSettings = applicationSettings;
		}

		[Microsoft.AspNetCore.Mvc.BindProperty]
		public string? ReturnUrl { get; set; }

		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Pages.Account.LoginViewModel ViewModel { get; set; }

		public Infrastructure.Settings.ApplicationSettings ApplicationSettings { get; }

		public void OnGet(string? returnUrl)
		{
			ReturnUrl = returnUrl;
		}

		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync()
		{
			if (ModelState.IsValid == false)
			{
				return Page();
			}

			// **************************************************
			//if (string.Compare(ViewModel.Username, "Dariush", ignoreCase: true) != 0 ||
			//	string.Compare(ViewModel.Password, "1234512345", ignoreCase: true) != 0)
			//{
			//	AddPageError
			//		(message: "Wrong username and/or password!");

			//	return Page();
			//}
			// **************************************************

			// **************************************************
			if (string.Compare(strA: ViewModel.Username, strB: "Dariush", ignoreCase: true) != 0)
			{
				AddPageError(message:
					Resources.Messages.Errors.InvalidUsernameOrPassword);

				return Page();
			}

			string? passwordHash =
				Dtat.Security.Hashing
				.GetSha256(text: ViewModel.Password);

			if (string.IsNullOrWhiteSpace(value: passwordHash))
			{
				AddPageError(message:
					Resources.Messages.Errors.InvalidUsernameOrPassword);

				return Page();
			}

			if (string.Compare(passwordHash,
				ApplicationSettings.MasterPassword, ignoreCase: true) != 0)
			{
				AddPageError(message:
					Resources.Messages.Errors.InvalidUsernameOrPassword);

				return Page();
			}
			// **************************************************

			// **************************************************
			// TODO
			// ApplicationSettings: MasterPassword
			// **************************************************

			// **************************************************
			// **************************************************
			// **************************************************
			var claims =
				new System.Collections.Generic
				.List<System.Security.Claims.Claim>();

			System.Security.Claims.Claim claim;

			// **************************************************
			claim =
				new System.Security.Claims.Claim
				(type: "FullName", value: "Mr. Dariush Tasdighi");

			claims.Add(item: claim);
			// **************************************************

			// **************************************************
			//claim =
			//	new System.Security.Claims.Claim
			//	(type: "Role", value: "Admin");

			claim =
				new System.Security.Claims.Claim
				(type: System.Security.Claims.ClaimTypes.Role, value: "Admin");

			claims.Add(item: claim);
			// **************************************************

			// **************************************************
			//claim =
			//	new System.Security.Claims.Claim
			//	(type: "Username", value: "Dariush");

			claim =
				new System.Security.Claims.Claim
				(type: System.Security.Claims.ClaimTypes.Name, value: "Dariush");

			claims.Add(item: claim);
			// **************************************************

			// **************************************************
			claim =
				new System.Security.Claims.Claim
				(type: System.Security.Claims.ClaimTypes.Email, value: "DariushT@GMail.com");

			claims.Add(item: claim);
			// **************************************************
			// **************************************************
			// **************************************************

			// **************************************************
			// **************************************************
			// **************************************************
			var claimsIdentity =
				new System.Security.Claims.ClaimsIdentity(claims: claims,
				authenticationType: Infrastructure.Security.Utility.AuthenticationScheme);
			// **************************************************
			// **************************************************
			// **************************************************

			// **************************************************
			// **************************************************
			// **************************************************
			//var claimsPrincipal =
			//	new System.Security.Claims.ClaimsPrincipal();

			//claimsPrincipal.AddIdentity(identity: claimsIdentity);

			var claimsPrincipal =
				new System.Security.Claims.ClaimsPrincipal(identity: claimsIdentity);
			// **************************************************
			// **************************************************
			// **************************************************

			// **************************************************
			// **************************************************
			// **************************************************
			var authenticationProperties =
				new Microsoft.AspNetCore.Authentication.AuthenticationProperties
				{
					IsPersistent = ViewModel.RememberMe,
				};
			// **************************************************
			// **************************************************
			// **************************************************

			// **************************************************
			// **************************************************
			// **************************************************
			// SignInAsync -> using Microsoft.AspNetCore.Authentication;
			await HttpContext.SignInAsync
				(scheme: Infrastructure.Security.Utility.AuthenticationScheme,
				principal: claimsPrincipal, properties: authenticationProperties);
			// **************************************************
			// **************************************************
			// **************************************************

			if (string.IsNullOrWhiteSpace(ReturnUrl))
			{
				return RedirectToPage(pageName: "/Index");
			}
			else
			{
				return Redirect(url: ReturnUrl);
			}
		}
	}
}
