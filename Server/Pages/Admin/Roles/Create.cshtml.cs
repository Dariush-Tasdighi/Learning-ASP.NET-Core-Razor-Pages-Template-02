using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.Roles;

[Microsoft.AspNetCore.Authorization.Authorize
	(Roles = Infrastructure.Constants.Role.Admin)]
public class CreateModel : Infrastructure.BasePageModelWithDatabaseContext
{
	public CreateModel(Data.DatabaseContext databaseContext,
		Microsoft.Extensions.Logging.ILogger<CreateModel> logger) :
		base(databaseContext: databaseContext)
	{
		Logger = logger;
		ViewModel = new();
	}

	// **********
	private Microsoft.Extensions.Logging.ILogger<CreateModel> Logger { get; }
	// **********

	// **********
	[Microsoft.AspNetCore.Mvc.BindProperty]
	public ViewModels.Pages.Admin.Roles.CreateViewModel ViewModel { get; set; }
	// **********

	public Microsoft.AspNetCore.Mvc.IActionResult OnGet()
	{
		// Note: If you want to change default value!
		//ViewModel.Ordering = 100;

		return Page();
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
			var fixedName =
				Dtat.Utility.FixText
				(text: ViewModel.Name);

			var foundedAny =
				await
				DatabaseContext.Roles
				.Where(current => current.Name.ToLower() == fixedName.ToLower())
				.AnyAsync();

			if (foundedAny)
			{
				// **************************************************
				var errorMessage = string.Format
					(Resources.Messages.Errors.AlreadyExists,
					Resources.DataDictionary.Name);

				AddPageError(message: errorMessage);
				// **************************************************

				return Page();
			}

			// **************************************************
			var fixedDescription =
				Dtat.Utility.FixText
				(text: ViewModel.Description);

			var newEntity =
				new Domain.Role(name: fixedName)
				{
					Ordering = ViewModel.Ordering,
					IsActive = ViewModel.IsActive,
					Description = fixedDescription,
				};

			var entityEntry =
				await
				DatabaseContext.AddAsync(entity: newEntity);

			var affectedRows =
				await
				DatabaseContext.SaveChangesAsync();
			// **************************************************

			// **************************************************
			var successMessage = string.Format
				(Resources.Messages.Successes.Created,
				Resources.DataDictionary.Role);

			AddToastSuccess(message: successMessage);
			// **************************************************

			//return RedirectToPage(pageName: "./Index");

			return RedirectToPage(pageName: "Index");
		}
		catch (System.Exception ex)
		{
			Logger.LogError
				(message: Domain.SeedWork.Constants.Logger.ErrorMessage, args: ex.Message);

			AddToastError
				(message: Resources.Messages.Errors.UnexpectedError);

			return RedirectToPage(pageName: "Index");
		}
		finally
		{
			await DisposeDatabaseContextAsync();
		}
	}
}
