using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.RoleManager
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Domain.SeedWork.Constant.SystemicRole.Admin)]
	public class UpdateModel : Infrastructure.BasePageModelWithDatabase
	{
		public UpdateModel
			(Persistence.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<UpdateModel> logger) : base(databaseContext: databaseContext)
		{
			Logger = logger;

			ViewModel = new();
		}

		// **********
		private Microsoft.Extensions.Logging.ILogger<UpdateModel> Logger { get; }
		// **********

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Pages.Admin.RoleManager.UpdateRoleViewModel ViewModel { get; set; }
		// **********

		public async
			System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult>
			OnGetAsync(System.Guid? id)
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
						await DatabaseContext.Roles
						.Where(current => current.Id == id.Value)
						.Select(current => new ViewModels.Pages.Admin.RoleManager.UpdateRoleViewModel
						{
							Id = current.Id,
							Name = current.Name,
							IsActive = current.IsActive,
							Ordering = current.Ordering,
							Description = current.Description,
							IsDeletable = current.IsDeletable,
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

		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync(System.Guid? id)
		{
			if (id == null)
			{
				return Page();
			}
			else if (ModelState.IsValid is false)
			{
				return Page();
			}

			try
			{
				string? fixedName =
					Infrastructure.Utility.FixText(text: ViewModel.Name);

				bool foundAny =
					await DatabaseContext.Roles
					.Where(current => current.Name.ToLower() == fixedName.ToLower())
					.Where(current => current.Id != id.Value)
					.Where(current => current.IsDeleted == false)
					.AnyAsync();

				if (foundAny)
				{
					// **************************************************
					string errorMessage = string.Format
						(Resources.Messages.Errors.AlreadyExists,
						Resources.DataDictionary.Name);

					AddToastError(message: errorMessage);

					return Page();
					// **************************************************
				}
				else
				{
					var foundedItem =
						await DatabaseContext.Roles
						.Where(current => current.Id == id.Value)
						.FirstOrDefaultAsync();

					// **************************************************
					foundedItem.Name = fixedName;
					foundedItem.Ordering = ViewModel.Ordering;
					foundedItem.IsActive = ViewModel.IsActive;
					foundedItem.IsDeletable = ViewModel.IsDeletable;
					foundedItem.Description = Infrastructure.Utility.FixText(text: ViewModel.Description);

					foundedItem.SetUpdateDateTime();
					// **************************************************

					var entityEntry =
						DatabaseContext.Update(entity: foundedItem);

					int affectedRows =
						await DatabaseContext.SaveChangesAsync();

					// **************************************************
					if (affectedRows > 0)
					{
						string successMessage = string.Format
							(Resources.Messages.Successes.SuccessfullyUpdated,
							Resources.DataDictionary.Role);

						AddToastSuccess(message: successMessage);
					}
					// **************************************************

					return RedirectToPage(pageName: "Index");
				}
			}
			catch (System.Exception ex)
			{
				Logger.LogError(message: ex.Message);

				//System.Console.WriteLine(value: ex.Message);

				AddToastError(message: Resources.Messages.Errors.UnexpectedError);

				return Page();
			}
			finally
			{
				await DisposeDatabaseContextAsync();
			}
		}
	}
}
