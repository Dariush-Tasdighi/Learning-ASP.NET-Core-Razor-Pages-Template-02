namespace Infrastructure.TagHelpers
{
	[Microsoft.AspNetCore.Razor.TagHelpers
		.HtmlTargetElement(tag: Constants.TagHelper.Input,
		TagStructure = Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.WithoutEndTag)]
	public class SimpleInputTagHelper :
		Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper
	{
		public SimpleInputTagHelper
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
