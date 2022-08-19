namespace Infrastructure.TagHelpers
{
	[Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElement
		(tag: "section-form",
		TagStructure = Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.NormalOrSelfClosing)]
	public class SectionFormTagHelper :
		Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
	{
		public SectionFormTagHelper() : base()
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
			divCol.AddCssClass(value: "bg-light");
			divCol.AddCssClass(value: "rounded-3");
			divCol.AddCssClass(value: "shadow-lg");
			divCol.AddCssClass(value: "border border-2");

			divCol.AddCssClass(value: "col-12 p-3");
			divCol.AddCssClass(value: "col-md-8 offset-md-2 p-md-4");
			divCol.AddCssClass(value: "col-lg-6 offset-lg-3 p-lg-5");

			divCol.InnerHtml.AppendHtml(content: originalContents);
			// **************************************************

			// **************************************************
			var divRow =
				new Microsoft.AspNetCore.Mvc.Rendering.TagBuilder("div");

			divRow.AddCssClass(value: "row");
			divRow.AddCssClass(value: "my-0");
			divRow.AddCssClass(value: "my-sm-1");
			divRow.AddCssClass(value: "my-md-3");
			divRow.AddCssClass(value: "my-lg-5");

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
}
