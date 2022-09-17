using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace Infrastructure;

public static class RouteFinder : object
{
	static RouteFinder()
	{
	}

	public static System.Collections.Generic.IList
		<ViewModels.Pages.Admin.ApplicationHandlers.CreateViewModel> Find()
	{
		var assembly =
			System.Reflection.Assembly
			.GetAssembly(type: typeof(Server.Pages.IndexModel));

		var pageModelType =
			typeof(Microsoft.AspNetCore.Mvc.RazorPages.PageModel);

		var compilerGeneratedAttributeType =
			typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute);

		var routes =
			assembly
			.GetTypes()
			.Where(current => pageModelType.IsAssignableFrom(c: current))
			.Where(current => current.IsAbstract == false)
			.SelectMany(current => current.GetMethods
			(
				bindingAttr:
				System.Reflection.BindingFlags.Public |
				System.Reflection.BindingFlags.Instance |
				System.Reflection.BindingFlags.DeclaredOnly
			));

		var foundedHandlers =
			routes
			.Where(current => current.GetCustomAttributes
				(attributeType: compilerGeneratedAttributeType, inherit: true).Any() == false)
			.Select(current => new ViewModels.Pages.Admin.ApplicationHandlers.CreateViewModel
			{
				IsActive = true,
				Name = current.Name,
				AccessType = Domain.Enumerations.AccessType.Special,
				Path = GetPath(current.DeclaringType.FullName, current.Name),
			})
			.OrderBy(current => current.Name)
			.ToList()
			;

		return foundedHandlers;
	}

	private static string GetPath(string fullName, string handler)
	{
		var dot = ".";
		var slash = "/";
		var doubleSlash = "//";

		var model = nameof(Model);
		var baseNamespace = $"{nameof(Server)}.{nameof(Server.Pages)}";

		if (fullName.ToLower().EndsWith(value: model.ToLower()))
		{
			fullName =
				fullName
				.Remove(startIndex: fullName.Length - 5);
		}

		var path =
			fullName
			.Replace(oldValue: baseNamespace, newValue: string.Empty)
			;

		path =
			path
			.Replace(oldValue: dot, newValue: slash)
			;

		if (path.EndsWith(value: slash) == false)
		{
			path += slash;
		}

		path += handler;

		while (path.Contains(value: doubleSlash))
		{
			path =
				path
				.Replace(oldValue: doubleSlash, newValue: slash)
				;
		}

		return path;
	}
}
