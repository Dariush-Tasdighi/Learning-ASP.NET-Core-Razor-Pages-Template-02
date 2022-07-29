using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.RoleManager
{
	[Microsoft.AspNetCore.Authorization.Authorize]
	//[Microsoft.AspNetCore.Authorization.Authorize
	//	(Roles = Infrastructure.Constant.Role.Admin)]
	public class UpdateModel : Infrastructure.BasePageModelWithDatabase
	{
		public UpdateModel
			(Data.DatabaseContext databaseContext,
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

		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnGetAsync(System.Guid id)
		{
			try
			{
				ViewModel =
					await DatabaseContext.Roles
					.Where(current => current.Id == id)
					.Select(current => new ViewModels.Pages.Admin.RoleManager.UpdateRoleViewModel
					{
						Id = current.Id,
						Name = current.Name,
						IsActive = current.IsActive,
						Ordering = current.Ordering,
						Description = current.Description,
						IsUndeletable = current.IsUndeletable,
					}).FirstOrDefaultAsync();
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
			<Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync(System.Guid id)
		{
			if (ModelState.IsValid is false)
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
					.Where(current => current.Id != id)
					//.Where(current => current.IsDeleted == false)
					.AnyAsync();

				if (foundAny)
				{
					// **************************************************
					string errorMessage = string.Format
						(Resources.Messages.Errors.AlreadyExists,
						Resources.DataDictionary.Name);
					// **************************************************

					AddToastError(message: errorMessage);

					return Page();
				}
				else
				{
					var foundedItem =
						await DatabaseContext.Roles
						.Where(current => current.Id == id)
						.FirstOrDefaultAsync();

					// **************************************************
					foundedItem.SetUpdateDateTime();

					foundedItem.Name = fixedName;
					foundedItem.Ordering = ViewModel.Ordering;
					foundedItem.IsActive = ViewModel.IsActive;
					foundedItem.IsUndeletable = ViewModel.IsUndeletable;
					foundedItem.Description = Infrastructure.Utility.FixText(text: ViewModel.Description);
					// **************************************************

					//var entityEntry =
					//	DatabaseContext.Update(entity: foundedItem);

					int affectedRows =
						await DatabaseContext.SaveChangesAsync();

					// **************************************************
					string successMessage = string.Format
						(Resources.Messages.Successes.SuccessfullyUpdated,
						Resources.DataDictionary.Role);

					AddToastSuccess(message: successMessage);
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
