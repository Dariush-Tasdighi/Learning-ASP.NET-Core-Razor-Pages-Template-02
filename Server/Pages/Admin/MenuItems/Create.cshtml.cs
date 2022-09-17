using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;


namespace Server.Pages.Admin.MenuItems;

[Microsoft.AspNetCore.Authorization
	.Authorize(Roles = Constants.Role.Admin)]
public class CreateModel : Infrastructure.BasePageModelWithDatabaseContext
{
	public CreateModel
		(Data.DatabaseContext databaseContext,
		Microsoft.Extensions.Logging.ILogger<CreateModel> logger) :
		base(databaseContext: databaseContext)
	{
		Logger = logger;
		ViewModel = new();

		ParentsViewModel = new System.Collections.Generic.List
			<ViewModels.Pages.Admin.MenuItems.GetAccessibleParentViewModel>();
	}

	// **********
	private Microsoft.Extensions.Logging.ILogger<CreateModel> Logger { get; }
	// **********

	// **********
	[Microsoft.AspNetCore.Mvc.BindProperty]
	public ViewModels.Pages.Admin.MenuItems.CreateViewModel ViewModel { get; set; }
	// **********

	// **********
	public System.Collections.Generic.IList
		<ViewModels.Pages.Admin.MenuItems.GetAccessibleParentViewModel> ParentsViewModel
	{ get; private set; }
	// **********

	public Microsoft.AspNetCore.Mvc.IActionResult OnGet()
	{
		return Page();
	}

	public async System.Threading.Tasks.Task
		<Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync()
	{
		try
		{
			if (ModelState.IsValid == false)
			{
				return Page();
			}

			string? fixedTitle =
				Dtat.Utility.FixText(text: ViewModel.Title);

			// **************************************************
			bool foundedAny =
				await DatabaseContext.MenuItems
				.Where(current => current.Title.ToLower() == fixedTitle.ToLower())
				.Where(current => current.ParentId == ViewModel.ParentId)
				.Where(current => current.IsDeleted == false)
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

			Domain.MenuItem newEntity = new(title: fixedTitle)
			{
				Icon = ViewModel.Icon,
				IsPublic = ViewModel.IsPublic,
				IsActive = ViewModel.IsActive,
				Ordering = ViewModel.Ordering,
				ParentId = ViewModel.ParentId,
				IsUndeletable = ViewModel.IsUndeletable,
				IconPosition = ViewModel.IconPosition,
				Link = Dtat.Utility.RemoveSpacesAndMakeTextCaseInsensitive(text: ViewModel.Link),
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
				Resources.DataDictionary.MenuItem);

			AddToastSuccess(message: successMessage);
			// **************************************************

			return RedirectToPage(pageName: "Index");
		}
		catch (System.Exception ex)
		{
			Logger.LogError
				(message: Constants.Logger.ErrorMessage, args: ex.Message);

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
