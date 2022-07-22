using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.MenuItemManager
{
	public class UpdateModel : Infrastructure.BasePageModelWithDatabase
	{
		public UpdateModel
			(Persistence.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<UpdateModel> logger) : base(databaseContext: databaseContext)
		{
			Logger = logger;

			ViewModel = new();
		}

		// **********
		private Microsoft.Extensions.Logging.ILogger<UpdateModel> Logger { get; }
		// **********

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Pages.Admin.MenuItemManager.UpdateMenuItemViewModel ViewModel { get; set; }
		// **********

		// **********
		public System.Collections.Generic.IList
			<ViewModels.Pages.Admin.MenuItemManager.GetAccessibleParentViewModel>? ParentsViewModel
		{ get; private set; }
		// **********

		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(System.Guid id)
		{
			try
			{
				ViewModel =
					await DatabaseContext.MenuItems
					.Where(current => current.Id == id)
					.Select(current => new ViewModels.Pages.Admin.MenuItemManager.UpdateMenuItemViewModel
					{
						Id = current.Id,
						Icon = current.Icon,
						Link = current.Link,
						Title = current.Title,
						Ordering = current.Ordering,
						IsPublic = current.IsPublic,
						IsActive = current.IsActive,
						ParentId = current.ParentId,
						Parent = current.Parent.Title,
						IsUndeletable = current.IsUndeletable,
						IconPosition = current.IconPosition,
					}).FirstOrDefaultAsync();
			}
			catch (System.Exception ex)
			{
				Logger.LogError(message: ex.Message);

				AddToastError(message: Resources.Messages.Errors.UnexpectedError);
			}
			finally
			{
				await SetAccessibleParent(id: id);

				await DisposeDatabaseContextAsync();
			}

			return Page();
		}

		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync(System.Guid id)
		{
			if (ModelState.IsValid == false)
			{
				return Page();
			}

			try
			{
				var foundedItem =
					await DatabaseContext.MenuItems
					.Where(current => current.Id == id)
					.FirstOrDefaultAsync();

				if (foundedItem == null)
				{
					string errorMessage = string.Format
						(Resources.Messages.Errors.NotFound,
						Resources.DataDictionary.MenuItem);

					AddToastError(message: errorMessage);
				}
				else
				{
					string? fixedTitle =
						Infrastructure.Utility.FixText(text: foundedItem.Title);

					bool hasAny =
						await DatabaseContext.MenuItems
						.Where(current => current.Title.ToLower() == ViewModel.Title.ToLower())
						.Where(current => current.Id != foundedItem.Id)
						.Where(current => current.ParentId == foundedItem.ParentId)
						.AnyAsync();

					if (hasAny)
					{
						// **************************************************
						string errorMessage = string.Format
							(Resources.Messages.Errors.AlreadyExists,
							Resources.DataDictionary.Title);
						// **************************************************

						AddPageError(message: errorMessage);

						return Page();
					}

					if (ViewModel.ParentId.HasValue)
					{
						// **************************************************
						bool isParent =
							await DatabaseContext.MenuItems
							.Where(current => current.ParentId == foundedItem.Id)
							.AnyAsync();
						// **************************************************

						if (isParent)
						{
							string errorMesage =
								Resources.Messages.Errors.UnableToUpdateParent;

							AddPageError(message: errorMesage);

							return Page();
						}
					}

					// **************************************************
					foundedItem.Icon = ViewModel.Icon;
					foundedItem.Title = ViewModel.Title;
					foundedItem.ParentId = ViewModel.ParentId;
					foundedItem.IsPublic = ViewModel.IsPublic;
					foundedItem.IsActive = ViewModel.IsActive;
					foundedItem.Ordering = ViewModel.Ordering;
					foundedItem.IsUndeletable = ViewModel.IsUndeletable;
					foundedItem.IconPosition = ViewModel.IconPosition;

					foundedItem.SetUpdateDateTime();
					// **************************************************

					//var entityEntry =
					//	DatabaseContext.Update(entity: foundedItem);

					int affectedRows =
						await DatabaseContext.SaveChangesAsync();

					// **************************************************
					if (affectedRows > 0)
					{
						string successMessage = string.Format
							(Resources.Messages.Successes.SuccessfullyUpdated,
							Resources.DataDictionary.MenuItem);

						AddToastSuccess(message: successMessage);
					}
					// **************************************************
				}

				return RedirectToPage("./Index");
			}
			catch (System.Exception ex)
			{
				Logger.LogError(message: ex.Message);

				//System.Console.WriteLine(value: ex.Message);

				AddToastError(message: Resources.Messages.Errors.UnexpectedError);

				return Page();
			}
			finally
			{
				await SetAccessibleParent(id: id);

				await DisposeDatabaseContextAsync();
			}
		}

		private async System.Threading.Tasks.Task SetAccessibleParent(System.Guid id)
		{
			ParentsViewModel =
				await DatabaseContext.MenuItems
				.Where(current => current.IsDeleted == false)
				.Where(current => current.ParentId == null)
				.Where(current => current.Id != id)
				.OrderBy(current => current.Ordering)
				.Select(current => new ViewModels.Pages.Admin.MenuItemManager.GetAccessibleParentViewModel
				{
					Id = current.Id,
					Title = current.Title,
				})
				.ToListAsync()
				;
		}
	}
}
