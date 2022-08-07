using System.Linq;

namespace Infrastructure.TagHelpers
{
	[Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElement
		(tag: "span",
		ParentTag = "section-form-field")]
	public class SectionFormFieldValidationMessage : Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper
	{
		public SectionFormFieldValidationMessage
			(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator generator) : base(generator)
		{
		}

		public override System.Threading.Tasks.Task ProcessAsync
			(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext context,
			Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
		{
			Utility.CreateOrMergeAttribute
				(name: "class", content: "text-danger", output: output);

			//output.TagName = "span";

			return base.ProcessAsync(context, output);
		}
	}
}
