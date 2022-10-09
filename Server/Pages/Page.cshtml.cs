using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages;

public class PageModel : Infrastructure.BasePageModelWithDatabaseContext
{
	#region Constructor
	public PageModel
		(Data.DatabaseContext databaseContext,
		Microsoft.Extensions.Logging.ILogger<PageModel> logger) :
		base(databaseContext: databaseContext)
	{
		Logger = logger;
	}
	#endregion /Constructor

	#region Properties
	private Domain.Page ViewModel { get; }

	private Microsoft.Extensions.Logging.ILogger<PageModel> Logger { get; }
	#endregion /Properties

	#region OnGetAsync
	public async System.Threading.Tasks.Task
		<Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(string? name)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(value: name))
			{
				// TODO: ParameterIsNull
				AddToastError
					(message: Resources.Messages.Errors.IdIsNull);

				return RedirectToPage(pageName: "Index");
			}

			var viewmodel =
				await
				DatabaseContext.Pages
				.Where(current => current.Title == name.ToLower())
				.FirstOrDefaultAsync();

			if (viewmodel == null)
			{
				// TODO: PageNotFound
				AddToastError
					(message: Resources.Messages.Errors.IdIsNull);

				return RedirectToPage(pageName: "Index");
			}

			return Page();
		}
		catch (System.Exception ex)
		{
			Logger.LogError
				(message: Constants.Logger.ErrorMessage, args: ex.Message);

			AddToastError
				(message: Resources.Messages.Errors.UnexpectedError);

			return RedirectToPage(pageName: "Index");
		}
		finally
		{
			await DisposeDatabaseContextAsync();
		}
	}
	#endregion /OnGetAsync
}
