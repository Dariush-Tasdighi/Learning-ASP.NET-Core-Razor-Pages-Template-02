namespace Infrastructure.TagHelpers;

[Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElement
	(tag: "button-create",
	ParentTag = "section-form-buttons",
	TagStructure = Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.WithoutEndTag)]
public class ButtonCreateTagHelper :
	Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
{
	public ButtonCreateTagHelper() : base()
	{
	}

	public override void Process
		(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext context,
		Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
	{
		// **************************************************
		var icon =
			Utility.GetIconCreate();
		// **************************************************

		// **************************************************
		var body =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "button");

		body.Attributes.Add
			(key: "type", value: "submit");

		body.AddCssClass(value: "btn");
		body.AddCssClass(value: "btn-primary");

		body.InnerHtml.AppendHtml(content: icon);
		body.InnerHtml.Append(unencoded: Resources.ButtonCaptions.Create);
		// **************************************************

		// **************************************************
		output.TagName = null;

		output.TagMode =
			Microsoft.AspNetCore.Razor
			.TagHelpers.TagMode.StartTagAndEndTag;

		output.Content.SetHtmlContent(htmlContent: body);
		// **************************************************
	}
}
