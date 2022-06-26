using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.UserManagement
{
	public class UpdateModel : Infrastructure.BasePageModelWithDatabase
	{
		public UpdateModel
			(Persistence.DatabaseContext databaseContext) : base(databaseContext: databaseContext)
		{
			ViewModel = new();
		}

		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Pages.Admin.UserManagement.UpdateUserViewModel ViewModel { get; set; }

		public async System.Threading.Tasks.Task OnGetAsync(System.Guid? userId)
		{
			if (userId.HasValue)
			{
				if (DatabaseContext is not null)
				{
					var foundedUser =
						await DatabaseContext.Users
						.Where(current => current.Id == userId)
						.FirstOrDefaultAsync();

					if (foundedUser is not null)
					{
						ViewModel.Gender = foundedUser.Gender;
						ViewModel.IsActive = foundedUser.IsActive;
						ViewModel.IsVerified = foundedUser.IsVerified;

						ViewModel.Username = foundedUser.Username;
						ViewModel.LastName = foundedUser.LastName;
						ViewModel.FirstName = foundedUser.FirstName;

						ViewModel.BirthDate = foundedUser.BirthDate;
						ViewModel.EmailAddress = foundedUser.EmailAddress;
						ViewModel.CellPhoneNumber = foundedUser.CellPhoneNumber;
					}
				}
			}
			else
			{
				// TODO: Read From Json File!
				AddPageError(message: "شناسه کاربری معتبر نمی باشد!");
			}
		}


		public async
			System.Threading.Tasks.Task OnPostAsync()
		{
			if (ModelState.IsValid == false)
			{
				return;
			}

			// **************************************************
			string? fixedUsername = Infrastructure.Utility
				.RemoveSpacesAndMakeTextCaseInsensitive(text: ViewModel.Username);

			string? fixedEmailAddress = Infrastructure.Utility
				.RemoveSpacesAndMakeTextCaseInsensitive(text: ViewModel.EmailAddress);
			// **************************************************

			try
			{
				// TO DO
			}
			catch (System.Exception ex)
			{
				// TODO:
				// Logger.LogError(message: ex.Message);

				System.Console.WriteLine(value: ex.Message);

				AddPageError(message: Resources.Messages.Errors.UnexpectedError);
			}
			finally
			{
				if (DatabaseContext is not null)
				{
					await DatabaseContext.DisposeAsync();

					DatabaseContext = null;
				}
			}

			return;
		}
	}
}
