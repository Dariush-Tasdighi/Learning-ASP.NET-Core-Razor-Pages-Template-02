namespace Infrastructure;

public static class HtmlHelpers : object
{
	static HtmlHelpers()
	{
	}

	public static string DefaultValue
	{
		get
		{
			//return null;
			//return string.Empty;
			return "-----";
		}
	}

	public static Microsoft.AspNetCore.Html.IHtmlContent DtatDisplayInteger
		(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html, long? value)
	{
		if (value.HasValue == false)
		{
			return html.Raw(value: DefaultValue);
		}

		var result =
			value.Value.ToString(format: "#,##0");

		result =
			Convert.DigitsToUnicode(value: result);

		return html.Raw(value: result);
	}

	public static Microsoft.AspNetCore.Html
		.IHtmlContent DtatDisplayRowNumberWithTd
		(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html, long? value)
	{
		var td =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "td");

		td.AddCssClass(value: "text-center");

		var innerHtml =
			DtatDisplayInteger(html: html, value: value);

		td.InnerHtml.AppendHtml(content: innerHtml);

		return td;
	}

	public static Microsoft.AspNetCore.Html.IHtmlContent DtatDisplayBoolean
		(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html, bool? value)
	{
		if (html is null)
		{
			throw new System
				.ArgumentNullException(paramName: nameof(html));
		}

		var div =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "div");

		var input =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "input");

		input.Attributes.Add
			(key: "type", value: "checkbox");

		input.Attributes.Add
			(key: "disabled", value: "disabled");

		if (value.HasValue && value.Value)
		{
			input.Attributes.Add
				(key: "checked", value: "checked");
		}

		div.InnerHtml.AppendHtml(content: input);

		return div;
	}

	public static Microsoft.AspNetCore.Html.IHtmlContent DtatDisplayBooleanWithTd
		(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html, bool? value)
	{
		var td =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "td");

		td.AddCssClass(value: "text-center");

		var innerHtml =
			DtatDisplayBoolean(html: html, value: value);

		td.InnerHtml.AppendHtml(content: innerHtml);

		return td;
	}

	public static Microsoft.AspNetCore.Html.IHtmlContent DtatDisplayIntegerWithTd
		(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html, long? value)
	{
		var td =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "td");

		td.Attributes.Add
			(key: "dir", value: "ltr");

		var innerHtml =
			DtatDisplayInteger(html: html, value: value);

		td.InnerHtml.AppendHtml(content: innerHtml);

		return td;
	}

	public static Microsoft.AspNetCore.Html.IHtmlContent DtatDisplayDateTime
		(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html, System.DateTime? value)
	{
		if (value.HasValue == false)
		{
			return html.Raw(value: DefaultValue);
		}

		var result =
			value.Value.ToString
			(format: "yyyy/MM/dd - HH:mm:ss");

		result =
			Convert.DigitsToUnicode(value: result);

		return html.Raw(value: result);
	}

	public static Microsoft.AspNetCore.Html.IHtmlContent DtatDisplayDateTimeWithTd
		(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html, System.DateTime? value)
	{
		var td =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "td");

		td.Attributes.Add
			(key: "dir", value: "ltr");

		var innerHtml =
			DtatDisplayDateTime(html: html, value: value);

		td.InnerHtml.AppendHtml(content: innerHtml);

		return td;
	}

	public static Microsoft.AspNetCore.Html.IHtmlContent DtatGetLinkCaptionForList
		(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html)
	{
		if (html is null)
		{
			throw new System
				.ArgumentNullException(paramName: nameof(html));
		}

		var icon =
			TagHelpers.Utility.GetIconList();

		var span =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "span");

		span.AddCssClass(value: "mx-1");

		span.InnerHtml.Append(unencoded: "[");
		span.InnerHtml.Append(unencoded: " ");
		span.InnerHtml.AppendHtml(content: icon);
		span.InnerHtml.Append(unencoded: Resources.ButtonCaptions.BackToList);
		span.InnerHtml.Append(unencoded: " ");
		span.InnerHtml.Append(unencoded: "]");

		return span;
	}

	public static Microsoft.AspNetCore.Html.IHtmlContent DtatGetLinkCaptionForDetails
		(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html)
	{
		if (html is null)
		{
			throw new System
				.ArgumentNullException(paramName: nameof(html));
		}

		var icon =
			TagHelpers.Utility.GetIconDetails();

		var span =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "span");

		span.AddCssClass(value: "mx-1");

		span.InnerHtml.Append(unencoded: "[");
		span.InnerHtml.Append(unencoded: " ");
		span.InnerHtml.AppendHtml(content: icon);
		span.InnerHtml.Append(unencoded: Resources.ButtonCaptions.Details);
		span.InnerHtml.Append(unencoded: " ");
		span.InnerHtml.Append(unencoded: "]");

		return span;
	}

	public static Microsoft.AspNetCore.Html.IHtmlContent DtatGetLinkCaptionForCreate
		(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html)
	{
		if (html is null)
		{
			throw new System
				.ArgumentNullException(paramName: nameof(html));
		}

		var icon =
			TagHelpers.Utility.GetIconCreate();

		var span =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "span");

		//span.AddCssClass(value: "mx-1");

		//span.InnerHtml.Append(unencoded: "[");
		//span.InnerHtml.Append(unencoded: " ");
		span.InnerHtml.AppendHtml(content: icon);
		span.InnerHtml.Append(unencoded: Resources.ButtonCaptions.Create);
		//span.InnerHtml.Append(unencoded: " ");
		//span.InnerHtml.Append(unencoded: "]");

		return span;
	}

	public static Microsoft.AspNetCore.Html.IHtmlContent DtatGetLinkCaptionForUpdate
		(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html)
	{
		if (html is null)
		{
			throw new System
				.ArgumentNullException(paramName: nameof(html));
		}

		var icon =
			TagHelpers.Utility.GetIconUpdate();

		var span =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "span");

		span.AddCssClass(value: "mx-1");

		span.InnerHtml.Append(unencoded: "[");
		span.InnerHtml.Append(unencoded: " ");
		span.InnerHtml.AppendHtml(content: icon);
		span.InnerHtml.Append(unencoded: Resources.ButtonCaptions.Update);
		span.InnerHtml.Append(unencoded: " ");
		span.InnerHtml.Append(unencoded: "]");

		return span;
	}

	public static Microsoft.AspNetCore.Html.IHtmlContent DtatGetLinkCaptionForDelete
		(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html)
	{
		if (html is null)
		{
			throw new System
				.ArgumentNullException(paramName: nameof(html));
		}

		var icon =
			TagHelpers.Utility.GetIconDelete();

		var span =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "span");

		span.AddCssClass(value: "mx-1");

		span.InnerHtml.Append(unencoded: "[");
		span.InnerHtml.Append(unencoded: " ");
		span.InnerHtml.AppendHtml(content: icon);
		span.InnerHtml.Append(unencoded: Resources.ButtonCaptions.Delete);
		span.InnerHtml.Append(unencoded: " ");
		span.InnerHtml.Append(unencoded: "]");

		return span;
	}

	public static Microsoft.AspNetCore.Html.IHtmlContent DtatGetIconDetails
		(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html)
	{
		if (html is null)
		{
			throw new System
				.ArgumentNullException(paramName: nameof(html));
		}

		var icon =
			TagHelpers.Utility.GetIconDetails();

		return icon;
	}

	public static Microsoft.AspNetCore.Html.IHtmlContent DtatGetIconCreate
		(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html)
	{
		if (html is null)
		{
			throw new System
				.ArgumentNullException(paramName: nameof(html));
		}

		var icon =
			TagHelpers.Utility.GetIconCreate();

		return icon;
	}

	public static Microsoft.AspNetCore.Html.IHtmlContent DtatGetIconUpdate
		(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html)
	{
		if (html is null)
		{
			throw new System
				.ArgumentNullException(paramName: nameof(html));
		}

		var icon =
			TagHelpers.Utility.GetIconUpdate();

		return icon;
	}

	public static Microsoft.AspNetCore.Html.IHtmlContent DtatGetIconDelete
		(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html)
	{
		if (html is null)
		{
			throw new System
				.ArgumentNullException(paramName: nameof(html));
		}

		var icon =
			TagHelpers.Utility.GetIconDelete();

		return icon;
	}
}
