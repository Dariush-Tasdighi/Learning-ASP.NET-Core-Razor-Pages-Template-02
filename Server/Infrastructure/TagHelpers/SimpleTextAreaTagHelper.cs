namespace Infrastructure.TagHelpers
{
	[Microsoft.AspNetCore.Razor.TagHelpers
		.HtmlTargetElement(tag: Constants.TagHelper.TextArea,
		TagStructure = Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.WithoutEndTag)]
	public class SimpleTextAreaTagHelper :
		Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper
	{
		public SimpleTextAreaTagHelper
			(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator generator) : base(generator: generator)
		{
		}

		public override System.Threading.Tasks.Task ProcessAsync
			(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext context,
			Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
		{
			Utility.CreateOrMergeAttribute
				(name: "class", content: "form-control", output: output);

			return base.ProcessAsync(context, output);
		}
	}
}
