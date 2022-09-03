namespace Infrastructure.TagHelpers
{
	[Microsoft.AspNetCore.Razor.TagHelpers
		.HtmlTargetElement(tag: Constants.TagHelper.Label,
		TagStructure = Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.WithoutEndTag)]
	public class SimpleLabelTagHelper :
		Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper
	{
		public SimpleLabelTagHelper
			(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator generator) : base(generator)
		{
		}

		public override System.Threading.Tasks.Task ProcessAsync
			(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext context,
			Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
		{
			Utility.CreateOrMergeAttribute
				(name: "class", content: "form-label", output: output);

			return base.ProcessAsync(context, output);
		}
	}
}
