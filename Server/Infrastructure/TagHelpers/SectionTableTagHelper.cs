namespace Infrastructure.TagHelpers;

[Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElement
	(tag: "section-table",
	TagStructure = Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.NormalOrSelfClosing)]
public class SectionTableTagHelper :
	Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
{
	public SectionTableTagHelper() : base()
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
		var divCol =
			new Microsoft.AspNetCore.Mvc.Rendering.TagBuilder("div");

		divCol.AddCssClass(value: "col");
		divCol.AddCssClass(value: "table-responsive");

		divCol.InnerHtml.AppendHtml(content: originalContents);
		// **************************************************

		// **************************************************
		var divRow =
			new Microsoft.AspNetCore.Mvc.Rendering.TagBuilder("div");

		divRow.AddCssClass(value: "row");

		divRow.InnerHtml.AppendHtml(content: divCol);
		// **************************************************

		// **************************************************
		output.TagName = null;

		output.TagMode =
			Microsoft.AspNetCore.Razor
			.TagHelpers.TagMode.StartTagAndEndTag;

		output.Content.SetHtmlContent(htmlContent: divRow);
		// **************************************************
	}
}
