using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Server.Pages.Admin.MenuItemManager;

[Microsoft.AspNetCore.Authorization.Authorize
        (Roles = Infrastructure.Constants.Role.Admin)]
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
            <ViewModels.Pages.Admin.MenuItemManager.IndexItemViewModel>();
    }

    // **********
    [Microsoft.AspNetCore.Mvc.BindProperty]
    public System.Guid? ParentId { get; set; }
    // **********

    // **********
    private Microsoft.Extensions.Logging.ILogger<IndexModel> Logger { get; }
    // **********

    // **********
    public System.Collections.Generic.IList
        <ViewModels.Pages.Admin.MenuItemManager.IndexItemViewModel> ViewModel
    { get; private set; }
    // **********

    public async System.Threading.Tasks.Task
            <Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(System.Guid? id = null)
    {
        try
        {
            ParentId = id;

            ViewModel =
                await
                DatabaseContext.MenuItems
                .Where(x => x.ParentId == ParentId)
                .OrderBy(current => current.Ordering)
                .ThenBy(current => current.Title)
                .Select(current => new ViewModels.Pages.Admin.MenuItemManager.IndexItemViewModel
                {
                    Id = current.Id,
                    Icon = current.Icon,
                    Title = current.Title,
                    IsActive = current.IsActive,
                    IsPublic = current.IsPublic,
                    Ordering = current.Ordering,
                    IsDeleted = current.IsDeleted,
                    IsUndeletable = current.IsUndeletable,
                    HasAnySubMenu = current.SubMenus.Any(),
                    InsertDateTime = current.InsertDateTime,
                    UpdateDateTime = current.UpdateDateTime,
                })
                .ToListAsync()
                ;
        }
        catch (System.Exception ex)
        {
            Logger.LogError
                (message: Domain.SeedWork.Constants
                .Logger.ErrorMessage, args: ex.Message);

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
