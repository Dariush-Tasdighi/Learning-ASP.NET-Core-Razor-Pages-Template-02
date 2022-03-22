using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Server.Pages
{
	public class ChangeCultureModel : Infrastructure.BasePageModel
	{
		public ChangeCultureModel
			(Microsoft.Extensions.Options.IOptions
			<Infrastructure.Settings.ApplicationSettings> applicationSettingsOptions) : base()
		{
			ApplicationSettings =
				applicationSettingsOptions.Value;
		}

		private Infrastructure.Settings.ApplicationSettings ApplicationSettings { get; }

		public Microsoft.AspNetCore.Mvc.IActionResult OnGet(string? cultureName)
		{
			// **************************************************
			// GetTypedHeaders -> using Microsoft.AspNetCore.Http;
			var typedHeaders =
				HttpContext.Request.GetTypedHeaders();

			var httpReferer =
				typedHeaders?.Referer?.AbsoluteUri;

			if (string.IsNullOrWhiteSpace(httpReferer))
			{
				return RedirectToPage(pageName: "/Index");
			}
			// **************************************************

			// **************************************************
			var defaultCultureName =
				ApplicationSettings.CultureSettings?.DefaultCultureName;

			var supportedCultureNames =
				ApplicationSettings.CultureSettings?.SupportedCultureNames?
				.ToList()
				;
			// **************************************************

			// **************************************************
			if (string.IsNullOrWhiteSpace(cultureName))
			{
				cultureName =
					defaultCultureName;
			}
			// **************************************************

			// **************************************************
			if (supportedCultureNames == null ||
				supportedCultureNames.Contains(item: cultureName!) == false)
			{
				cultureName =
					defaultCultureName;
			}
			// **************************************************

			// **************************************************
			Infrastructure.Middlewares
				.CultureCookieHandlerMiddleware.SetCulture(cultureName: cultureName);
			// **************************************************

			// **************************************************
			Infrastructure.Middlewares.CultureCookieHandlerMiddleware
				.CreateCookie(httpContext: HttpContext, cultureName: cultureName!);
			// **************************************************

			return Redirect(url: httpReferer);
		}
	}
}
