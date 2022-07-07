using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.UserManager
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

			RolesViewModel = new System.Collections.Generic.List
				<ViewModels.Pages.Admin.UserManager.GetAccessibleRolesViewModel>();
		}

		// **********
		private Microsoft.Extensions.Logging.ILogger<UpdateModel> Logger { get; }
		// **********

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Pages.Admin.UserManager.UpdateUserViewModel ViewModel { get; set; }
		// **********

		// **********
		public System.Collections.Generic.IList
			<ViewModels.Pages.Admin.UserManager.GetAccessibleRolesViewModel> RolesViewModel
		{ get; private set; }
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
					ViewModel = await DatabaseContext.Users
						.Where(current => current.Id == id.Value)
						.Select(current => new ViewModels.Pages.Admin.UserManager.UpdateUserViewModel
						{
							Id = current.Id,
							RoleId = current.RoleId,
							Username = current.Username,
							IsActive = current.IsActive,
							IsVerified = current.IsVerified,
						}).FirstOrDefaultAsync();

					await SetAccessibleRole();
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
				var foundedItem =
					await DatabaseContext.Users
					.Where(current => current.Id == id.Value)
					.FirstOrDefaultAsync();

				if (foundedItem == null)
				{
					// **************************************************
					string errorMessage = string.Format
						(Resources.Messages.Errors.NotFound,
						Resources.DataDictionary.User);

					AddToastError(message: errorMessage);
					// **************************************************
				}
				else
				{
					// **************************************************
					foundedItem.RoleId = ViewModel.RoleId;
					foundedItem.IsActive = ViewModel.IsActive;
					foundedItem.IsVerified = foundedItem.IsVerified ? foundedItem.IsVerified : ViewModel.IsVerified;

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
							Resources.DataDictionary.User);

						AddToastSuccess(message: successMessage);
					}
					// **************************************************
				}

				return RedirectToPage("./Index");
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

		private async System.Threading.Tasks.Task SetAccessibleRole()
		{
			RolesViewModel =
				await DatabaseContext.Roles
				.Where(current => current.IsDeleted == false)
				.OrderBy(current => current.Ordering)
				.Select(current => new ViewModels.Pages.Admin.UserManager.GetAccessibleRolesViewModel
				{
					Id = current.Id,
					Name = current.Name,
				})
				.ToListAsync()
				;
		}
	}
}
