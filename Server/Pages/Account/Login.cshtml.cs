using Microsoft.AspNetCore.Authentication;

namespace Server.Pages.Security
{
	public class LoginModel : Infrastructure.BasePageModel
	{
		public LoginModel() : base()
		{
			ViewModel = new();
		}

		[Microsoft.AspNetCore.Mvc.BindProperty]
		public string? ReturnUrl { get; set; }

		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Pages.Account.LoginViewModel ViewModel { get; set; }

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

			if (string.Compare(ViewModel.Username, "Dariush", ignoreCase: true) != 0 ||
				string.Compare(ViewModel.Password, "1234512345", ignoreCase: true) != 0)
			{
				AddPageError
					(message: "Wrong username and/or password!");

				return Page();
			}

			await Infrastructure.Security
				.Utility.Login(httpContext: HttpContext, viewModel: ViewModel);

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
