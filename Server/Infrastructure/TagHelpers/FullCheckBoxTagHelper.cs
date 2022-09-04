namespace Infrastructure.TagHelpers;

[Microsoft.AspNetCore.Razor.TagHelpers
	.HtmlTargetElement(tag: Constants.TagHelper.FullCheckBox,
	TagStructure = Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.WithoutEndTag)]
public class FullCheckBoxTagHelper :
	Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
{
	public FullCheckBoxTagHelper
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
		var checkBox =
			await
			Utility.GenerateCheckBoxAsync
			(generator: Generator, viewContext: ViewContext, @for: For);

		innerDiv.InnerHtml.AppendHtml(encoded: checkBox);
		// **************************************************

		// **************************************************
		var label =
			await
			Utility.GenerateLabelAsync(generator: Generator,
			viewContext: ViewContext, @for: For, cssClass: "form-check-label");

		innerDiv.InnerHtml.AppendHtml(encoded: label);
		// **************************************************

		// **************************************************
		output.TagName = null;

		output.TagMode =
			Microsoft.AspNetCore.Razor
			.TagHelpers.TagMode.StartTagAndEndTag;

		output.Content.SetHtmlContent(htmlContent: div);
		// **************************************************
	}

	//private async System.Threading.Tasks.Task<string> CreateLabelElementAsync()
	//{
	//	var tagBuilder =
	//		Generator.GenerateLabel
	//		(viewContext: ViewContext,
	//		modelExplorer: For.ModelExplorer, expression: For.Name, labelText: null,
	//		htmlAttributes: new { @class =  });

	//	var writer =
	//		new System.IO.StringWriter();

	//	tagBuilder.WriteTo(writer: writer,
	//		encoder: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.Default);

	//	var result =
	//		writer.ToString();

	//	await writer.DisposeAsync();

	//	return result;
	//}
}
