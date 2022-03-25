**************************************************
**************************************************
**************************************************
Session (22)
**************************************************
**************************************************
**************************************************
Tanx Mr. Sadegh Dehghani - صادق دهقانی
**************************************************
- In 'Server' Project -> In 'Pages' Folder:

	- In '_ViewStart.cshtml' Page:

1)
cultureInfo.TextInfo.IsRightToLeft;
cultureInfo.TwoLetterISOLanguageName;
**************************************************

**************************************************
Tanx Mr. Ali Varposhti - علی ورپشتی
**************************************************
1)
- In 'Server' Project -> In 'Pages' Folder:

	- In '_ChangeCulture.cshtml' Page:

var language =
	supportedCulture.NativeName
	[..(supportedCulture.NativeName.IndexOf('(') - 1)];

var language =
	supportedCulture.Parent.NativeName;
**************************************************

**************************************************
Tanx: Mr. Nima Sheikhani - نیما شیخانی
**************************************************
1)
- Async:

https://stackoverflow.com/questions/70963014/using-task-run-in-asp-net-core
https://stackoverflow.com/questions/51256520/when-should-i-use-task-run-in-asp-net-core
https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices?view=aspnetcore-6.0
https://stackoverflow.com/questions/60283722/is-it-allowed-to-use-task-run-in-an-asp-net-core-controller

2)
- In 'program.cs' File:

var webApplicationOptions =
	new Microsoft.AspNetCore.Builder.WebApplicationOptions
	{
		//EnvironmentName =
		//	Microsoft.Extensions.Hosting.Environments.Production,

		EnvironmentName =
			Microsoft.Extensions.Hosting.Environments.Development,
	};

var webApplicationOptions =
	new Microsoft.AspNetCore.Builder.WebApplicationOptions
	{
		EnvironmentName =
			System.Diagnostics.Debugger.IsAttached ?
			Microsoft.Extensions.Hosting.Environments.Development
			:
			Microsoft.Extensions.Hosting.Environments.Production
	};
**************************************************

**************************************************
Tanx Mr. Reza Ghadimi - رضا قدیمی
**************************************************
1)
- In 'program.cs' File:

builder.Services.Configure<Infrastructure.Settings.ApplicationSettings>
	(builder.Configuration.GetSection(key: Infrastructure.Settings.ApplicationSettings.KeyName));

builder.Services.Configure<Infrastructure.Settings.ApplicationSettings>
	(builder.Configuration.GetSection(key: Infrastructure.Settings.ApplicationSettings.KeyName))
	.AddSingleton
	(implementationFactory: serviceType =>
	{
		var result =
			serviceType.GetRequiredService
			<Microsoft.Extensions.Options.IOptions
			<Infrastructure.Settings.ApplicationSettings>>().Value;

		return result;
	});

2)
- In 'Server' Project -> In 'Pages' Folder:

	- In 'ChangeCulture.cshtml.cs' File:

- In 'Server' Project -> In 'Infrastructure' Folder -> In 'Middlewares' Folder:

	- In 'CultureCookieHandlerMiddleware.cs' File:

- In 'Server' Project -> In 'Pages' Folder -> In 'PartialViews' Folder:

	- In '_ChangeCulture.cshtml' File:

Microsoft.Extensions.Options.IOptions<Infrastructure.Settings.ApplicationSettings>
->
Infrastructure.Settings.ApplicationSettings
**************************************************

**************************************************
Tanx: Mr. Dariush Tasdighi :-)
**************************************************
1)
- In 'Server' Project -> In 'Pages' Folder -> In 'PartialViews' Folder -> In 'Ltr' and 'Rtl' Folders:

	- In '_Footer.cshtml', '_Scripts.cshtml', '_StyleSheets.cshtml' Files:

<environment include="Development" exclude="Production">
</environment>

<environment include="Production" exclude="Development">
</environment>

2)
- In 'Server' Project -> In 'Pages' Folder -> In 'PartialViews' Folder -> In 'Ltr' and 'Rtl' Folders:

	- In '_Footer.cshtml' File:

@inject Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor

- In 'Server' Project -> In 'Program.cs' File:

services.AddHttpContextAccessor();

3)
- In 'Server' Project:

	- Update 'appsettings.json' File
	- Update 'appsettings.Development.json' File

- In 'Server' Project -> In 'Infrastructure' Folder -> In 'Settings' Folder:

	- Create 'FileManagerSettings.cs' File
	- Update 'ApplicationSettings.cs' File

- In 'Server' Project -> In 'Infrastructure' Folder -> In 'Middlewares' Folder:

	- Create 'ActivationKeysHandlerMiddleware.cs' File

4)
- Publish
**************************************************
