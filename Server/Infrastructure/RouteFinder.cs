﻿using System.Linq;

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
				Path = GetPath(current.DeclaringType.Namespace, current.Name),
			})
			.OrderBy(current => current.Name)
			.ToList()
			;

		return foundedHandlers;
	}

	private static string GetPath(string @namespace, string actionName)
	{
		var dot = ".";
		var slash = "/";
		var doubleSlash = slash + slash;

		var path =
			@namespace
			.Replace(oldValue: nameof(Server.Pages), newValue: string.Empty)
			;

		path =
			path
			.Replace(oldValue: dot, newValue: slash)
			;

		if (path.EndsWith(value: slash) == false)
		{
			path += slash;
		}

		path += actionName;

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
