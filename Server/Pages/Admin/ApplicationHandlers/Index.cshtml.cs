using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.ApplicationHandlers;


[Microsoft.AspNetCore.Authorization
	.Authorize(Roles = Constants.Role.Admin)]
public class IndexModel : Infrastructure.BasePageModelWithDatabaseContext
{
	public IndexModel
		(Data.DatabaseContext databaseContext,
		Microsoft.Extensions.Logging.ILogger<IndexModel> logger) :
		base(databaseContext: databaseContext)
	{
		Logger = logger;

		ViewModel =
			new System.Collections.Generic.List
			<ViewModels.Pages.Admin.ApplicationHandlers.IndexItemViewModel>();
	}

	// **********
	private Microsoft.Extensions.Logging.ILogger<IndexModel> Logger { get; }
	// **********

	// **********
	public System.Collections.Generic.IList
		<ViewModels.Pages.Admin.ApplicationHandlers.IndexItemViewModel> ViewModel
	{ get; private set; }
	// **********

	public async System.Threading.Tasks.Task
		<Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync()
	{
		try
		{
			bool foundAny =
				await
				DatabaseContext.ApplicationHandlers
				.AnyAsync();

			if (foundAny == false)
			{
				await OnPostAsync();
			}

			ViewModel =
				await
				DatabaseContext.ApplicationHandlers
				.OrderBy(current => current.Ordering)
				.ThenBy(current => current.Name)
				.ThenBy(current => current.Title)
				.Select(current => new ViewModels.Pages.Admin.ApplicationHandlers.IndexItemViewModel
				{
					Id = current.Id,
					Name = current.Name,
					Path = current.Path,
					Title = current.Title,
					IsActive = current.IsActive,
					Ordering = current.Ordering,
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

	public async System.Threading.Tasks.Task
		<Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync()
	{
		try
		{
			var handlers =
				Infrastructure.RouteFinder.Find();

			if (handlers.Any())
			{
				foreach (var item in handlers)
				{
					bool foundAny =
						await
						DatabaseContext.ApplicationHandlers
						.Where(current => current.Name.ToLower().Trim() == item.Name.ToLower().Trim())
						.Where(current => current.Path.ToLower().Trim() == item.Path.ToLower().Trim())
						.AnyAsync();

					if (foundAny == false)
					{
						var newEntity =
							new Domain.ApplicationHandler(name: item.Name, path: item.Path)
							{
								Title = item.Title,
								Ordering = item.Ordering,
								IsActive = item.IsActive,
								AccessType = item.AccessType,
								Description = item.Description,
							};

						await DatabaseContext.AddAsync(entity: newEntity);

						await DatabaseContext.SaveChangesAsync();
					}
				}
			}
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

		return RedirectToPage(pageName: "Index");
	}
}
