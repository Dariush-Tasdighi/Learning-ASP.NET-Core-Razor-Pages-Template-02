using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.PageCategories;

[Microsoft.AspNetCore.Authorization
	.Authorize(Roles = Constants.Role.Admin)]
public class IndexModel : Infrastructure.BasePageModelWithDatabaseContext
{
	#region Constructor(s)
	public IndexModel
		(Data.DatabaseContext databaseContext,
		Microsoft.Extensions.Logging.ILogger<IndexModel> logger) :
		base(databaseContext: databaseContext)
	{
		Logger = logger;

		ViewModel =
			new System.Collections.Generic.List
			<ViewModels.Pages.Admin.PageCategories.IndexItemViewModel>();
	}
	#endregion /Constructor(s)

	// **********
	private Microsoft.Extensions.Logging.ILogger<IndexModel> Logger { get; }
	// **********

	// **********
	public System.Collections.Generic.IList
		<ViewModels.Pages.Admin.PageCategories.IndexItemViewModel> ViewModel
	{ get; private set; }
	// **********

	public async System.Threading.Tasks.Task
		<Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync()
	{
		try
		{
			ViewModel =
				await
				DatabaseContext.PageCategories
				.OrderBy(current => current.Ordering)
				.ThenBy(current => current.Name)
				.Select(current => new ViewModels.Pages.Admin.PageCategories.IndexItemViewModel
				{
					Id = current.Id,
					Name = current.Name,
					IsActive = current.IsActive,
					Ordering = current.Ordering,
					PageCount = current.Pages.Count,
					InsertDateTime = current.InsertDateTime,
					UpdateDateTime = current.UpdateDateTime,
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
}
