using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.PageManager
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Domain.SeedWork.Constant.SystemicRole.Admin)]
	public class CreateModel : Infrastructure.BasePageModelWithDatabase
	{
		public CreateModel
			(Persistence.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<CreateModel> logger) : base(databaseContext: databaseContext)
		{
			Logger = logger;
		}

		// **********
		private Microsoft.Extensions.Logging.ILogger<CreateModel> Logger { get; }
		// **********

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public string? ReturnUrl { get; set; }
		// **********


		public async System.Threading.Tasks.Task OnGetAsync(string? returnUrl)
		{
			ReturnUrl = returnUrl;

			try
			{
			}
			catch (System.Exception ex)
			{
				Logger.LogError(message: ex.Message);
			}
			finally
			{
				await DisposeDatabaseContextAsync();
			}
		}

		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync()
		{
			if (ModelState.IsValid == false)
			{
				return Page();
			}

			try
			{
				if (ModelState.IsValid is false)
				{
					return Page();
				}
			}
			catch (System.Exception ex)
			{
				Logger.LogError(message: ex.Message);

				//System.Console.WriteLine(value: ex.Message);

				AddPageError(message: Resources.Messages.Errors.UnexpectedError);
			}
			finally
			{
				await DisposeDatabaseContextAsync();
			}

			if (string.IsNullOrWhiteSpace(value: ReturnUrl))
			{
				return RedirectToPage(pageName: "./Index");
			}
			else
			{
				return Redirect(url: ReturnUrl);
			}
		}
	}
}
