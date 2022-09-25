using System.Drawing.Imaging;
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
			GetRolesAsync(Data.DatabaseContext databaseContext, object? selectedValue = null)
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

			// **************************************************
			var emptyItem =
				new ViewModels.Shared.KeyValueViewModel
				(id: null, name: Resources.DataDictionary.SelectAnItem);

			list.Insert(index: 0, item: emptyItem);
			// **************************************************

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
