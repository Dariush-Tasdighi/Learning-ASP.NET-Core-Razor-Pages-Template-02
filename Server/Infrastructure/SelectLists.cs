using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
	public static class SelectLists : object
	{
		static SelectLists()
		{
		}

		public static async System.Threading.Tasks.Task
			<Microsoft.AspNetCore.Mvc.Rendering.SelectList>
			GetRoles(Data.DatabaseContext databaseContext, object? selectedValue = null)
		{
			var list =
				await
				databaseContext.Roles
				.OrderBy(current => current.Ordering)
				.ThenBy(current => current.Name)
				.Select(current => new ViewModels.Shared.KeyValueViewModel
				{
					Id = current.Id,
					Name = current.Name,
				})
				.ToListAsync()
				;

			var result =
				new Microsoft.AspNetCore.Mvc.Rendering
				.SelectList(items: list,
				dataValueField: nameof(ViewModels.Shared.KeyValueViewModel.Id),
				dataTextField: nameof(ViewModels.Shared.KeyValueViewModel.Name),
				selectedValue: selectedValue);

			return result;
		}
	}
}
