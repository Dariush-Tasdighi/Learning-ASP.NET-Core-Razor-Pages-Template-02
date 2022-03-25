using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Middlewares
{
	public class ActivationKeysHandlerMiddleware : object
	{
		#region Static Member(s)
		private static string GetSha256(string value)
		{
			using var mySHA256 = System.Security.Cryptography.SHA256.Create();

			var stringBuilder =
				new System.Text.StringBuilder();

			try
			{
				var valueBytes =
					System.Text.Encoding.UTF8.GetBytes(s: value);

				// Compute the hash of the fileStream.
				byte[] hashBytes =
					mySHA256.ComputeHash(buffer: valueBytes);

				foreach (byte theByte in hashBytes)
				{
					stringBuilder.Append
						(value: theByte.ToString("x2"));
				}

				return stringBuilder.ToString();
			}
			catch
			{
				return string.Empty;
			}
		}

		private static string GetValidActivationKeyByDomain(string domain)
		{
			var result =
				GetSha256(value: domain);

			return result;
		}
		#endregion /Static Member(s)

		public ActivationKeysHandlerMiddleware
			(Microsoft.AspNetCore.Http.RequestDelegate next) : base()
		{
			Next = next;
		}

		private Microsoft.AspNetCore.Http.RequestDelegate Next { get; }

		public async System.Threading.Tasks.Task
			InvokeAsync(Microsoft.AspNetCore.Http.HttpContext httpContext,
			Infrastructure.Settings.ApplicationSettings applicationSettings)
		{
			if (applicationSettings == null ||
				applicationSettings.ActivationKeys == null ||
				applicationSettings.ActivationKeys.Length == 0)
			{
				// WriteAsync() -> using Microsoft.AspNetCore.Http;
				await httpContext.Response.WriteAsync("No Activation Key");

				return;
			}

			var domain =
				httpContext.Request.Host.Value;

			//domain = "dtat.ir";

			var validActivationKey =
				GetValidActivationKeyByDomain(domain: domain);

			if (string.IsNullOrWhiteSpace(validActivationKey))
			{
				// WriteAsync() -> using Microsoft.AspNetCore.Http;
				await httpContext.Response.WriteAsync("No Activation Key");

				return;
			}

			var contains =
				applicationSettings.ActivationKeys
				.Where(current => current.ToLower() == validActivationKey.ToLower())
				.Any();

			if (contains == false)
			{
				// WriteAsync() -> using Microsoft.AspNetCore.Http;
				await httpContext.Response.WriteAsync("No Activation Key");

				return;
			}

			await Next(httpContext);
		}
	}
}
