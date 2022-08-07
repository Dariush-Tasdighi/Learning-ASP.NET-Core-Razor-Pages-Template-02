using System.Linq;

namespace Infrastructure.TagHelpers
{
	public static class Utility : object
	{
		static Utility()
		{
		}

		public static Microsoft.AspNetCore.Mvc.Rendering.TagBuilder GetIconList()
		{
			var icon =
				new Microsoft.AspNetCore.Mvc
				.Rendering.TagBuilder(tagName: "i");

			icon.AddCssClass(value: "mx-1");
			icon.AddCssClass(value: "bi");
			icon.AddCssClass(value: "bi-card-list");

			return icon;
		}

		public static Microsoft.AspNetCore.Mvc.Rendering.TagBuilder GetIconDetails()
		{
			var icon =
				new Microsoft.AspNetCore.Mvc
				.Rendering.TagBuilder(tagName: "i");

			icon.AddCssClass(value: "mx-1");
			icon.AddCssClass(value: "bi");
			icon.AddCssClass(value: "bi-zoom-in");

			return icon;
		}

		public static Microsoft.AspNetCore.Mvc.Rendering.TagBuilder GetIconCreate()
		{
			var icon =
				new Microsoft.AspNetCore.Mvc
				.Rendering.TagBuilder(tagName: "i");

			icon.AddCssClass(value: "mx-1");
			icon.AddCssClass(value: "bi");
			icon.AddCssClass(value: "bi-plus-square");

			return icon;
		}

		public static Microsoft.AspNetCore.Mvc.Rendering.TagBuilder GetIconUpdate()
		{
			var icon =
				new Microsoft.AspNetCore.Mvc
				.Rendering.TagBuilder(tagName: "i");

			icon.AddCssClass(value: "mx-1");
			icon.AddCssClass(value: "bi");
			icon.AddCssClass(value: "bi-pencil-fill");

			return icon;
		}

		public static Microsoft.AspNetCore.Mvc.Rendering.TagBuilder GetIconDelete()
		{
			var icon =
				new Microsoft.AspNetCore.Mvc
				.Rendering.TagBuilder(tagName: "i");

			icon.AddCssClass(value: "mx-1");
			icon.AddCssClass(value: "bi");
			icon.AddCssClass(value: "bi-trash");

			return icon;
		}

		public static Microsoft.AspNetCore.Mvc.Rendering.TagBuilder GetIconReset()
		{
			var icon =
				new Microsoft.AspNetCore.Mvc
				.Rendering.TagBuilder(tagName: "i");

			icon.AddCssClass(value: "mx-1");
			icon.AddCssClass(value: "bi");
			icon.AddCssClass(value: "bi-repeat");

			return icon;
		}

		public static void CreateOrMergeAttribute
			(string name, object content,
			Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
		{
			var currentAttribute =
				output.Attributes
				.Where(current => current.Name == name)
				.FirstOrDefault();

			if (currentAttribute == null)
			{
				var attribute =
					new Microsoft.AspNetCore.Razor.TagHelpers
					.TagHelperAttribute(name: name, value: content);

				output.Attributes.Add(attribute: attribute);
			}
			else
			{
				var value =
					$"{currentAttribute.Value} {content}";

				var newAttribute =
					new Microsoft.AspNetCore.Razor.TagHelpers
					.TagHelperAttribute(name: name, value: value,
					valueStyle: currentAttribute.ValueStyle);

				output.Attributes
					.Remove(attribute: currentAttribute);

				output.Attributes
					.Add(attribute: newAttribute);
			}
		}
	}
}
