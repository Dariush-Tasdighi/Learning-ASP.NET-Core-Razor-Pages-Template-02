namespace Infrastructure.TagHelpers;

[Microsoft.AspNetCore.Razor.TagHelpers
	.HtmlTargetElement(tag: "readonly-checkbox",
	TagStructure = Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.WithoutEndTag)]
public class ReadOnlyCheckBoxTagHelper :
	Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
{
	public ReadOnlyCheckBoxTagHelper
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
		var innerDiv =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "div");

		innerDiv.AddCssClass(value: "form-check");

		div.InnerHtml.AppendHtml(content: innerDiv);
		// **************************************************

		// **************************************************
		var textBoxElement =
			await
			CreateCheckBoxElementAsync();

		innerDiv.InnerHtml.AppendHtml(encoded: textBoxElement);
		// **************************************************

		// **************************************************
		var labelElement =
			await
			CreateLabelElementAsync();

		innerDiv.InnerHtml.AppendHtml(encoded: labelElement);
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
			htmlAttributes: new { @class = "form-check-label" });

		var writer =
			new System.IO.StringWriter();

		tagBuilder.WriteTo(writer: writer,
			encoder: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.Default);

		var result =
			writer.ToString();

		await writer.DisposeAsync();

		return result;
	}

	private async System.Threading.Tasks.Task<string> CreateCheckBoxElementAsync()
	{
		Microsoft.AspNetCore.Mvc.Rendering.TagBuilder tagBuilder;

		bool? isChecked = null;

		if (For.Model != null)
		{
			isChecked =
				System.Convert
				.ToBoolean(value: For.Model);
		}

		tagBuilder =
			Generator.GenerateCheckBox
			(viewContext: ViewContext,
			modelExplorer: For.ModelExplorer,
			expression: For.Name, isChecked: isChecked, htmlAttributes: null);

		tagBuilder.AddCssClass(value: "form-check-input");

		tagBuilder.Attributes.Add(key: "disabled", value: null);
		//tagBuilder.Attributes.Add(key: "disabled", value: "disabled");

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
