using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Server.Pages.Admin.MenuItems;

[Microsoft.AspNetCore.Authorization
	.Authorize(Roles = Constants.Role.Admin)]
public class UpdateModel : Infrastructure.BasePageModelWithDatabaseContext
{
	public UpdateModel
		(Data.DatabaseContext databaseContext,
		Microsoft.Extensions.Logging.ILogger<UpdateModel> logger) :
		base(databaseContext: databaseContext)
	{
		Logger = logger;
		ViewModel = new();
		ParentsViewModel = new
			List<ViewModels.Pages.Admin.MenuItems.GetAccessibleParentViewModel>();
		ParentSelectList = new System.Collections.Generic.List<SelectListItem>();
	}

	// **********
	private Microsoft.Extensions.Logging.ILogger<UpdateModel> Logger { get; }
	// **********

	// **********
	[Microsoft.AspNetCore.Mvc.BindProperty]
	public ViewModels.Pages.Admin.MenuItems.UpdateViewModel ViewModel { get; set; }
	// **********

	// **********
	public System.Collections.Generic.IList
		<ViewModels.Pages.Admin.MenuItems.GetAccessibleParentViewModel>? ParentsViewModel
	{ get; private set; }
	// **********

	// **********
	public System.Collections.Generic.IList
		<SelectListItem> ParentSelectList
	{ get; private set; }
	// **********

	public async System.Threading.Tasks.Task
		<Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(System.Guid? id)
	{
		try
		{
			if (id.HasValue == false)
			{
				AddToastError
					(message: Resources.Messages.Errors.IdIsNull);

				return RedirectToPage(pageName: "Index");
			}

			await SetAccessibleParent();

			SetAccessibleParentToSelectList();

			ViewModel =
				await DatabaseContext.MenuItems
				.Where(current => current.Id == id)
				.Select(current => new ViewModels.Pages.Admin.MenuItems.UpdateViewModel
				{
					Id = current.Id,
					Icon = current.Icon,
					Link = current.Link,
					Title = current.Title,
					Ordering = current.Ordering,
					IsPublic = current.IsPublic,
					IsActive = current.IsActive,
					ParentId = current.ParentId,
					ParentTitle = current.Parent.Title,
					IsUndeletable = current.IsUndeletable,
					IconPosition = current.IconPosition,
				})
				.FirstOrDefaultAsync();

			if (ViewModel == null)
			{
				AddToastError
					(message: Resources.Messages.Errors.ThereIsNotAnyDataWithThisId);

				return RedirectToPage(pageName: "Index");
			}

			return Page();
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

	public async System.Threading.Tasks.Task
		<Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync()
	{
		if (ModelState.IsValid == false)
		{
			return Page();
		}

		try
		{
			// **************************************************
			var foundedItem =
				await
				DatabaseContext.MenuItems
				.Where(current => current.Id == ViewModel.Id)
				.FirstOrDefaultAsync();

			if (foundedItem == null)
			{
				AddToastError
					(message: Resources.Messages.Errors.ThereIsNotAnyDataWithThisId);

				return RedirectToPage(pageName: "Index");
			}
			// **************************************************
			string? fixedTitle =
					Dtat.Utility.FixText
					(text: foundedItem.Title);

			bool foundedAny =
				await
				DatabaseContext.MenuItems
				.Where(current => current.Title.ToLower() == ViewModel.Title.ToLower())
				.Where(current => current.Id != foundedItem.Id)
				.Where(current => current.ParentId == foundedItem.ParentId)
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

			if (ViewModel.ParentId.HasValue)
			{
				// **************************************************
				bool isParent =
					await DatabaseContext.MenuItems
					.Where(current => current.ParentId == foundedItem.Id)
					.AnyAsync();

				if (isParent)
				{
					string errorMesage =
						Resources.Messages.Errors.UnableToUpdateParent;

					AddPageError(message: errorMesage);
					// **************************************************

					return Page();
				}
			}
			// **************************************************

			// **************************************************
			foundedItem.Icon = ViewModel.Icon;
			foundedItem.Title = ViewModel.Title;
			foundedItem.ParentId = ViewModel.ParentId;
			foundedItem.IsPublic = ViewModel.IsPublic;
			foundedItem.IsActive = ViewModel.IsActive;
			foundedItem.Ordering = ViewModel.Ordering;
			foundedItem.IsUndeletable = ViewModel.IsUndeletable;
			foundedItem.IconPosition = ViewModel.IconPosition;
			foundedItem.Link = ViewModel.Link;

			foundedItem.SetUpdateDateTime();
			// **************************************************

			var affectedRows =
				await
				DatabaseContext.SaveChangesAsync();

			// **************************************************
			var successMessage = string.Format
				(Resources.Messages.Successes.Updated,
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
	private async System.Threading.Tasks.Task SetAccessibleParent()
	{
		ParentsViewModel =
			await DatabaseContext.MenuItems
			.Where(current => current.IsDeleted == false)
			.Where(current => current.ParentId == null)
			.OrderBy(current => current.Ordering)
			.Select(current => new ViewModels.Pages.Admin.MenuItems.GetAccessibleParentViewModel
			{
				Id = current.Id,
				Title = current.Title,
			})
			.ToListAsync()
			;
	}

	private void SetAccessibleParentToSelectList()
	{
		foreach (var item in ParentsViewModel)
		{
			ParentSelectList.Add(new SelectListItem
			{
				Text = item.Title,
				Value = item.Id.ToString(),
			});
		}
	}

}
