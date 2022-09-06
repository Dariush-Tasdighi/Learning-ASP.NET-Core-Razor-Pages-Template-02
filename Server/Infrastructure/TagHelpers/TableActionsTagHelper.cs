namespace Infrastructure.TagHelpers;

[Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElement
	(tag: "table-actions",
	ParentTag = "tr",
	TagStructure = Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.NormalOrSelfClosing)]
public class TableActionsTagHelper :
	Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
{
	public TableActionsTagHelper() : base()
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
			.Rendering.TagBuilder(tagName: "td");

		body.AddCssClass(value: "text-center");

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
