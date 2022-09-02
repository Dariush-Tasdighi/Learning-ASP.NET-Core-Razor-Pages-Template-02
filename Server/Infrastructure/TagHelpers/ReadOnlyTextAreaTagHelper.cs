using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using System.Data;

namespace Infrastructure.TagHelpers;

[Microsoft.AspNetCore.Razor.TagHelpers
	.HtmlTargetElement(tag: "readonly-textarea",
	TagStructure = Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.WithoutEndTag)]
public class ReadOnlyTextAreaTagHelper :
	Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
{
	public ReadOnlyTextAreaTagHelper
		(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator generator) : base()
	{
		Generator = generator;
	}

	private Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator Generator { get; }

	[Microsoft.AspNetCore.Mvc.ViewFeatures.ViewContext]
	[Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNotBound]
	public Microsoft.AspNetCore.Mvc.Rendering.ViewContext? ViewContext { get; set; }

	[Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName(name: "asp-for")]
	public Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression? For { get; set; }

	public override async System.Threading.Tasks.Task ProcessAsync
		(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext context,
		Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
	{
		// **************************************************
		var div =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "div");

		div.AddCssClass(value: "mb-3");
		// **************************************************

		// **************************************************
		var labelElement =
			await
			CreateLabelElementAsync();

		div.InnerHtml.AppendHtml(encoded: labelElement);
		// **************************************************

		// **************************************************
		var textBoxElement =
			await
			CreateTextAreaElementAsync();

		div.InnerHtml.AppendHtml(encoded: textBoxElement);
		// **************************************************

		// **************************************************
		output.TagName = null;

		output.TagMode =
			Microsoft.AspNetCore.Razor
			.TagHelpers.TagMode.StartTagAndEndTag;

		output.Content.SetHtmlContent(htmlContent: div);
		// **************************************************
	}

	private async System.Threading.Tasks.Task<string> CreateLabelElementAsync()
	{
		var tagBuilder =
			Generator.GenerateLabel
			(viewContext: ViewContext,
			modelExplorer: For.ModelExplorer, expression: For.Name, labelText: null,
			htmlAttributes: new { @class = "form-label" });

		var writer =
			new System.IO.StringWriter();

		tagBuilder.WriteTo(writer: writer,
			encoder: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.Default);

		var result =
			writer.ToString();

		await writer.DisposeAsync();

		return result;
	}

	private async System.Threading.Tasks.Task<string> CreateTextAreaElementAsync()
	{
		Microsoft.AspNetCore.Mvc.Rendering.TagBuilder tagBuilder;

		tagBuilder =
			Generator.GenerateTextArea
			(viewContext: ViewContext,
			modelExplorer: For.ModelExplorer,
			expression: For.Name, rows: 3, columns: 60, htmlAttributes: null);

		tagBuilder.AddCssClass(value: "form-control");

		tagBuilder.Attributes.Add(key: "disabled", value: null);
		//tagBuilder.Attributes.Add(key: "disabled", value: "disabled");
		//tagBuilder.Attributes.Add(key: "readonly", value: null);
		//tagBuilder.Attributes.Add(key: "readonly", value: "readonly");

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
