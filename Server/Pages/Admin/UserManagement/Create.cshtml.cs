using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.UserManagement
{
	public class CreateModel : Infrastructure.BasePageModelWithDatabase
	{
		public CreateModel
			(Persistence.DatabaseContext databaseContext) : base(databaseContext: databaseContext)
		{
			ViewModel = new();
		}

		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Pages.Admin.UserManagement.CreateUserViewModel ViewModel { get; set; }

		public void OnGet()
		{
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
				if (DatabaseContext is not null)
				{
					bool isUsernameFound =
						await DatabaseContext.Users
						.Where(current => current.Username == fixedUsername)
						.AnyAsync();

					bool isEmailAddressFound =
						await DatabaseContext.Users
						.Where(current => current.EmailAddress == fixedEmailAddress)
						.Where(current => current.IsEmailAddressVerified.HasValue && current.IsEmailAddressVerified.Value)
						.Where(current => current.IsDeleted == false)
						.AnyAsync();

					// **************************************************
					if (isUsernameFound)
					{
						string errorMessage = string.Format
							(Resources.Messages.Errors.AlreadyExists, Resources.DataDictionary.Username);

						AddPageError(message: errorMessage);
					}

					if (isEmailAddressFound)
					{
						string errorMessage = string.Format
							(Resources.Messages.Errors.AlreadyExists, Resources.DataDictionary.EmailAddress);

						AddPageError(message: errorMessage);
					}
					// **************************************************

					if (isUsernameFound || isEmailAddressFound)
					{
						return;
					}

					// **************************************************
					if (string.IsNullOrWhiteSpace(value: ViewModel.EmailAddress) == false)
					{
						ViewModel.IsEmailAddressVerified = true;
					}

					if (string.IsNullOrWhiteSpace(value: ViewModel.CellPhoneNumber) == false)
					{
						ViewModel.IsCellPhoneNumberVerified = true;
					}
					// **************************************************

					// **************************************************
					Domain.Cms.Account.User user = new()
					{
						//Role = ViewModel.Role,
						Gender = ViewModel.Gender,
						IsActive = ViewModel.IsActive,

						IsVerified = ViewModel.IsVerified,
						VerifyDateTime = Domain.SeedWork.Utility.Now,
						IsEmailAddressVerified = ViewModel.IsEmailAddressVerified,
						IsCellPhoneNumberVerified = ViewModel.IsCellPhoneNumberVerified,

						Username = fixedUsername,
						EmailAddress = fixedEmailAddress,
						CellPhoneNumber = ViewModel.CellPhoneNumber,
						LastName = Infrastructure.Utility.FixText(text: ViewModel.LastName),
						FirstName = Infrastructure.Utility.FixText(text: ViewModel.FirstName),
						Password = Dtat.Security.Cryptography.GetSha256(text: ViewModel.Password),
					};

					await DatabaseContext.AddAsync(entity: user);

					await DatabaseContext.SaveChangesAsync();
					// **************************************************

					// TODO: Read From Resource File
					AddToastSuccess(message: "اطلاعات کاربر با موفقیت در این سامانه ثبت شد...");
				}
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
