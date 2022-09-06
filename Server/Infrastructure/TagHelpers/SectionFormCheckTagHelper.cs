namespace Infrastructure.TagHelpers;

[Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElement
	(tag: "section-form-check",
	ParentTag = "fieldset",
	TagStructure = Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.NormalOrSelfClosing)]
public class SectionFormCheckTagHelper :
	Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
{
	public SectionFormCheckTagHelper() : base()
	{
	}

	public async override System.Threading.Tasks.Task ProcessAsync
		(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext context,
		Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
	{
		// **************************************************
		var originalContents =
			await
			output.GetChildContentAsync();
		// **************************************************

		// **************************************************
		var div =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "div");

		div.AddCssClass(value: "form-check");

		div.InnerHtml.AppendHtml(content: originalContents);
		// **************************************************

		// **************************************************
		var body =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "div");

		body.AddCssClass(value: "mb-3");

		body.InnerHtml.AppendHtml(content: div);
		// **************************************************

		// **************************************************
		output.TagName = null;

		output.TagMode =
			Microsoft.AspNetCore.Razor
			.TagHelpers.TagMode.StartTagAndEndTag;

		output.Content.SetHtmlContent(htmlContent: body);
		// **************************************************
	}
}
