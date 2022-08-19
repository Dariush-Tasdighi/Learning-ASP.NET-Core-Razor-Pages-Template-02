using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.Users
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Infrastructure.Constant.Role.Admin)]
	public class IndexModel : Infrastructure.BasePageModelWithDatabase
	{
		#region Constructor(s)
		public IndexModel(Data.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<IndexModel> logger) :
			base(databaseContext: databaseContext)
		{
			Logger = logger;

			ViewModel =
				new System.Collections.Generic.List
				<ViewModels.Pages.Admin.Users.IndexItemViewModel>();
		}
		#endregion /Constructor(s)

		#region Property(ies)
		// **********
		private Microsoft.Extensions.Logging.ILogger<IndexModel> Logger { get; }
		// **********

		// **********
		public System.Collections.Generic.IList
			<ViewModels.Pages.Admin.Users.IndexItemViewModel> ViewModel
		{ get; private set; }
		// **********
		#endregion /Property(ies)

		#region OnGet
		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync()
		{
			try
			{
				ViewModel =
					await
					DatabaseContext.Users
					.OrderBy(current => current.Ordering)
					//.ThenBy(current => current.EmailAddress)
					.Select(current => new ViewModels.Pages.Admin.Users.IndexItemViewModel
					{
						Id = current.Id,
						Role = current.Role.Name,
						Ordering = current.Ordering,
						IsActive = current.IsActive,
						IsSystemic = current.IsSystemic,
						IsProgrammer = current.IsProgrammer,
						EmailAddress = current.EmailAddress,
						IsUndeletable = current.IsUndeletable,
						InsertDateTime = current.InsertDateTime,
						UpdateDateTime = current.UpdateDateTime,
						IsEmailAddressVerified = current.IsEmailAddressVerified,
						LastLoginDateTime = current.UserLogins.Max(current => current.InsertDateTime),
					})
					//.AsNoTracking()
					.ToListAsync()
					;
			}
			catch (System.Exception ex)
			{
				Logger.LogError
					(message: Domain.SeedWork.Constants.Logger.ErrorMessage, args: ex.Message);

				AddPageError
					(message: Resources.Messages.Errors.UnexpectedError);
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
