namespace Infrastructure
{
	public static class HtmlHelpers : object
	{
		static HtmlHelpers()
		{
		}

		public static string DefaultValue
		{
			get
			{
				return "-----";
			}
		}

		public static Microsoft.AspNetCore.Html.IHtmlContent DtatDisplayPageHeader
			(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html, string title)
		{
			if (html is null)
			{
				throw new System
					.ArgumentNullException(paramName: nameof(html));
			}

			//var result =
			//	$"<h3 class='text-center'>{title}</h3>";

			//return html.Raw(result);

			var heading =
				new Microsoft.AspNetCore.Mvc.Rendering.TagBuilder(tagName: "h3");

			heading.AddCssClass(value: "text-center");

			heading.InnerHtml.Append(unencoded: title);

			return heading;
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

		public static Microsoft.AspNetCore.Html.IHtmlContent DtatDisplayTdBoolean
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

		public static Microsoft.AspNetCore.Html.IHtmlContent DtatDisplayInteger
			(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html, long? value)
		{
			if (value.HasValue == false)
			{
				return html.Raw(DefaultValue);
			}

			var result =
				value.Value.ToString(format: "#,##0");

			result =
				Convert.DigitsToUnicode(value: result);

			return html.Raw(result);
		}

		public static Microsoft.AspNetCore.Html.IHtmlContent DtatDisplayTdInteger
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

		public static Microsoft.AspNetCore.Html.IHtmlContent DtatDisplayTdRowNumber
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

		public static Microsoft.AspNetCore.Html.IHtmlContent DtatDisplayDateTime
			(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html, System.DateTime? value)
		{
			if (value.HasValue == false)
			{
				return html.Raw(DefaultValue);
			}

			var result =
				value.Value.ToString
				(format: "yyyy/MM/dd - HH:mm:ss");

			result =
				Convert.DigitsToUnicode(value: result);

			return html.Raw(result);
		}

		public static Microsoft.AspNetCore.Html.IHtmlContent DtatDisplayTdDateTime
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

		public static Microsoft.AspNetCore.Html.IHtmlContent DtatDisplayIconList
			(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html)
		{
			if (html is null)
			{
				throw new System
					.ArgumentNullException(paramName: nameof(html));
			}

			var i =
				new Microsoft.AspNetCore.Mvc
				.Rendering.TagBuilder(tagName: "i");

			i.AddCssClass(value: "bi");
			i.AddCssClass(value: "bi-person-workspace");

			return i;
		}

		public static Microsoft.AspNetCore.Html.IHtmlContent DtatDisplayIconCreate
			(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html)
		{
			if (html is null)
			{
				throw new System
					.ArgumentNullException(paramName: nameof(html));
			}

			var i =
				new Microsoft.AspNetCore.Mvc
				.Rendering.TagBuilder(tagName: "i");

			i.AddCssClass(value: "bi");
			i.AddCssClass(value: "bi-person-workspace");

			return i;
		}

		public static Microsoft.AspNetCore.Html.IHtmlContent DtatDisplayIconDetails
			(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html)
		{
			if (html is null)
			{
				throw new System
					.ArgumentNullException(paramName: nameof(html));
			}

			var i =
				new Microsoft.AspNetCore.Mvc
				.Rendering.TagBuilder(tagName: "i");

			i.AddCssClass(value: "bi");
			i.AddCssClass(value: "bi-zoom-in");

			return i;
		}

		public static Microsoft.AspNetCore.Html.IHtmlContent DtatDisplayIconUpdate
			(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html)
		{
			if (html is null)
			{
				throw new System
					.ArgumentNullException(paramName: nameof(html));
			}

			var i =
				new Microsoft.AspNetCore.Mvc
				.Rendering.TagBuilder(tagName: "i");

			i.AddCssClass(value: "bi");
			i.AddCssClass(value: "bi-pencil-fill");

			return i;
		}

		public static Microsoft.AspNetCore.Html.IHtmlContent DtatDisplayIconDelete
			(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html)
		{
			if (html is null)
			{
				throw new System
					.ArgumentNullException(paramName: nameof(html));
			}

			var i =
				new Microsoft.AspNetCore.Mvc
				.Rendering.TagBuilder(tagName: "i");

			i.AddCssClass(value: "bi");
			i.AddCssClass(value: "bi-trash-fill");

			return i;
		}

		public static Microsoft.AspNetCore.Html.IHtmlContent DtatDisplayButtonCreate
			(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html)
		{
			if (html is null)
			{
				throw new System
					.ArgumentNullException(paramName: nameof(html));
			}

			var i =
				new Microsoft.AspNetCore.Mvc
				.Rendering.TagBuilder(tagName: "i");

			i.AddCssClass(value: "bi");
			i.AddCssClass(value: "bi-person-workspace");

			var button =
				new Microsoft.AspNetCore.Mvc
				.Rendering.TagBuilder(tagName: "button");

			button.AddCssClass(value: "btn");
			button.AddCssClass(value: "btn-primary");

			button.Attributes.Add
				(key: "type", value: "submit");

			button.InnerHtml.AppendHtml(content: i);
			button.InnerHtml.Append(unencoded: Resources.ButtonCaptions.Create);

			return button;
		}

		public static Microsoft.AspNetCore.Html.IHtmlContent DtatDisplayButtonReset
			(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html)
		{
			if (html is null)
			{
				throw new System
					.ArgumentNullException(paramName: nameof(html));
			}

			var i =
				new Microsoft.AspNetCore.Mvc
				.Rendering.TagBuilder(tagName: "i");

			i.AddCssClass(value: "bi");
			i.AddCssClass(value: "bi-person-workspace");

			var button =
				new Microsoft.AspNetCore.Mvc
				.Rendering.TagBuilder(tagName: "button");

			button.AddCssClass(value: "btn");
			button.AddCssClass(value: "btn-secondary");

			button.Attributes.Add
				(key: "type", value: "reset");

			button.InnerHtml.AppendHtml(content: i);
			button.InnerHtml.Append(unencoded: Resources.ButtonCaptions.Reset);

			return button;
		}

		public static Microsoft.AspNetCore.Html.IHtmlContent DtatDisplayButtonUpdate
			(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html)
		{
			if (html is null)
			{
				throw new System
					.ArgumentNullException(paramName: nameof(html));
			}

			var icon =
				DtatDisplayIconUpdate(html: html);

			var button =
				new Microsoft.AspNetCore.Mvc
				.Rendering.TagBuilder(tagName: "button");

			button.AddCssClass(value: "btn");
			button.AddCssClass(value: "btn-primary");

			button.Attributes.Add
				(key: "type", value: "submit");

			button.InnerHtml.AppendHtml(content: icon);
			button.InnerHtml.Append(unencoded: Resources.ButtonCaptions.Save);

			return button;
		}

		public static Microsoft.AspNetCore.Html.IHtmlContent DtatDisplayButtonDelete
			(this Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper html)
		{
			if (html is null)
			{
				throw new System
					.ArgumentNullException(paramName: nameof(html));
			}

			var icon =
				DtatDisplayIconDelete(html: html);

			var button =
				new Microsoft.AspNetCore.Mvc
				.Rendering.TagBuilder(tagName: "button");

			button.AddCssClass(value: "btn");
			button.AddCssClass(value: "btn-danger");

			button.Attributes.Add
				(key: "type", value: "submit");

			button.InnerHtml.AppendHtml(content: icon);
			button.InnerHtml.Append(unencoded: Resources.ButtonCaptions.Delete);

			return button;
		}
	}
}
