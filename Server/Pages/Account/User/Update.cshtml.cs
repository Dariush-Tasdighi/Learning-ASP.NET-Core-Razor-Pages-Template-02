using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Security.User
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

		public async System.Threading.Tasks.Task OnGetAsync()
		{
			// TODO: Read User Id...

			System.Guid? userId = new System.Guid(); // Replace it with Real Id!

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
						// ViewModel.Role = foundedUser.Role,
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
				//AddPageError(message: Resources.Messages.Errors.AccessDenied);
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
