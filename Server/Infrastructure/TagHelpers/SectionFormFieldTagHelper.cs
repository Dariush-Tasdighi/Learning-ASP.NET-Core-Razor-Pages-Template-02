namespace Infrastructure.TagHelpers;

[Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElement
	(tag: "section-form-field",
	ParentTag = "fieldset",
	TagStructure = Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.NormalOrSelfClosing)]
public class SectionFormFieldTagHelper :
	Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
{
	public SectionFormFieldTagHelper() : base()
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
		var body =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "div");

		body.AddCssClass(value: "mb-3");

		body.InnerHtml.AppendHtml(content: originalContents);
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
