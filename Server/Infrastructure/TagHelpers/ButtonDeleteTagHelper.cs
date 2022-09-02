namespace Infrastructure.TagHelpers;

[Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElement
	(tag: "button-delete",
	ParentTag = "section-form-buttons",
	TagStructure = Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.WithoutEndTag)]
public class ButtonDeleteTagHelper :
	Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
{
	public ButtonDeleteTagHelper() : base()
	{
	}

	public override void Process
		(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext context,
		Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
	{
		// **************************************************
		var icon =
			Utility.GetIconDelete();
		// **************************************************

		// **************************************************
		var body =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "button");

		body.Attributes.Add
			(key: "type", value: "submit");

		body.AddCssClass(value: "btn");
		body.AddCssClass(value: "btn-danger");

		body.InnerHtml.AppendHtml(content: icon);
		body.InnerHtml.Append(unencoded: Resources.ButtonCaptions.Delete);
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
