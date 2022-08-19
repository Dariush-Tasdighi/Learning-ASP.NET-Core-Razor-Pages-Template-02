using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.Users
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Infrastructure.Constant.Role.Admin)]
	public class DeleteModel : Infrastructure.BasePageModelWithDatabase
	{
		#region Constructor(s)
		public DeleteModel(Data.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<DeleteModel> logger) :
			base(databaseContext: databaseContext)
		{
			Logger = logger;

			ViewModel = new();
		}
		#endregion /Constructor(s)

		#region Porperty(ies)
		// **********
		private Microsoft.Extensions.Logging.ILogger<DeleteModel> Logger { get; }
		// **********

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Pages.Admin.Users.DeleteDetailsViewModel ViewModel { get; private set; }
		// **********
		#endregion /Porperty(ies)

		#region OnGet
		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(System.Guid? id)
		{
			try
			{
				if (id.HasValue == false)
				{
					AddToastError
						(message: Resources.Messages.Errors.IdIsNull);
				}

				ViewModel =
					await
					DatabaseContext.Users
					.Where(current => current.Id == id.Value)
					.Select(current => new ViewModels.Pages.Admin.Users.DeleteDetailsViewModel
					{
						Id = current.Id,
						Role = current.Role.Name,
						IsActive = current.IsActive,
						FullName = current.FullName,
						Ordering = current.Ordering,
						EmailAddress = current.EmailAddress,
						AdminDescription = current.AdminDescription,
						IsEmailAddressVerified = current.IsEmailAddressVerified,
					})
					.FirstOrDefaultAsync();

				if (ViewModel == null)
				{
					AddToastError
						(message: Resources.Messages.Errors.ThereIsNotAnyDataWithThisId);
				}
			}
			catch (System.Exception ex)
			{
				Logger.LogError
					(message: Domain.SeedWork.Constants.Logger.ErrorMessage, args: ex.Message);

				AddPageError
					(message: Resources.Messages.Errors.UnexpectedError);
			}
			finally
			{
				await DisposeDatabaseContextAsync();
			}

			return Page();
		}
		#endregion /OnGet

		#region OnPost
		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return Page();
			}

			try
			{
				var foundedItem =
					await
					DatabaseContext.Users
					.Where(current => current.Id == id)
					.FirstOrDefaultAsync();

				if (foundedItem == null)
				{
					AddToastError
						(message: Resources.Messages.Errors.ThereIsNotAnyDataWithThisId);

					return RedirectToPage(pageName: "Index");
				}

				// TO DO: Check User Id (and maybe User Role)
				if (foundedItem.IsProgrammer)
				{
					// **************************************************
					string errorMessage = string.Format
						(Resources.Messages.Errors.UnableTo,
						Resources.ButtonCaptions.Delete,
						Resources.DataDictionary.User);

					AddToastError(message: errorMessage);
					// **************************************************

					return RedirectToPage(pageName: "Index");
				}

				if (foundedItem.IsUndeletable)
				{
					// **************************************************
					string errorMessage = string.Format
						(Resources.Messages.Errors.UnableTo,
						Resources.ButtonCaptions.Delete,
						Resources.DataDictionary.User);

					AddToastError(message: errorMessage);
					// **************************************************

					return RedirectToPage(pageName: "Index");
				}

				DatabaseContext.Remove(entity: foundedItem);

				await DatabaseContext.SaveChangesAsync();

				// **************************************************
				string successMessage = string.Format
					(Resources.Messages.Successes.Deleted,
					Resources.DataDictionary.Role);

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
		#endregion /OnPost
	}
}
