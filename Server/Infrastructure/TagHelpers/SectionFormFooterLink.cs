﻿namespace Infrastructure.TagHelpers
{
	[Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElement
		(tag: "a",
		ParentTag = "section-form-footer",
		TagStructure = Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.NormalOrSelfClosing)]
	public class SectionFormFooterLink : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
	{
		public SectionFormFooterLink() : base()
		{
		}

		public override void Process
			(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext context,
			Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
		{
			// **************************************************
			output.Attributes.SetAttribute
				(name: "class", value: "text-decoration-none");
			// **************************************************
		}
	}
}
