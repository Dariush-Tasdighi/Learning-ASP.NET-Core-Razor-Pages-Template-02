//using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.TagHelpers
{
	// TO DO:
	[Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElement(tag: "td", Attributes = "page-information")]
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

		public override
			void
			Process
			(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext context,
			Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
		{
		}
	}
}

