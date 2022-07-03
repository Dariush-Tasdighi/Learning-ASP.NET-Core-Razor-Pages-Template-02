using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.UserManager
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Domain.SeedWork.Constant.SystemicRole.Admin)]
	public class DetailsModel : Infrastructure.BasePageModelWithDatabase
	{
		public DetailsModel
			(Persistence.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<DetailsModel> logger) : base(databaseContext: databaseContext)
		{
			Logger = logger;
			ViewModel = new();
		}

		// **********
		private Microsoft.Extensions.Logging.ILogger<DetailsModel> Logger { get; }
		// **********

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Pages.Admin.UserManager.GetUserDetailsViewModel ViewModel { get; private set; }
		// **********

		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(System.Guid? id)
		{
			try
			{
				if (id == null)
				{
					string errorMessage = string.Format
						(Resources.Messages.Validations.Required,
						Resources.DataDictionary.Id);

					AddPageError(message: errorMessage);
				}
				else
				{
					ViewModel =
						await DatabaseContext.Users
						.Where(current => current.Id == id.Value)
						.Select(current => new ViewModels.Pages.Admin.UserManager.GetUserDetailsViewModel
						{
							//Id = current.Id,
							Gender = current.Gender,

							Role = current.Role.Name,
							Username = current.Username,
							LastName = current.LastName,
							FirstName = current.FirstName,
							BirthDate = current.BirthDate,
							Description = current.Description,
							NationalCode = current.NationalCode,
							EmailAddress = current.EmailAddress,
							CellPhoneNumber = current.CellPhoneNumber,

							IsActive = current.IsActive,
							IsDeleted = current.IsDeleted,
							IsVerified = current.IsVerified,
							InsertDateTime = current.InsertDateTime,
							UpdateDateTime = current.UpdateDateTime,
							VerifyDateTime = current.VerifyDateTime,

							IsEmailAddressVerified = current.IsEmailAddressVerified,
							IsCellPhoneNumberVerified = current.IsCellPhoneNumberVerified,
						}).FirstOrDefaultAsync();
				}
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
	}
}
