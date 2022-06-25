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
		public System.DateTime? BirthDate { get; set; }
		// **********

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public string? NationalCode { get; set; }
		// **********

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public Domain.Cms.Account.Enumerations.Gender? Gender { get; set; }
		// **********

		public void OnGet()
		{
		}
	}
}
