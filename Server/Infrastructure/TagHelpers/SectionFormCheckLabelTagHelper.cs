namespace Infrastructure.TagHelpers;

[Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElement
	(tag: "label",
	ParentTag = "section-form-check")]
public class SectionFormCheckLabelTagHelper :
	Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper
{
	public SectionFormCheckLabelTagHelper
		(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator generator) : base(generator)
	{
	}

	public override System.Threading.Tasks.Task ProcessAsync
		(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext context,
		Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
	{
		Utility.CreateOrMergeAttribute
			(name: "class", content: "form-check-label", output: output);

		//output.TagName = "label";

		return base.ProcessAsync(context, output);
	}
}
