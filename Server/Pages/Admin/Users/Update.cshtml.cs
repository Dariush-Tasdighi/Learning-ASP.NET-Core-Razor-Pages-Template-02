using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.Users;

[Microsoft.AspNetCore.Authorization
	.Authorize(Roles = Constants.Role.Admin)]
public class UpdateModel : Infrastructure.BasePageModelWithDatabaseContext
{
	#region Constructor
	public UpdateModel(Data.DatabaseContext databaseContext,
		Microsoft.Extensions.Logging.ILogger<UpdateModel> logger) :
		base(databaseContext: databaseContext)
	{
		Logger = logger;
		ViewModel = new();
	}
	#endregion /Constructor

	#region Properties
	private Microsoft.Extensions.Logging.ILogger<UpdateModel> Logger { get; }

	[Microsoft.AspNetCore.Mvc.BindProperty]
	public ViewModels.Pages.Admin.Users.UpdateViewModel ViewModel { get; set; }

	public Microsoft.AspNetCore.Mvc.Rendering.SelectList? RolesSelectList { get; set; }
	#endregion /Properties

	#region Methods

	#region OnGetAsync
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
				DatabaseContext.Users
				.Where(current => current.Id == id.Value)
				.Select(current => new ViewModels.Pages.Admin.Users.UpdateViewModel
				{
					Id = current.Id,

					RoleId = current.RoleId,

					Ordering = current.Ordering,

					IsActive = current.IsActive,
					IsProgrammer = current.IsProgrammer,
					IsProfilePublic = current.IsProfilePublic,
					IsEmailAddressVerified = current.IsEmailAddressVerified,
					IsVisibleInContactUsPage = current.IsVisibleInContactUsPage,
					IsCellPhoneNumberVerified = current.IsCellPhoneNumberVerified,

					LastName = current.LastName,
					Username = current.Username,
					FirstName = current.FirstName,
					Description = current.Description,
					EmailAddress = current.EmailAddress,
					CellPhoneNumber = current.CellPhoneNumber,
					AdminDescription = current.AdminDescription,
					TitleInContactUsPage = current.TitleInContactUsPage,
				})
				.FirstOrDefaultAsync();

			if (ViewModel == null)
			{
				AddToastError
					(message: Resources.Messages.Errors.ThereIsNotAnyDataWithThisId);

				return RedirectToPage(pageName: "Index");
			}

			RolesSelectList =
				await
				Infrastructure.SelectLists.GetRolesAsync
				(databaseContext: DatabaseContext, selectedValue: null);

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
	#endregion /OnGetAsync

	#region OnPostAsync
	public async System.Threading.Tasks.Task
		<Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync()
	{
		try
		{
			RolesSelectList =
				await
				Infrastructure.SelectLists.GetRolesAsync
				(databaseContext: DatabaseContext, selectedValue: ViewModel.RoleId);

			if (ModelState.IsValid == false)
			{
				return Page();
			}

			// **************************************************
			var fixedEmailAddress =
				Dtat.Utility.FixText
				(text: ViewModel.EmailAddress);

			var foundedAny =
				await
				DatabaseContext.Users
				.Where(current => current.Id != ViewModel.Id)
				.Where(current => current.EmailAddress.ToLower() == fixedEmailAddress.ToLower())
				.AnyAsync();

			if (foundedAny)
			{
				var key =
					$"{nameof(ViewModel)}.{nameof(ViewModel.EmailAddress)}";

				var errorMessage = string.Format
					(format: Resources.Messages.Errors.AlreadyExists,
					arg0: Resources.DataDictionary.EmailAddress);

				ModelState.AddModelError
					(key: key, errorMessage: errorMessage);
			}
			// **************************************************

			// **************************************************
			var fixedUsername =
				Dtat.Utility.FixText
				(text: ViewModel.Username);

			if (fixedUsername != null)
			{
				foundedAny =
					await
					DatabaseContext.Users
					.Where(current => current.Id != ViewModel.Id)
					.Where(current => current.Username.ToLower() == fixedUsername.ToLower())
					.AnyAsync();

				if (foundedAny)
				{
					var key =
						$"{nameof(ViewModel)}.{nameof(ViewModel.Username)}";

					var errorMessage = string.Format
						(format: Resources.Messages.Errors.AlreadyExists,
						arg0: Resources.DataDictionary.Username);

					ModelState.AddModelError
						(key: key, errorMessage: errorMessage);
				}
			}
			// **************************************************

			// **************************************************
			var fixedCellPhoneNumber =
				Dtat.Utility.FixText
				(text: ViewModel.CellPhoneNumber);

			if (fixedCellPhoneNumber != null)
			{
				foundedAny =
					await
					DatabaseContext.Users
					.Where(current => current.Id != ViewModel.Id)
					.Where(current => current.CellPhoneNumber == fixedCellPhoneNumber)
					.AnyAsync();

				if (foundedAny)
				{
					var key =
						$"{nameof(ViewModel)}.{nameof(ViewModel.CellPhoneNumber)}";

					var errorMessage = string.Format
						(format: Resources.Messages.Errors.AlreadyExists,
						arg0: Resources.DataDictionary.CellPhoneNumber);

					ModelState.AddModelError
						(key: key, errorMessage: errorMessage);
				}
			}
			// **************************************************

			if (ModelState.IsValid == false)
			{
				return Page();
			}

			// **************************************************
			var foundedItem =
				await DatabaseContext.Users
				.Where(current => current.Id == ViewModel.Id)
				.FirstOrDefaultAsync();

			if (foundedItem == null)
			{
				AddToastError
					(message: Resources.Messages.Errors.ThereIsNotAnyDataWithThisId);

				return RedirectToPage(pageName: "Index");
			}
			// **************************************************

			// **************************************************
			var fixedFirstName =
				Dtat.Utility.FixText
				(text: ViewModel.FirstName);

			var fixedLastName =
				Dtat.Utility.FixText
				(text: ViewModel.LastName);

			var fixedDescription =
				Dtat.Utility.FixText
				(text: ViewModel.Description);

			var fixedAdminDescription =
				Dtat.Utility.FixText
				(text: ViewModel.AdminDescription);

			var fixedTitleInContactUsPage =
				Dtat.Utility.FixText
				(text: ViewModel.TitleInContactUsPage);

			foundedItem.RoleId = ViewModel.RoleId;

			foundedItem.Ordering = ViewModel.Ordering;

			foundedItem.IsActive = ViewModel.IsActive;
			foundedItem.IsProgrammer = ViewModel.IsProgrammer;
			foundedItem.IsProfilePublic = ViewModel.IsProfilePublic;
			foundedItem.IsEmailAddressVerified = ViewModel.IsEmailAddressVerified;
			foundedItem.IsVisibleInContactUsPage = ViewModel.IsVisibleInContactUsPage;
			foundedItem.IsCellPhoneNumberVerified = ViewModel.IsCellPhoneNumberVerified;

			foundedItem.LastName = fixedLastName;
			foundedItem.Username = fixedUsername;
			foundedItem.FirstName = fixedFirstName;
			foundedItem.Description = fixedDescription;
			foundedItem.EmailAddress = fixedEmailAddress;
			foundedItem.CellPhoneNumber = fixedCellPhoneNumber;
			foundedItem.AdminDescription = fixedAdminDescription;
			foundedItem.TitleInContactUsPage = fixedTitleInContactUsPage;

			foundedItem.SetUpdateDateTime();

			var affectedRows =
				await
				DatabaseContext.SaveChangesAsync();
			// **************************************************

			// **************************************************
			var successMessage = string.Format
				(format: Resources.Messages.Successes.Updated,
				arg0: Resources.DataDictionary.User);

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
			//await SetAccessibleRoleAsync()

			await DisposeDatabaseContextAsync();
		}
	}
	#endregion /OnPostAsync

	#endregion /Methods
}
