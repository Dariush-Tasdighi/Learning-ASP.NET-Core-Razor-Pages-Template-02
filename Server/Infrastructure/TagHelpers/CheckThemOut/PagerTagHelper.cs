//using Microsoft.AspNetCore.Mvc;

//namespace Infrastructure.TagHelpers.CheckThemOut;

//[Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElement
//	(tag: Constants.HtmlTag.TableData,
//	Attributes = "page-information-view-model")]
//public class PagerTagHelper : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
//{
//	#region Constructor(s)
//#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
//	public PagerTagHelper
//#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
//		(Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory urlHelperFactory) : base()
//	{
//		PageAction = "./Index";

//		UrlHelperFactory = urlHelperFactory;
//	}
//	#endregion /Constructor(s)

//	#region Property(ies)
//	public string PageClass { get; set; }

//	public string? PageAction { get; set; }

//	public string PageDefaultClass { get; set; }

//	public string PageSelectedClass { get; set; }

//	public bool PageClassesEnabled { get; set; }

//	[Microsoft.AspNetCore.Mvc.ViewFeatures.ViewContext]
//	[Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNotBound]
//	public Microsoft.AspNetCore.Mvc.Rendering.ViewContext ViewContext { get; set; }

//	public ViewModels.Shared.PaginationViewModel PageInformationViewModel { get; set; }

//	protected Microsoft.AspNetCore.Mvc.Routing.IUrlHelperFactory UrlHelperFactory { get; }
//	#endregion /Property(ies)

//	#region Process
//	// Development in progress...
//	public override
//		void
//		Process
//		(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext context,
//		Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput output)
//	{
//		var urlHelper =
//			UrlHelperFactory.GetUrlHelper
//			(context: ViewContext);

//		var result =
//			new Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
//			(tagName: Constants.HtmlTag.TableData);

//		var ulTag =
//			new Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
//			(tagName: Constants.HtmlTag.Unorderedlist);

//		ulTag.AddCssClass(value: "pagination");

//		// **************************************************
//		var liTag = BuildListItemTag();

//		var aTag =
//			BuildAnchorTag(urlHelper: urlHelper,
//			caption: Resources.ButtonCaptions.Previous,
//			pageNumber: PageInformationViewModel.PageNumber - 1);

//		if (PageInformationViewModel.PageNumber <= 1)
//		{
//			aTag.AddCssClass(value: Constants.CssClass.Disabled);
//		}
//		// **************************************************


//		// **************************************************
//		liTag.InnerHtml.AppendHtml(content: aTag);

//		ulTag.InnerHtml.AppendHtml(content: liTag);
//		// **************************************************

//		for (int index = 1; index <= PageInformationViewModel.PageCount; index++)
//		{
//			if (index == PageInformationViewModel.PageNumber ||
//				index == PageInformationViewModel.PageNumber - 1 ||
//				index == PageInformationViewModel.PageNumber + 1)
//			{
//				liTag =
//					BuildListItemTag();

//				aTag = BuildAnchorTag
//					(pageNumber: index,
//					urlHelper: urlHelper, caption: index.ToString());

//				liTag.InnerHtml.AppendHtml(content: aTag);

//				ulTag.InnerHtml.AppendHtml(content: liTag);
//			}
//		}

//		// **************************************************
//		liTag = BuildListItemTag();

//		aTag = BuildAnchorTag
//			(urlHelper: urlHelper,
//			caption: Resources.ButtonCaptions.Next,
//			pageNumber: PageInformationViewModel.PageNumber + 1);

//		if (PageInformationViewModel.PageNumber >= PageInformationViewModel.PageCount)
//		{
//			aTag.AddCssClass(value: Constants.CssClass.Disabled);
//		}
//		// **************************************************

//		// **************************************************
//		liTag.InnerHtml.AppendHtml(content: aTag);
//		ulTag.InnerHtml.AppendHtml(content: liTag);
//		// **************************************************

//		result.InnerHtml.AppendHtml(content: ulTag);

//		output.Content.AppendHtml(htmlContent: result.InnerHtml);
//	}
//	#endregion /Process

//	#region Build List Item Tag
//	private static Microsoft.AspNetCore.Mvc.Rendering.TagBuilder BuildListItemTag()
//	{
//		var tag =
//			new Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
//			(tagName: Constants.HtmlTag.ListItem);

//		tag.AddCssClass(value: "page-item");

//		return tag;
//	}
//	#endregion /Build List Item Tag

//	#region Build Anchor Tag
//	private
//		Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
//		BuildAnchorTag
//		(string caption, int pageNumber, IUrlHelper urlHelper)
//	{
//		var tag =
//			new Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
//			(tagName: Constants.HtmlTag.Anchor);

//		tag.Attributes["href"] =
//			// .Action -> using Microsoft.AspNetCore.Mvc
//			urlHelper.Action
//			(action: PageAction,
//			values: new { PageNumber = pageNumber, PageInformationViewModel.PageSize });

//		if (PageClassesEnabled)
//		{
//			var style =
//				pageNumber ==
//				PageInformationViewModel.PageNumber ?
//				PageSelectedClass : PageDefaultClass;

//			var cssClass =
//				$"{PageClass} {style}";

//			tag.AddCssClass(value: cssClass);
//		}

//		tag.InnerHtml.Append(unencoded: caption);

//		return tag;
//	}
//	#endregion /Build Anchor Tag
//}
