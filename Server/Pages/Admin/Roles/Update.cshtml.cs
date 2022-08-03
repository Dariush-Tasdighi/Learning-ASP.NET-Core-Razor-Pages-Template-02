using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.Roles
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Infrastructure.Constant.Role.Admin)]
	public class UpdateModel : Infrastructure.BasePageModelWithDatabase
	{
		public UpdateModel
			(Data.DatabaseContext databaseContext,
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
		public ViewModels.Pages.Admin.Roles.UpdateViewModel ViewModel { get; set; }
		// **********

		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(System.Guid? id)
		{
			try
			{
				if (id.HasValue == false)
				{
					AddToastError(message:
						Resources.Messages.Errors.IdIsNull);

					return RedirectToPage(pageName: "Index");
				}

				ViewModel =
					await
					DatabaseContext.Roles
					.Where(current => current.Id == id.Value)
					.Select(current => new ViewModels.Pages.Admin.Roles.UpdateViewModel()
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
					AddToastError(message:
						Resources.Messages.Errors.ThereIsNotAnyDataWithThisId);
				}
			}
			catch (System.Exception ex)
			{
				Logger.Log(logLevel: Microsoft.Extensions
					.Logging.LogLevel.Error, message: ex.Message);

				AddPageError(message:
					Resources.Messages.Errors.UnexpectedError);
			}
			finally
			{
				await DisposeDatabaseContextAsync();
			}

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
					Dtat.Utility.FixText(text: ViewModel.Name);

				var foundedAny =
					await DatabaseContext.Roles
					.Where(current => current.Id != ViewModel.Id)
					.Where(current => current.Name.ToLower() == fixedName.ToLower())
					.AnyAsync();

				if (foundedAny)
				{
					string errorMessage = string.Format
						(Resources.Messages.Errors.AlreadyExists,
						Resources.DataDictionary.Name);

					AddToastError(message: errorMessage);

					return Page();
				}

				var foundedItem =
					await
					DatabaseContext.Roles
					.Where(current => current.Id == ViewModel.Id)
					.FirstOrDefaultAsync();

				if (foundedItem == null)
				{
					AddToastError(message:
						Resources.Messages.Errors.ThereIsNotAnyDataWithThisId);
				}

				// **************************************************
				var fixedDescription =
					Dtat.Utility.FixText(text: ViewModel.Description);

				foundedItem.SetUpdateDateTime();

				foundedItem.Name = fixedName;
				foundedItem.Ordering = ViewModel.Ordering;
				foundedItem.IsActive = ViewModel.IsActive;
				foundedItem.Description = fixedDescription;
				// **************************************************

				int affectedRows =
					await DatabaseContext.SaveChangesAsync();

				// **************************************************
				string successMessage = string.Format
					(Resources.Messages.Successes.Updated,
					Resources.DataDictionary.Role);

				AddToastSuccess(message: successMessage);
				// **************************************************

				return RedirectToPage(pageName: "Index");
			}
			catch (System.Exception ex)
			{
				Logger.Log(logLevel: Microsoft.Extensions
					.Logging.LogLevel.Error, message: ex.Message);

				AddPageError(message:
					Resources.Messages.Errors.UnexpectedError);

				return Page();
			}
			finally
			{
				await DisposeDatabaseContextAsync();
			}
		}
	}
}
