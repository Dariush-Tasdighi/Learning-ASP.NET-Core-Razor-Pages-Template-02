namespace Server.Pages.Account.Users
{
	public class IndexModel : Infrastructure.BasePageModelWithDatabase
	{
		public IndexModel
			(Persistence.DatabaseContext databaseContext) : base(databaseContext: databaseContext)
		{
		}

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public string? Username { get; set; }
		// **********

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public string? FirstName { get; set; }

		[Microsoft.AspNetCore.Mvc.BindProperty]
		public string? LastName { get; set; }
		// **********

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public string? Description { get; set; }
		// **********

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public string? NationalCode { get; set; }
		// **********

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public System.DateTime? BirthDate { get; set; }
		// **********

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public Domain.Cms.Account.Enumerations.Gender? Gender { get; set; }
		// **********

		public void OnGet()
		{
		}

		public async
			System.Threading.Tasks.Task OnPostEditGenderAsync()
		{
			// TO DO:
			await System.Threading.Tasks.Task.CompletedTask;
		}

		public async
			System.Threading.Tasks.Task OnPostEditUsernameAsync()
		{
			// TO DO:
			await System.Threading.Tasks.Task.CompletedTask;
		}
		
		public async
			System.Threading.Tasks.Task OnPostEditBirthDateAsync()
		{
			// TO DO:
			await System.Threading.Tasks.Task.CompletedTask;
		}

		public async
			System.Threading.Tasks.Task OnPostEditFullNameAsync()
		{
			// TO DO:
			await System.Threading.Tasks.Task.CompletedTask;
		}

		public async
			System.Threading.Tasks.Task OnPostEditDescriptionAsync()
		{
			// TO DO:
			await System.Threading.Tasks.Task.CompletedTask;
		}

		public async
			System.Threading.Tasks.Task OnPostEditNationalCodeAsync()
		{
			// TO DO:
			await System.Threading.Tasks.Task.CompletedTask;
		}
	}
}
