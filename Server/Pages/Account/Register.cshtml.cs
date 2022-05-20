namespace Server.Pages.Security
{
	public class RegisterModel : Infrastructure.BasePageModel
	{
		public RegisterModel() : base()
		{
			ViewModel = new();
		}

		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Pages.Account.RegisterViewModel ViewModel { get; set; }

		public void OnGet()
		{
		}

		public void OnPost()
		{
			if (ModelState.IsValid == false)
			{
				return;
			}
		}
	}
}
