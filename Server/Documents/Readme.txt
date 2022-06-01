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
**************************************************
**************************************************

**************************************************
**************************************************
**************************************************
Session (43)
**************************************************
**************************************************
**************************************************
1)
- In 'Server' Project ->
	In 'Pages' Folder ->
		In 'Shared' Folder ->
			In 'PartialViews' Folder:

				- Create '_LoginStatus.cshtml' File

Note:

	User

		ClaimsPrincipal

			Identities

			Identity (Main)

				Claims

2)
- In 'Server' Project ->
	In 'Pages' Folder ->
		In 'Shared' Folder ->
			In 'PartialViews' Folder ->
				In 'Ltr' and 'Rtl' Folders:

					- Update '_Header.cshtml' File

3)
- In 'Domain' Project -> In 'SeedWork' Folder:

	- Create 'Constant.cs' File

4)
- In 'Resources' Project:

	- Create 'Messages' Folder

		- Create 'Validations.resx' and 'Validations.fa-IR.resx' Files

5)
- In 'ViewModels' Project:

	- Create 'Pages' Folder

		- Create 'Account' Folder

			- Create 'LoginViewModel' File
			- Create 'RegisterViewModel' File

6)
- In 'Server' Project ->
	In 'Pages' Folder ->
		In 'Shared' Folder ->
			In 'Layouts' Folder ->
				In 'Ltr' and 'Rtl' Folders:

					- Create 'Security.cshtml' File

7)
- In 'Resources' Project ->
	In 'PageTitles.resx' and 'PageTitles.fa-IR.resx' Files:

		- Add Keys:

			- Login
			- Profile
			- Register
			- AccessDenied
			- UpdateProfile
			- TerminateAccount
			- DeactivateAccount


8)
- In 'Resources' Project ->
	In 'ButtonCaptions.resx' and 'ButtonCaptions.fa-IR.resx' Files:

		- Add Keys:

			- Home
			- Login
			- Register
			- ForgotUsername
			- ForgotPassword
			- SendAgainEmailAddressVerificationKey

9)
- In 'Server' Project ->
	In 'Infrastructure' Folder:

		- Create 'Security' Folder:

			- Create 'Utility.cs' File

**************************************************
Session (44)
**************************************************

10)
- In 'Server' Project ->
	In 'Pages' Folder:

		- Create 'Account' Folder

			- Create 'Login.cshtml' Page
			- Create 'Logout.cshtml' Page
			- Create 'Profile.cshtml' Page
			- Create 'Register.cshtml' Page
			- Create 'AccessDenied.cshtml' Page

11)
- In 'Server' Project:

	- Update 'Program.cs' File

// **************************************************
builder.Services
	.AddAuthentication(defaultScheme: Infrastructure.Security.Utility.AuthenticationScheme)
	.AddCookie(authenticationScheme: Infrastructure.Security.Utility.AuthenticationScheme);
// **************************************************

// **************************************************
// UseAuthorization() -> using Microsoft.AspNetCore.Builder;
app.UseAuthentication();
// **************************************************

// **************************************************
// UseAuthorization() -> using Microsoft.AspNetCore.Builder;
app.UseAuthorization();
**************************************************

12)
- In 'Server' Project ->
	In 'Pages' Folder ->
		- In 'Account' Folder:

			- Update 'Login.cshtml.cs' File

				- Remember Me

				- await HttpContext.SignInAsync(...)

			- Update 'Logout.cshtml.cs' File

				- await HttpContext.SignOutAsync(...)

				- [Microsoft.AspNetCore.Authorization.Authorize]

			- Update 'Profile.cshtml.cs' File

				- [Microsoft.AspNetCore.Authorization.Authorize]

				- زمانی که هنوز وارد سامانه نشده‌ایم نشانی ذیل را می‌زنیم
				- به طور خودکار ما را به صفحه ورود هدایت کند

				- https://localhost:7301/account/profile

					- returnUrl

13)
- In 'Server' Project ->
	In 'Pages' Folder ->
		- In 'Admin' Folder ->
			- In 'FileManager' Folder ->

				- Update 'Index.cshtml.cs' File

					- [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]

					- یک‌بار با نقش ادمین و یک‌بار بدون نقش ادمین وارد صفحه ذیل می‌شویم

						- https://localhost:7301/admin/filemanager

							- AccessDenied

14)
- ورود از طریق گوگل و غیره در دوره امنیت آموزش داده می‌شود
**************************************************
**************************************************
**************************************************
