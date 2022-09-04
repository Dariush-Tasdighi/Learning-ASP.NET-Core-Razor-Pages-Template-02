namespace Infrastructure.TagHelpers;

[Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElement
	(tag: "input",
	ParentTag = "section-form-check")]
public class SectionFormCheckInputTagHelper :
	Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper
{
	public SectionFormCheckInputTagHelper
		(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator generator) : base(generator)
	{
	}

	public override System.Threading.Tasks.Task ProcessAsync
		(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext context,
		Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
	{
		Utility.CreateOrMergeAttribute
			(name: "class", content: "form-check-input", output: output);

		//output.TagName = "input";

		return base.ProcessAsync(context, output);
	}
}
