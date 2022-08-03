using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.Roles
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Infrastructure.Constant.Role.Admin)]
	public class DeleteModel : Infrastructure.BasePageModelWithDatabase
	{
		public DeleteModel
			(Data.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<DetailsModel> logger) :
			base(databaseContext: databaseContext)
		{
			Logger = logger;

			ViewModel = new();
		}

		// **********
		private Microsoft.Extensions.Logging.ILogger<DetailsModel> Logger { get; }
		// **********

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Pages.Admin.Roles.DeleteDetailsViewModel ViewModel { get; private set; }
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
				}

				ViewModel =
					await
					DatabaseContext.Roles
					.Where(current => current.Id == id.Value)
					.Select(current => new ViewModels.Pages.Admin.Roles.DeleteDetailsViewModel()
					{
						Id = current.Id,
						Name = current.Name,
						IsActive = current.IsActive,
						Ordering = current.Ordering,
						UserCount = current.Users.Count,
						Description = current.Description,
						InsertDateTime = current.InsertDateTime,
						UpdateDateTime = current.UpdateDateTime,
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
			<Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync(System.Guid? id)
		{
			try
			{
				if (id.HasValue == false)
				{
					return Page();
				}

				var foundedAny =
					await DatabaseContext.Users
					.Where(current => current.RoleId != ViewModel.Id)
					.AnyAsync();

				if (foundedAny)
				{
					string errorMessage = string.Format
						(Resources.Messages.Errors.CascadeDelete,
						Resources.DataDictionary.Role);

					AddPageError(message: errorMessage);

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

					return RedirectToPage("Index");
				}

				// **************************************************
				DatabaseContext.Remove(entity: foundedItem);

				await DatabaseContext.SaveChangesAsync();

				// **************************************************
				string successMessage =
					string.Format
					(Resources.Messages.Successes.Deleted,
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
