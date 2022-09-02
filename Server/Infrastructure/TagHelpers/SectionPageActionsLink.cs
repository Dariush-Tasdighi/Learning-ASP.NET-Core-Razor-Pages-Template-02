namespace Infrastructure.TagHelpers;

[Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElement
	(tag: "a",
	ParentTag = "section-page-actions",
	TagStructure = Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.NormalOrSelfClosing)]
public class SectionPageActionsLink :
	Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
{
	public SectionPageActionsLink() : base()
	{
	}

	public override void Process
		(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext context,
		Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
	{
		// **************************************************
		output.Attributes.SetAttribute
			(name: "class", value: "btn btn-primary");
		// **************************************************
	}
}
