**************************************************
**************************************************
**************************************************
Session (22)
**************************************************
**************************************************
**************************************************
Tanx Mr. Ali Varposhti - علی ورپشتی

- In 'Server' Project -> In 'Pages' Folder:

	- In '_ChangeCulture.cshtml' Page:

var language =
	supportedCulture.NativeName
	[..(supportedCulture.NativeName.IndexOf('(') - 1)];

var language =
	supportedCulture.Parent.NativeName;
**************************************************

**************************************************
Tanx Mr. Sadegh Dehghani - صادق دهقانی

- In 'Server' Project -> In 'Pages' Folder:

	- In '_ViewStart.cshtml' Page:

	cultureInfo.TextInfo.IsRightToLeft;
	cultureInfo.TwoLetterISOLanguageName;
**************************************************

**************************************************
Tanx: Mr. Nima Sheikhani - نیما شیخانی

- Async:

https://stackoverflow.com/questions/70963014/using-task-run-in-asp-net-core
https://stackoverflow.com/questions/51256520/when-should-i-use-task-run-in-asp-net-core
https://docs.microsoft.com/en-us/aspnet/core/performance/performance-best-practices?view=aspnetcore-6.0
https://stackoverflow.com/questions/60283722/is-it-allowed-to-use-task-run-in-an-asp-net-core-controller

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
Tanx: Mr. Dariush Tasdighi :-)

- In 'Server' Project -> In 'Pages' Folder -> In 'PartialViews' Folder -> In 'Ltr' and 'Rtl' Folders:

	- In '_Footer.cshtml', '_Scripts.cshtml', '_StyleSheets.cshtml' Files

<environment include="Development" exclude="Production">
</environment>

<environment include="Production" exclude="Development">
</environment>
**************************************************

**************************************************
Tanx Mr. Reza Ghadimi:

- In 'program.cs' File:

builder.Services.Configure<Infrastructure.Settings.ApplicationSettings>
	(builder.Configuration.GetSection(key: Infrastructure.Settings.ApplicationSettings.KeyName));

**************************************************
