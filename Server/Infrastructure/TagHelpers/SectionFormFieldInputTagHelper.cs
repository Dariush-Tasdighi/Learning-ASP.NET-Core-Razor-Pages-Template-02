namespace Infrastructure.TagHelpers
{
	[Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElement
		(tag: "textarea",
		ParentTag = "section-form-field")]
	public class SectionFormFieldInputTagHelper :
		Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper
	{
		public SectionFormFieldInputTagHelper
			(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator generator) : base(generator)
		{
		}

		public override System.Threading.Tasks.Task ProcessAsync
			(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext context,
			Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
		{
			Utility.CreateOrMergeAttribute
				(name: "class", content: "form-control", output: output);

			//output.TagName = "textarea";

			return base.ProcessAsync(context, output);
		}
	}
}
