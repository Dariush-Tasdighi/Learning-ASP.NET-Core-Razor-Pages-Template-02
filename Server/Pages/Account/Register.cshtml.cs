namespace Server.Pages.Security
{
	public class RegisterModel : Infrastructure.BasePageModel
	{
		public RegisterModel(Persistence.DatabaseContext databaseContext) : base()
		{
			ViewModel = new();
			DatabaseContext = databaseContext;
		}

		private Persistence.DatabaseContext DatabaseContext { get; }

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

			Domain.Cms.Account.User user = new()
			{
				Username = ViewModel.Username,
				EmailAddress = ViewModel.EmailAddress,
				Password = Dtat.Security.Cryptography.GetSha256(text: ViewModel.Password),
			};

			DatabaseContext.Add(entity: user);

			DatabaseContext.SaveChanges();
		}
	}
}
