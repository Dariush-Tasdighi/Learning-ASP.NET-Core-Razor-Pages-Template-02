using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Server.Pages.Admin.UserManager
{
	public class DeleteModel : Infrastructure.BasePageModelWithDatabase
	{
		public DeleteModel
			(Persistence.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<DeleteModel> logger) : base(databaseContext: databaseContext)
		{
			Logger = logger;

			ViewModel = new();
		}

		private Microsoft.Extensions.Logging.ILogger<DeleteModel> Logger { get; }

		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Pages.Admin.UserManager.DeleteUserViewModel ViewModel { get; set; }

		public async System.Threading.Tasks.Task OnGetAsync(System.Guid? id)
		{
			{
				try
				{
					if (id.HasValue)
					{
						ViewModel =
							await DatabaseContext.Users
							.Where(current => current.Id == id.Value)
							//.Where(current => current.IsDeleted == false)
							.Select(current => new ViewModels.Pages.Admin.UserManager.DeleteUserViewModel
							{
								Id = current.Id,
								Role = current.Role.Name,
								Username = current.Username,
								IsActive = current.IsActive,
								LastName = current.LastName,
								FirstName = current.FirstName,
								InsertDateTime = current.InsertDateTime,
							})
							.FirstOrDefaultAsync();
					}
				}
				catch (System.Exception ex)
				{
					Logger.LogError(message: ex.Message);

					AddToastError(message: Resources.Messages.Errors.UnexpectedError);
				}
				finally
				{
					await DisposeDatabaseContextAsync();
				}
			}
		}

		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnPostDeleteAsync(System.Guid? id)
		{
			try
			{
				if (id.HasValue)
				{
					var foundedItem =
						await DatabaseContext.Users
						.Where(current => current.Id == id.Value)
						.Where(current => current.IsDeleted == false)
						.FirstOrDefaultAsync();

					if (foundedItem == null)
					{
						string errorMessage = string.Format
							(Resources.Messages.Errors.NotFound,
							Resources.DataDictionary.User);

						AddToastError(message: errorMessage);

						return RedirectToPage("./Index");
					}
					// TO DO: Check User Id...
					else if (foundedItem.RoleId != Domain.SeedWork.Constant.SystemicRole.UserRoleId)
					{
						string errorMessage = string.Format
							(Resources.Messages.Errors.UnableTo,
							Resources.DataDictionary.Delete,
							Resources.DataDictionary.User);

						AddToastError(message: errorMessage);

						return RedirectToPage("./Index");
					}
					else
					{
						//foundedItem.IsActive = false;
						foundedItem.IsDeleted = true;

						DatabaseContext.Users.Update(entity: foundedItem);

						await DatabaseContext.SaveChangesAsync();

						return RedirectToPage("./Index");
					}
				}
			}
			catch (System.Exception ex)
			{
				Logger.LogError(message: ex.Message);

				AddToastError(message: Resources.Messages.Errors.UnexpectedError);
			}
			finally
			{
				await DisposeDatabaseContextAsync();
			}

			return Page();
		}
	}
}
