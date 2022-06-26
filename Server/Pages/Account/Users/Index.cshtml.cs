namespace Server.Pages.Account.Users
{
	public class IndexModel : Infrastructure.BasePageModel
	{
		public IndexModel() : base()
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
			await System.Threading.Tasks.Task.CompletedTask;
		}

		public async
			System.Threading.Tasks.Task OnPostEditUsernameAsync()
		{
			await System.Threading.Tasks.Task.CompletedTask;
		}
		
		public async
			System.Threading.Tasks.Task OnPostEditBirthDateAsync()
		{
			await System.Threading.Tasks.Task.CompletedTask;
		}

		public async
			System.Threading.Tasks.Task OnPostEditFullNameAsync()
		{
			await System.Threading.Tasks.Task.CompletedTask;
		}

		public async
			System.Threading.Tasks.Task OnPostEditDescriptionAsync()
		{
			await System.Threading.Tasks.Task.CompletedTask;
		}

		public async
			System.Threading.Tasks.Task OnPostEditNationalCodeAsync()
		{
			await System.Threading.Tasks.Task.CompletedTask;
		}
	}
}
