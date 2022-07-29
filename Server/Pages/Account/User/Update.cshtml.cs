////using System.Linq;
////using Microsoft.EntityFrameworkCore;
////using Microsoft.Extensions.Logging;

//namespace Server.Pages.Security.User
//{
//	[Microsoft.AspNetCore.Authorization.Authorize]
//	public class UpdateModel : Infrastructure.BasePageModelWithDatabase
//	{
//		public UpdateModel
//			(Data.DatabaseContext databaseContext,
//			Microsoft.Extensions.Logging.ILogger<UpdateModel> logger) : base(databaseContext: databaseContext)
//		{
//			Logger = logger;

//			ViewModel = new();
//		}

//		private Microsoft.Extensions.Logging.ILogger<UpdateModel> Logger { get; }

//		[Microsoft.AspNetCore.Mvc.BindProperty]
//		public ViewModels.Pages.Admin.UserManager.UpdateUserViewModel ViewModel { get; set; }

//		public async System.Threading.Tasks.Task OnGetAsync()
//		{
//			await System.Threading.Tasks.Task.CompletedTask;
//		}

//		public async
//			System.Threading.Tasks.Task OnPostAsync()
//		{
//			if (ModelState.IsValid == false)
//			{
//				return;
//			}

//			await System.Threading.Tasks.Task.CompletedTask;
//		}
//	}
//}
