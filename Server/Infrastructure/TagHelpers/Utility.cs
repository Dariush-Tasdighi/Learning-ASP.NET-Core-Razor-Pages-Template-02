using System.Linq;

namespace Infrastructure.TagHelpers;

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

			output.Attributes
				.Add(attribute: attribute);
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

	public static async
		System.Threading.Tasks.Task<string> GenerateLabelAsync
		(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator generator,
		Microsoft.AspNetCore.Mvc.Rendering.ViewContext viewContext,
		Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression @for, string? cssClass = null)
	{
		var tagBuilder =
			generator.GenerateLabel
			(viewContext: viewContext,
			modelExplorer: @for.ModelExplorer,
			expression: @for.Name, labelText: null, htmlAttributes: null);

		if (cssClass != null)
		{
			tagBuilder.AddCssClass
				(value: "form-label");
		}
		else
		{
			tagBuilder.AddCssClass(value: cssClass);
		}

		var writer =
			new System.IO.StringWriter();

		tagBuilder.WriteTo(writer: writer,
			encoder: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.Default);

		var result =
			writer.ToString();

		await writer.DisposeAsync();

		return result;
	}

	public static async
		System.Threading.Tasks.Task<string> GenerateTextBoxAsync
		(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator generator,
		Microsoft.AspNetCore.Mvc.Rendering.ViewContext viewContext,
		Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression @for)
	{
		var tagBuilder =
			generator.GenerateTextBox
			(viewContext: viewContext,
			modelExplorer: @for.ModelExplorer, expression: @for.Name,
			value: @for.Model, format: null, htmlAttributes: null);

		tagBuilder.AddCssClass
			(value: "form-control");

		if ((@for.ModelExplorer.ModelType == typeof(System.Int16))
			||
			(@for.ModelExplorer.ModelType == typeof(System.Int32))
			||
			(@for.ModelExplorer.ModelType == typeof(System.Int64))
			||
			(@for.ModelExplorer.ModelType == typeof(System.DateTime)))
		{
			tagBuilder.AddCssClass(value: "ltr");

			tagBuilder.Attributes.Remove(key: "type");
			tagBuilder.Attributes.Add(key: "type", value: "number");
		}

		var writer =
			new System.IO.StringWriter();

		tagBuilder.WriteTo(writer: writer,
			encoder: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.Default);

		var result =
			writer.ToString();

		await writer.DisposeAsync();

		return result;
	}

	public static async
		System.Threading.Tasks.Task<string> GenerateCheckBoxAsync
		(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator generator,
		Microsoft.AspNetCore.Mvc.Rendering.ViewContext viewContext,
		Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression @for)
	{
		bool? isChecked = null;

		if (@for.Model != null)
		{
			isChecked =
				System.Convert
				.ToBoolean(value: @for.Model);
		}

		var tagBuilder =
			generator.GenerateCheckBox
			(viewContext: viewContext, modelExplorer: @for.ModelExplorer,
			expression: @for.Name, isChecked: isChecked, htmlAttributes: null);

		tagBuilder.AddCssClass
			(value: "form-check-input");

		var writer =
			new System.IO.StringWriter();

		tagBuilder.WriteTo(writer: writer,
			encoder: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.Default);

		var result =
			writer.ToString();

		await writer.DisposeAsync();

		return result;
	}

	public static async
		System.Threading.Tasks.Task<string> GenerateTextAreaAsync
		(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator generator,
		Microsoft.AspNetCore.Mvc.Rendering.ViewContext viewContext,
		Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression @for)
	{
		var tagBuilder =
			generator.GenerateTextArea
			(viewContext: viewContext, modelExplorer: @for.ModelExplorer,
			expression: @for.Name, rows: 3, columns: 60, htmlAttributes: null);

		tagBuilder.AddCssClass
			(value: "form-control");

		var writer =
			new System.IO.StringWriter();

		tagBuilder.WriteTo(writer: writer,
			encoder: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.Default);

		var result =
			writer.ToString();

		await writer.DisposeAsync();

		return result;
	}

	public static async
		System.Threading.Tasks.Task<string> GenerateValidationMessageAsync
		(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator generator,
		Microsoft.AspNetCore.Mvc.Rendering.ViewContext viewContext,
		Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression @for)
	{
		var tagBuilder =
			generator.GenerateValidationMessage
			(viewContext: viewContext,
			modelExplorer: @for.ModelExplorer,
			expression: @for.Name, message: null, tag: null, htmlAttributes: null);

		tagBuilder.AddCssClass(value: "text-danger");

		var writer =
			new System.IO.StringWriter();

		tagBuilder.WriteTo(writer: writer,
			encoder: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.Default);

		var result =
			writer.ToString();

		await writer.DisposeAsync();

		return result;
	}
}
