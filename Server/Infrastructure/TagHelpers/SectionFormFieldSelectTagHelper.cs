namespace Infrastructure.TagHelpers
{
	[Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElement
		(tag: "select",
		ParentTag = "section-form-field")]
	public class SectionFormFieldSelectTagHelper :
		Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper
	{
		public SectionFormFieldSelectTagHelper
            (Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator generator) : base(generator)
		{
		}

		public override System.Threading.Tasks.Task ProcessAsync
			(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext context,
			Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
		{
			Utility.CreateOrMergeAttribute
				(name: "class", content: "form-select", output: output);


            return base.ProcessAsync(context, output);
		}
	}
}
