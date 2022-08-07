namespace Infrastructure.TagHelpers
{
	[Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElement
		(tag: "a",
		ParentTag = "table-actions",
		TagStructure = Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.NormalOrSelfClosing)]
	public class TableActionsLink : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
	{
		public TableActionsLink() : base()
		{
		}

		public override void Process
			(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext context,
			Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
		{
			// **************************************************
			output.Attributes.SetAttribute
				(name: "class", value: "text-decoration-none");
			// **************************************************
		}
	}
}
