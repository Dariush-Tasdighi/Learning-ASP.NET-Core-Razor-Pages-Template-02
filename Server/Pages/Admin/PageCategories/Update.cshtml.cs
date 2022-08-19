using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.PageCategorys
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Infrastructure.Constants.Role.Admin)]
	public class UpdateModel : Infrastructure.BasePageModelWithDatabase
	{
		public UpdateModel
			(Data.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<UpdateModel> logger) :
			base(databaseContext: databaseContext)
		{
			Logger = logger;

			ViewModel = new();
		}

		// **********
		private Microsoft.Extensions.Logging.ILogger<UpdateModel> Logger { get; }
		// **********

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Pages.Admin.PageCategories.UpdateViewModel ViewModel { get; set; }
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

				ViewModel =
					await
					DatabaseContext.PageCategories
					.Where(current => current.Id == id.Value)
					.Select(current => new ViewModels.Pages.Admin.PageCategories.UpdateViewModel()
					{
						Id = current.Id,
						Name = current.Name,
						IsActive = current.IsActive,
						Ordering = current.Ordering,
						Description = current.Description,
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
					await DatabaseContext.PageCategories
					.Where(current => current.Id != ViewModel.Id)
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

				var foundedItem =
					await
					DatabaseContext.PageCategories
					.Where(current => current.Id == ViewModel.Id)
					.FirstOrDefaultAsync();

				if (foundedItem == null)
				{
					AddToastError
						(message: Resources.Messages.Errors.ThereIsNotAnyDataWithThisId);

					return RedirectToPage(pageName: "Index");
				}

				// **************************************************
				var fixedDescription =
					Dtat.Utility.FixText
					(text: ViewModel.Description);

				foundedItem.SetUpdateDateTime();

				foundedItem.Name = fixedName;
				foundedItem.Ordering = ViewModel.Ordering;
				foundedItem.IsActive = ViewModel.IsActive;
				foundedItem.Description = fixedDescription;
				// **************************************************

				var affectedRows =
					await DatabaseContext.SaveChangesAsync();

				// **************************************************
				var successMessage = string.Format
					(Resources.Messages.Successes.Updated,
					Resources.DataDictionary.PageCategory);

				AddToastSuccess(message: successMessage);
				// **************************************************

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
}
