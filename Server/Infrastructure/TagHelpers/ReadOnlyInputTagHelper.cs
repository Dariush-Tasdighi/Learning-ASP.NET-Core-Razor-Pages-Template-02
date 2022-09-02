namespace Infrastructure.TagHelpers;

/// <summary>
/// https://stackoverflow.com/questions/51904629/how-to-create-custom-tag-helper-containing-other-tag-helpers
/// https://stackoverflow.com/questions/47547844/tag-helper-embedded-in-another-tag-helpers-code-doesnt-render
/// https://stackoverflow.com/questions/46681692/combine-taghelper-statements
/// </summary>
[Microsoft.AspNetCore.Razor.TagHelpers
	.HtmlTargetElement(tag: "readonly-input",
	TagStructure = Microsoft.AspNetCore.Razor.TagHelpers.TagStructure.WithoutEndTag)]
public class ReadOnlyInputTagHelper :
	Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
{
	public ReadOnlyInputTagHelper
		(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator generator) : base()
	{
		Generator = generator;
	}

	private Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator Generator { get; }

	[Microsoft.AspNetCore.Mvc.ViewFeatures.ViewContext]
	[Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNotBound]
	public Microsoft.AspNetCore.Mvc.Rendering.ViewContext? ViewContext { get; set; }

	[Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeName(name: "asp-for")]
	public Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression? For { get; set; }

	public override async System.Threading.Tasks.Task ProcessAsync
		(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext context,
		Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
	{
		// **************************************************
		var div =
			new Microsoft.AspNetCore.Mvc
			.Rendering.TagBuilder(tagName: "div");

		div.AddCssClass(value: "mb-3");
		// **************************************************

		// **************************************************
		var labelElement =
			await
			CreateLabelElementAsync();

		div.InnerHtml.AppendHtml(encoded: labelElement);
		// **************************************************

		// **************************************************
		var textBoxElement =
			await
			CreateTextBoxElementAsync();

		div.InnerHtml.AppendHtml(encoded: textBoxElement);
		// **************************************************

		// **************************************************
		output.TagName = null;

		output.TagMode =
			Microsoft.AspNetCore.Razor
			.TagHelpers.TagMode.StartTagAndEndTag;

		output.Content.SetHtmlContent(htmlContent: div);
		// **************************************************
	}

	private async System.Threading.Tasks.Task<string> CreateLabelElementAsync()
	{
		var tagBuilder =
			Generator.GenerateLabel
			(viewContext: ViewContext,
			modelExplorer: For.ModelExplorer, expression: For.Name, labelText: null,
			htmlAttributes: new { @class = "form-label" });

		var writer =
			new System.IO.StringWriter();

		tagBuilder.WriteTo(writer: writer,
			encoder: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.Default);

		var result =
			writer.ToString();

		await writer.DisposeAsync();

		return result;
	}

	private async System.Threading.Tasks.Task<string> CreateTextBoxElementAsync()
	{
		Microsoft.AspNetCore.Mvc.Rendering.TagBuilder tagBuilder;

		bool leftToRight = false;
		bool hasBeenCustomized = false;
		object formatedValue = For.Model;

		if (For.ModelExplorer.ModelType == typeof(System.Guid))
		{
			leftToRight = true;
			hasBeenCustomized = true;
		}

		if ((For.ModelExplorer.ModelType == typeof(System.Int16))
			||
			(For.ModelExplorer.ModelType == typeof(System.Int32))
			||
			(For.ModelExplorer.ModelType == typeof(System.Int64)))
		{
			leftToRight = true;
			hasBeenCustomized = true;

			if (formatedValue == null)
			{
				formatedValue =
					Constants.Format.NullValue;
			}
			else
			{
				var valueInteget =
					System.Convert.ToInt64(value: formatedValue);

				formatedValue =
					valueInteget.ToString
					(format: Constants.Format.Integer);

				formatedValue =
					Convert.DigitsToUnicode(value: formatedValue);
			}
		}

		if (For.ModelExplorer.ModelType == typeof(System.DateTime))
		{
			leftToRight = true;
			hasBeenCustomized = true;

			if (formatedValue == null)
			{
				formatedValue =
					Constants.Format.NullValue;
			}
			else
			{
				var valueDateTime =
					(System.DateTime)formatedValue;

				formatedValue =
					valueDateTime.ToString
					(format: Constants.Format.DateTime);

				formatedValue =
					Convert.DigitsToUnicode(value: formatedValue);
			}
		}

		if (hasBeenCustomized)
		{
			tagBuilder =
				Generator.GenerateTextBox
				(viewContext: ViewContext,
				modelExplorer: For.ModelExplorer,
				expression: For.Name, value: formatedValue,
				format: null, htmlAttributes: null);
		}
		else
		{
			tagBuilder =
				Generator.GenerateTextBox
				(viewContext: ViewContext,
				modelExplorer: For.ModelExplorer,
				expression: For.Name, value: For.Model,
				format: null, htmlAttributes: null);
		}

		tagBuilder.AddCssClass(value: "form-control");

		tagBuilder.Attributes.Add(key: "disabled", value: null);
		//tagBuilder.Attributes.Add(key: "disabled", value: "disabled");
		//tagBuilder.Attributes.Add(key: "readonly", value: null);
		//tagBuilder.Attributes.Add(key: "readonly", value: "readonly");

		if (leftToRight)
		{
			tagBuilder.AddCssClass(value: "ltr");
		}

		var writer =
			new System.IO.StringWriter();

		tagBuilder.WriteTo(writer: writer,
			encoder: Microsoft.AspNetCore.Razor.TagHelpers.NullHtmlEncoder.Default);

		var result =
			writer.ToString();

		await writer.DisposeAsync();

		return result;
	}
}
