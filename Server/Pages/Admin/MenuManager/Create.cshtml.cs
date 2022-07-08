using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.MenuManager
{
	public class CreateModel : Infrastructure.BasePageModelWithDatabase
	{
		public CreateModel
			(Persistence.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<CreateModel> logger) : base(databaseContext: databaseContext)
		{
			Logger = logger;

			ViewModel = new();

			ParentsViewModel = new System.Collections.Generic.List
				<ViewModels.Pages.Admin.MenuManager.GetAccessibleParentMenuViewModel>();
		}

		// **********
		private Microsoft.Extensions.Logging.ILogger<CreateModel> Logger { get; }
		// **********

		// **********
		public string? ReturnUrl { get; set; }
		// **********

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Pages.Admin.MenuManager.CreateMenuItemViewModel ViewModel { get; set; }
		// **********

		// **********
		public System.Collections.Generic.IList
			<ViewModels.Pages.Admin.MenuManager.GetAccessibleParentMenuViewModel> ParentsViewModel
		{ get; private set; }
		// **********

		public async System.Threading.Tasks.Task OnGetAsync(string? returnUrl)
		{
			ReturnUrl = returnUrl;

			try
			{
				await SetAccessibleParent();
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
			try
			{
				// **************************************************
				if (ModelState.IsValid == false)
				{
					return Page();
				}
				// **************************************************

				string? fixedTitle = Infrastructure.Utility.FixText(text: ViewModel.Title);

				// **************************************************
				bool hasAny =
					await DatabaseContext.Menus
					.Where(current => current.Title.ToLower() == fixedTitle.ToLower())
					.Where(current => current.ParentId == ViewModel.ParentId)
					.Where(current => current.IsDeleted == false)
					.AnyAsync();

				if (hasAny)
				{
					string errorMessage = string.Format
						(Resources.Messages.Errors.AlreadyExists, Resources.DataDictionary.Title);

					AddPageError(message: errorMessage);

					return Page();
				}
				// **************************************************

				Domain.Models.Menus.Menu menu = new()
				{
					Title = fixedTitle,
					Icon = ViewModel.Icon,
					IsPublic = ViewModel.IsPublic,
					IsActive = ViewModel.IsActive,
					Ordering = ViewModel.Ordering,
					ParentId = ViewModel.ParentId,
					IsDeletable = ViewModel.IsDeletable,
					IconPosition = ViewModel.IconPosition,
					Link = Infrastructure.Utility.RemoveSpacesAndMakeTextCaseInsensitive(text: ViewModel.Link),
				};

				var entityEntry =
					await DatabaseContext.AddAsync(entity: menu);

				int affectedRow =
					await DatabaseContext.SaveChangesAsync();

				// **************************************************
				if (affectedRow > 0)
				{
					string successMessage = string.Format
						(Resources.Messages.Successes.SuccessfullyCreated,
						Resources.DataDictionary.Menu);

					AddToastSuccess(message: successMessage);
				}
				// **************************************************
			}
			catch (System.Exception ex)
			{
				Logger.LogError(message: ex.Message);

				//System.Console.WriteLine(value: ex.Message);

				AddToastError(message: Resources.Messages.Errors.UnexpectedError);
			}
			finally
			{
				await SetAccessibleParent();

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

		private async System.Threading.Tasks.Task SetAccessibleParent()
		{
			ParentsViewModel =
				await DatabaseContext.Menus
				.Where(current => current.IsDeleted == false)
				.Where(current => current.ParentId == null)
				.OrderBy(current => current.Ordering)
				.Select(current => new ViewModels.Pages.Admin.MenuManager.GetAccessibleParentMenuViewModel
				{
					Id = current.Id,
					Title = current.Title,
				})
				.ToListAsync()
				;
		}
	}
}
