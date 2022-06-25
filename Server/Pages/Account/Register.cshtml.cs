using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Security
{
	public class RegisterModel : Infrastructure.BasePageModel
	{
		public RegisterModel(Persistence.DatabaseContext databaseContext) : base()
		{
			ViewModel = new();
			DatabaseContext = databaseContext;
		}

		private Persistence.DatabaseContext? DatabaseContext { get; set; }

		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Pages.Account.RegisterViewModel ViewModel { get; set; }

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
					Domain.Cms.Account.User user = new()
					{
						Username = fixedUsername,
						EmailAddress = fixedEmailAddress,
						Password = Dtat.Security.Cryptography.GetSha256(text: ViewModel.Password),
					};

					await DatabaseContext.AddAsync(entity: user);

					await DatabaseContext.SaveChangesAsync();
					// **************************************************

					// TODO: Read From Resource File
					AddToastSuccess(message: "اطلاعات شما با موفقیت در این سامانه ثبت شد...");

					// **************************************************
					// TODO: Send Verification Key To User Email Address
					// **************************************************
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
