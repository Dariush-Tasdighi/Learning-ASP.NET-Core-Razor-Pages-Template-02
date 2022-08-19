namespace Infrastructure.TagHelpers
{
	[Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElement
		(tag: "input",
		ParentTag = "section-form-field")]
	public class SectionFormFieldTextArea :
		Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper
	{
		public SectionFormFieldTextArea
			(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator generator) : base(generator)
		{
		}

		public override System.Threading.Tasks.Task ProcessAsync
			(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext context,
			Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
		{
			Utility.CreateOrMergeAttribute
				(name: "class", content: "form-control", output: output);

			//output.TagName = "input";

			return base.ProcessAsync(context, output);
		}
	}
}
