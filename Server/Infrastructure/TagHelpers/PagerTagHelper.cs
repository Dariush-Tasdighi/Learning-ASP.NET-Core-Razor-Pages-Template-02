using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.TagHelpers
{
	// TO DO:
	[Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElement(tag: "td", Attributes = "page-information-view-model")]
	public class PagerTagHelper : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
	{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public PagerTagHelper
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
			(Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory urlHelperFactory) : base()
		{
			UrlHelperFactory = urlHelperFactory;
		}

		public string? PageAction { get; set; }

		public ViewModels.Shared.PaginationViewModel PageInformationViewModel { get; set; }

		[Microsoft.AspNetCore.Mvc.ViewFeatures.ViewContext]
		[Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNotBound]
		public Microsoft.AspNetCore.Mvc.Rendering.ViewContext ViewContext { get; set; }

		protected Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory UrlHelperFactory { get; }

		#region Css
		public string PageClass { get; set; }

		public string PageClassNormal { get; set; }

		public bool PageClassesEnabled { get; set; }

		public string PageClassSelected { get; set; }
		#endregion /Css

		// Development in progress...
		public override
			void
			Process
			(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext context,
			Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
		{
			Microsoft.AspNetCore.Mvc.IUrlHelper urlHelper =
				UrlHelperFactory.GetUrlHelper(context: ViewContext);

			Microsoft.AspNetCore.Mvc.Rendering.TagBuilder result = new("td");

			Microsoft.AspNetCore.Mvc.Rendering.TagBuilder ulTag = new("ul");

			ulTag.AddCssClass("pagination");

			for (int index = 1; index <= PageInformationViewModel.PageCount; index++)
			{
				// **************************************************
				Microsoft.AspNetCore.Mvc.Rendering.TagBuilder liTag = new("li");

				liTag.AddCssClass(value: $"page-item");
				// **************************************************


				// **************************************************
				Microsoft.AspNetCore.Mvc.Rendering.TagBuilder aTag = new("a");

				aTag.Attributes["href"] =
					// .Action -> using Microsoft.AspNetCore.Mvc
					urlHelper.Action(PageAction, new { PageNumber = index, PageSize = PageInformationViewModel.PageSize });
				// **************************************************

				if (PageClassesEnabled)
				{
					aTag.AddCssClass(PageClass);

					aTag.AddCssClass(index == PageInformationViewModel.PageNumber ? PageClassSelected : PageClassNormal);
				}

				// **************************************************
				aTag.InnerHtml.AppendHtml(encoded: "&nbsp;");
				aTag.InnerHtml.Append(unencoded: $"{index}");
				aTag.InnerHtml.AppendHtml(encoded: "&nbsp;");

				liTag.InnerHtml.AppendHtml(content: aTag);
				ulTag.InnerHtml.AppendHtml(content: liTag);
				// **************************************************
			}

			result.InnerHtml.AppendHtml(content: ulTag);

			output.Content.AppendHtml(htmlContent: result.InnerHtml);
		}
	}
}
