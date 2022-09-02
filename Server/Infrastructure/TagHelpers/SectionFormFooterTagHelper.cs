namespace Infrastructure.TagHelpers;

[Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElement
	(tag: "section-form-footer",
	ParentTag = "section-form",
	TagStructure = Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.NormalOrSelfClosing)]
public class SectionFormFooterTagHelper :
	Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
{
	public SectionFormFooterTagHelper() : base()
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
		var horizontalRule =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "hr");

		horizontalRule.TagRenderMode =
			Microsoft.AspNetCore.Mvc.Rendering.TagRenderMode.SelfClosing;

		horizontalRule.AddCssClass(value: "mt-4");
		// **************************************************

		// **************************************************
		var body =
			new Microsoft.AspNetCore.Mvc.Rendering.TagBuilder("div");

		body.AddCssClass(value: "mb-3");
		body.AddCssClass(value: "text-center");

		body.InnerHtml.AppendHtml(content: originalContents);
		// **************************************************

		// **************************************************
		output.TagName = null;

		output.TagMode =
			Microsoft.AspNetCore.Razor
			.TagHelpers.TagMode.StartTagAndEndTag;

		output.PreElement.AppendHtml(htmlContent: horizontalRule);
		output.Content.SetHtmlContent(htmlContent: body);
		// **************************************************
	}
}
