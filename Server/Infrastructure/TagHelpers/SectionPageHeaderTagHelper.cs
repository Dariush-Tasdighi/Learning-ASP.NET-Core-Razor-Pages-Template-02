namespace Infrastructure.TagHelpers
{
	[Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElement
			(tag: "section-page-header",
			TagStructure = Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.NormalOrSelfClosing)]
	public class SectionPageHeaderTagHelper :
		Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
	{
		public SectionPageHeaderTagHelper() : base()
		{
		}

		//public override void Process
		//	(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext context,
		//	Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
		//{
		//	base.Process(context, output);
		//}

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
				new Microsoft.AspNetCore.Mvc
				.Rendering.TagBuilder(tagName: "h3");

			body.AddCssClass(value: "mb-3");
			body.AddCssClass(value: "text-center");

			body.InnerHtml.AppendHtml(content: originalContents);
			//body.InnerHtml.AppendHtml(content: horizontalRule);
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
}
