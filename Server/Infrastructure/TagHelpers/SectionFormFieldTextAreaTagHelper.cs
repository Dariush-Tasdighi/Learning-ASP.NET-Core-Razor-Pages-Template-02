namespace Infrastructure.TagHelpers;

[Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElement
	(tag: "textarea",
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

		Utility.CreateOrMergeAttribute
			(name: "class", content: "tinymce", output: output);

		return base.ProcessAsync(context, output);
	}
}
