namespace Infrastructure.TagHelpers;

[Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElement
	(tag: "table",
	ParentTag = "section-table",
	TagStructure = Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.NormalOrSelfClosing)]
public class TableTagHelper :
	Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
{
	public TableTagHelper() : base()
	{
	}

	public async override System.Threading.Tasks.Task ProcessAsync
		(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext context,
		Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
	{
		// **************************************************
		var originalContents =
			(await
			output.GetChildContentAsync())
			.GetContent()
			;

		originalContents =
			originalContents.Replace
			("thead", "thead class=\"table-primary text-center\"");

		//originalContents =
		//	originalContents.Replace
		//	("tbody", "tbody class=\"\"");

		originalContents =
			originalContents.Replace
			("tfooter", "tfooter class=\"table-secondary\"");
		// **************************************************

		// **************************************************
		output.TagName = "table";

		output.TagMode =
			Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag;

		output.Attributes.SetAttribute
			(name: "class",
			value: "table table-bordered table-sm table-striped table-hover align-items-center");
		// **************************************************

		output.Content.SetHtmlContent(encoded: originalContents);
	}
}
