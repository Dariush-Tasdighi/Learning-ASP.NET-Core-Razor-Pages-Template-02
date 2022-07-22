using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Security
{
	public class RegisterModel : Infrastructure.BasePageModelWithDatabase
	{
		public RegisterModel
			(Persistence.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<RegisterModel> logger) : base(databaseContext: databaseContext)
		{
			Logger = logger;
			ViewModel = new();
		}

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Pages.Account.RegisterViewModel ViewModel { get; set; }
		// **********

		// **********
		private Microsoft.Extensions.Logging.ILogger<RegisterModel> Logger { get; }
		// **********

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
			//string? fixedUsername = Infrastructure.Utility
			//	.RemoveSpacesAndMakeTextCaseInsensitive(text: ViewModel.Username);

			//string? fixedEmailAddress = Infrastructure.Utility
			//	.RemoveSpacesAndMakeTextCaseInsensitive(text: ViewModel.EmailAddress);
			// **************************************************

			try
			{
				//bool isUsernameFound =
				//	await DatabaseContext.Users
				//	.Where(current => current.Username == fixedUsername)
				//	.AnyAsync();

				//bool isEmailAddressFound =
				//	await DatabaseContext.Users
				//	.Where(current => current.EmailAddress == fixedEmailAddress)
				//	.Where(current => current.IsEmailAddressVerified.HasValue && current.IsEmailAddressVerified.Value)
				//	.Where(current => current.IsDeleted == false)
				//	.AnyAsync();

				//// **************************************************
				//if (isUsernameFound)
				//{
				//	string errorMessage = string.Format
				//		(Resources.Messages.Errors.AlreadyExists, Resources.DataDictionary.Username);

				//	AddPageError(message: errorMessage);
				//}

				//if (isEmailAddressFound)
				//{
				//	string errorMessage = string.Format
				//		(Resources.Messages.Errors.AlreadyExists, Resources.DataDictionary.EmailAddress);

				//	AddPageError(message: errorMessage);
				//}
				//// **************************************************

				//if (isUsernameFound || isEmailAddressFound)
				//{
				//	return;
				//}

				//// **************************************************
				//Domain.User user = new()
				//{
				//	Username = fixedUsername,
				//	//RoleId = DefaultRoleId,
				//	EmailAddress = fixedEmailAddress,
				//	Password = Dtat.Security.Cryptography.GetSha256(text: ViewModel.Password),
				//};

				//await DatabaseContext.AddAsync(entity: user);

				//await DatabaseContext.SaveChangesAsync();
				// **************************************************

				AddToastSuccess(message: "اطلاعات شما با موفقیت در این سامانه ثبت شد...");

				// **************************************************
				// TODO: Send Verification Key To User Email Address
				// **************************************************
			}
			catch (System.Exception ex)
			{
				Logger.LogError(message: ex.Message);

				//System.Console.WriteLine(value: ex.Message);

				AddPageError(message: Resources.Messages.Errors.UnexpectedError);
			}
			finally
			{
				await DisposeDatabaseContextAsync();
			}

			return;
		}
	}
}
