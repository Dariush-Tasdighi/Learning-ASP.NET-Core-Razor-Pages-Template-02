using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.UserManager
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Infrastructure.Constants.Role.Admin)]
	public class DetailsModel : Infrastructure.BasePageModelWithDatabaseContext
	{
		#region Constructor(s)
		public DetailsModel
			(Data.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<DetailsModel> logger) : base(databaseContext: databaseContext)
		{
			Logger = logger;

			ViewModel = new();
		}
		#endregion /Constructor(s)

		#region Property(ies)
		// **********
		private Microsoft.Extensions.Logging.ILogger<DetailsModel> Logger { get; }
		// **********

		// **********
		public ViewModels.Pages.Admin.UserManager.GetUserDetailsViewModel ViewModel { get; private set; }
		// **********
		#endregion /Property(ies)

		#region OnGet
		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(System.Guid id)
		{
			try
			{
				ViewModel =
					await DatabaseContext.Users
					.Where(current => current.Id == id)
					.Select(current => new ViewModels.Pages.Admin.UserManager.GetUserDetailsViewModel
					{
						Role = current.Role.Name,
						Username = current.Username,
						FullName = current.FullName,
						Description = current.Description,
						EmailAddress = current.EmailAddress,
						CellPhoneNumber = current.CellPhoneNumber,
						AdminDescription = current.AdminDescription,

						IsSystemic = current.IsSystemic,
						IsProgrammer = current.IsProgrammer,

						IsActive = current.IsActive,
						IsUndeletable = current.IsUndeletable,

						InsertDateTime = current.InsertDateTime,
						UpdateDateTime = current.UpdateDateTime,

						IsEmailAddressVerified = current.IsEmailAddressVerified,
						IsCellPhoneNumberVerified = current.IsCellPhoneNumberVerified,
					}).FirstOrDefaultAsync();
			}
			catch (System.Exception ex)
			{
				Logger.LogError(message: ex.Message);

				AddPageError(message: Resources.Messages.Errors.UnexpectedError);
			}
			finally
			{
				await DisposeDatabaseContextAsync();
			}

			return Page();
		}
		#endregion /OnGet
	}
}
