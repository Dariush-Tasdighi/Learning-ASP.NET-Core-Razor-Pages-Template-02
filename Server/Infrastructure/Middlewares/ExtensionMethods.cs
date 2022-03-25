using Microsoft.AspNetCore.Builder;

namespace Infrastructure.Middlewares
{
	public static class ExtensionMethods
	{
		static ExtensionMethods()
		{
		}

		public static Microsoft.AspNetCore.Builder.IApplicationBuilder
			UseCultureCookie(this Microsoft.AspNetCore.Builder.IApplicationBuilder app)

		{
			// UseMiddleware -> //using Microsoft.AspNetCore.Builder;
			return app.UseMiddleware<CultureCookieHandlerMiddleware>();
		}

		public static Microsoft.AspNetCore.Builder.IApplicationBuilder
			UseGlobalException(this Microsoft.AspNetCore.Builder.IApplicationBuilder app)
		{
			// UseMiddleware -> //using Microsoft.AspNetCore.Builder;
			return app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
		}

		public static Microsoft.AspNetCore.Builder.IApplicationBuilder
			UseActivationKeys(this Microsoft.AspNetCore.Builder.IApplicationBuilder app)
		{
			// UseMiddleware -> //using Microsoft.AspNetCore.Builder;
			return app.UseMiddleware<ActivationKeysHandlerMiddleware>();
		}
	}
}
