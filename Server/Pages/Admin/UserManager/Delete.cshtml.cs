using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.UserManager
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Infrastructure.Constant.Role.Admin)]
	public class DeleteModel : Infrastructure.BasePageModelWithDatabase
	{
		#region Constructor(s)
		public DeleteModel
			(Data.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<DeleteModel> logger) : base(databaseContext: databaseContext)
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
		public ViewModels.Pages.Admin.UserManager.DeleteUserViewModel ViewModel { get; private set; }
		// **********
		#endregion /Porperty(ies)

		#region OnGet
		public async System.Threading.Tasks.Task OnGetAsync(System.Guid id)
		{
			try
			{
				ViewModel =
					await DatabaseContext.Users
					.Where(current => current.Id == id)
					//.Where(current => current.IsDeleted == false)
					.Select(current => new ViewModels.Pages.Admin.UserManager.DeleteUserViewModel
					{
						Id = current.Id,
						Role = current.Role.Name,
						Username = current.Username,
						IsActive = current.IsActive,
						FullName = current.FullName,
						EmailAddress = current.EmailAddress,
						InsertDateTime = current.InsertDateTime,
						IsEmailAddressVerified = current.IsEmailAddressVerified,
					})
					.FirstOrDefaultAsync();

			}
			catch (System.Exception ex)
			{
				Logger.LogError(message: ex.Message);

				AddToastError(message: Resources.Messages.Errors.UnexpectedError);
			}
			finally
			{
				await DisposeDatabaseContextAsync();
			}
		}
		#endregion /OnGet

		#region OnPost
		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnPostDeleteAsync(System.Guid id)
		{
			try
			{
				var foundedItem =
					await DatabaseContext.Users
					.Where(current => current.Id == id)
					.FirstOrDefaultAsync();

				if (foundedItem == null)
				{
					string errorMessage = string.Format
						(Resources.Messages.Errors.NotFound,
						Resources.DataDictionary.User);

					AddToastError(message: errorMessage);
				}
				// TO DO: Check User Id...
				//else if (foundedItem.RoleId != Domain.Role.UserRoleId)
				//{
				//	string errorMessage = string.Format
				//		(Resources.Messages.Errors.UnableTo,
				//		Resources.DataDictionary.Delete,
				//		Resources.DataDictionary.User);

				//	AddToastError(message: errorMessage);

				//	return RedirectToPage("./Index");
				//}
				else if (foundedItem.IsUndeletable)
				{
					string errorMessage = string.Format
						(Resources.Messages.Errors.UnableTo,
						Resources.DataDictionary.Delete,
						Resources.DataDictionary.User);

					AddToastError(message: errorMessage);
				}
				else
				{
					DatabaseContext.Remove(entity: foundedItem);

					await DatabaseContext.SaveChangesAsync();
				}

				return RedirectToPage("./Index");
			}
			catch (System.Exception ex)
			{
				Logger.LogError(message: ex.Message);

				AddToastError(message: Resources.Messages.Errors.UnexpectedError);
			}
			finally
			{
				await DisposeDatabaseContextAsync();
			}

			return Page();
		}
		#endregion /OnPost
	}
}
