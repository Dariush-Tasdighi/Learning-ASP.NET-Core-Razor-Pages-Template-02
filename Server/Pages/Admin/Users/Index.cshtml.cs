using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.Users;

[Microsoft.AspNetCore.Authorization
	.Authorize(Roles = Constants.Role.Admin)]
public class IndexModel : Infrastructure.BasePageModelWithDatabaseContext
{
	#region Constructor
	public IndexModel
		(Data.DatabaseContext databaseContext,
		Microsoft.Extensions.Logging.ILogger<IndexModel> logger) :
		base(databaseContext: databaseContext)
	{
		Logger = logger;

		ViewModel =
			new System.Collections.Generic.List
			<ViewModels.Pages.Admin.Users.IndexItemViewModel>();
	}
	#endregion /Constructor

	#region Properties
	private Microsoft.Extensions.Logging.ILogger<IndexModel> Logger { get; }

	public System.Collections.Generic.IList
		<ViewModels.Pages.Admin.Users.IndexItemViewModel> ViewModel
	{ get; private set; }
	#endregion /Properties

	#region OnGetAsync
	public async System.Threading.Tasks.Task
		<Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync()
	{
		try
		{
			ViewModel =
				await
				DatabaseContext.Users
				.OrderByDescending(current => current.InsertDateTime)
				.Select(current => new ViewModels.Pages.Admin.Users.IndexItemViewModel
				{
					Id = current.Id,

					IsActive = current.IsActive,
					IsProgrammer = current.IsProgrammer,
					IsUndeletable = current.IsUndeletable,
					IsEmailAddressVerified = current.IsEmailAddressVerified,
					IsVisibleInContactUsPage = current.IsVisibleInContactUsPage,
					IsCellPhoneNumberVerified = current.IsCellPhoneNumberVerified,

					RoleId = current.RoleId,
					RoleName = current.Role.Name,
					IsRoleActive = current.Role.IsActive,

					LastName = current.LastName,
					Username = current.Username,
					FirstName = current.FirstName,
					EmailAddress = current.EmailAddress,
					CellPhoneNumber = current.CellPhoneNumber,

					InsertDateTime = current.InsertDateTime,
					UpdateDateTime = current.UpdateDateTime,
					LastLoginDateTime = current.LastLoginDateTime,
				})
				.ToListAsync()
				;
		}
		catch (System.Exception ex)
		{
			Logger.LogError
				(message: Constants.Logger.ErrorMessage, args: ex.Message);

			AddPageError
				(message: Resources.Messages.Errors.UnexpectedError);
		}
		finally
		{
			await DisposeDatabaseContextAsync();
		}

		return Page();
	}
	#endregion /OnGetAsync
}
