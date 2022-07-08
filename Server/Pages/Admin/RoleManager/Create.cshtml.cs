using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Server.Pages.Admin.RoleManager
{
	[Microsoft.AspNetCore.Authorization.Authorize
		(Roles = Domain.SeedWork.Constant.SystemicRole.Admin)]
	public class CreateModel : Infrastructure.BasePageModelWithDatabase
	{
		public CreateModel
			(Persistence.DatabaseContext databaseContext,
			Microsoft.Extensions.Logging.ILogger<CreateModel> logger) : base(databaseContext: databaseContext)
		{
			Logger = logger;
			ViewModel = new();
		}

		// **********
		private Microsoft.Extensions.Logging.ILogger<CreateModel> Logger { get; }
		// **********

		// **********
		[Microsoft.AspNetCore.Mvc.BindProperty]
		public ViewModels.Pages.Admin.RoleManager.CreateRoleViewModel ViewModel { get; set; }
		// **********

		public Microsoft.AspNetCore.Mvc.IActionResult OnGet()
		{
			return Page();
		}

		public async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.IActionResult> OnPostAsync()
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
					// **************************************************
					Domain.Models.Role role = new()
					{
						Name = fixedName,
						Ordering = ViewModel.Ordering,
						IsActive = ViewModel.IsActive,
						IsDeletable = ViewModel.IsDeletable,
						Description = Infrastructure.Utility.FixText(text: ViewModel.Description),
					};
					// **************************************************

					var entityEntry =
						await DatabaseContext.AddAsync(entity: role);

					int affectedRows =
						await DatabaseContext.SaveChangesAsync();

					// **************************************************
					if (affectedRows > 0)
					{
						string successMessage = string.Format
							(Resources.Messages.Successes.SuccessfullyCreated,
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
