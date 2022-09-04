using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Server.Pages.Admin.MenuItemManager;

[Microsoft.AspNetCore.Authorization.Authorize
    (Roles = Infrastructure.Constants.Role.Admin)]
public class CreateModel : Infrastructure.BasePageModelWithDatabaseContext
{
    public CreateModel
        (Data.DatabaseContext databaseContext,
        Microsoft.Extensions.Logging.ILogger<CreateModel> logger) : base(databaseContext: databaseContext)
    {
        Logger = logger;

        ViewModel = new();

        ParentsViewModel = new System.Collections.Generic.List
            <ViewModels.Pages.Admin.MenuItemManager.GetAccessibleParentViewModel>();
    }

    // **********
    private Microsoft.Extensions.Logging.ILogger<CreateModel> Logger { get; }
    // **********

    // **********
    public string? ReturnUrl { get; set; }
    // **********

    // **********
    [Microsoft.AspNetCore.Mvc.BindProperty]
    public ViewModels.Pages.Admin.MenuItemManager.CreateViewModel ViewModel { get; set; }
    // **********

    // **********
    public System.Collections.Generic.IList
        <ViewModels.Pages.Admin.MenuItemManager.GetAccessibleParentViewModel> ParentsViewModel
    { get; private set; }
    // **********

    public async System.Threading.Tasks.Task OnGetAsync(string? returnUrl)
    {
        ReturnUrl = returnUrl;

        try
        {
            await SetAccessibleParent();
        }
        catch (System.Exception ex)
        {
            Logger.LogError(message: ex.Message);
        }
        finally
        {
            await DisposeDatabaseContextAsync();
        }
    }

    public async System.Threading.Tasks.Task
        <Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync()
    {
        try
        {
            // **************************************************
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            // **************************************************

            string? fixedTitle =
                Dtat.Utility.FixText(text: ViewModel.Title);

            // **************************************************
            bool hasAny =
                await DatabaseContext.MenuItems
                .Where(current => current.Title.ToLower() == fixedTitle.ToLower())
                .Where(current => current.ParentId == ViewModel.ParentId)
                .Where(current => current.IsDeleted == false)
                .AnyAsync();

            if (hasAny)
            {
                string errorMessage = string.Format
                    (Resources.Messages.Errors.AlreadyExists, Resources.DataDictionary.Title);

                AddPageError(message: errorMessage);

                return Page();
            }
            // **************************************************

            Domain.MenuItem menu = new(title: fixedTitle)
            {
                Icon = ViewModel.Icon,
                IsPublic = ViewModel.IsPublic,
                IsActive = ViewModel.IsActive,
                Ordering = ViewModel.Ordering,
                ParentId = ViewModel.ParentId,
                IsUndeletable = ViewModel.IsUndeletable,
                IconPosition = ViewModel.IconPosition,
                Link = Dtat.Utility.RemoveSpacesAndMakeTextCaseInsensitive(text: ViewModel.Link),
            };

            var entityEntry =
                await DatabaseContext.AddAsync(entity: menu);

            int affectedRow =
                await DatabaseContext.SaveChangesAsync();

            // **************************************************
            if (affectedRow > 0)
            {
                string successMessage = string.Format
                    (Resources.Messages.Successes.Created,
                    Resources.DataDictionary.MenuItem);

                AddToastSuccess(message: successMessage);
            }
            // **************************************************
        }
        catch (System.Exception ex)
        {
            Logger.LogError(message: ex.Message);

            //System.Console.WriteLine(value: ex.Message);

            AddToastError(message: Resources.Messages.Errors.UnexpectedError);
        }
        finally
        {
            await SetAccessibleParent();

            await DisposeDatabaseContextAsync();
        }

        if (string.IsNullOrWhiteSpace(value: ReturnUrl))
        {
            return RedirectToPage(pageName: "./Index");
        }
        else
        {
            return Redirect(url: ReturnUrl);
        }
    }

    private async System.Threading.Tasks.Task SetAccessibleParent()
    {
        ParentsViewModel =
            await DatabaseContext.MenuItems
            .Where(current => current.IsDeleted == false)
            .Where(current => current.ParentId == null)
            .OrderBy(current => current.Ordering)
            .Select(current => new ViewModels.Pages.Admin.MenuItemManager.GetAccessibleParentViewModel
            {
                Id = current.Id,
                Title = current.Title,
            })
            .ToListAsync()
            ;
    }
}
