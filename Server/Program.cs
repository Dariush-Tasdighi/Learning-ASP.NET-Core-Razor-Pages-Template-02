// **************************************************
using Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
// **************************************************

// **************************************************
var webApplicationOptions =
	new Microsoft.AspNetCore.Builder.WebApplicationOptions
	{
		EnvironmentName =
			System.Diagnostics.Debugger.IsAttached ?
			Microsoft.Extensions.Hosting.Environments.Development
			:
			Microsoft.Extensions.Hosting.Environments.Production,
	};

var builder =
	Microsoft.AspNetCore.Builder
	.WebApplication.CreateBuilder(options: webApplicationOptions);
// **************************************************

// **************************************************
// AddHttpContextAccessor() -> using Microsoft.Extensions.DependencyInjection;
builder.Services.AddHttpContextAccessor();
// **************************************************

// **************************************************
builder.Services.AddRouting(options =>
{
	options.LowercaseUrls = true;
	options.LowercaseQueryStrings = true;

	//options.AppendTrailingSlash
	//options.SuppressCheckForUnhandledSecurityMetadata = false;
});
// **************************************************

// **************************************************
// AddRazorPages() -> using Microsoft.Extensions.DependencyInjection;
builder.Services.AddRazorPages();
// **************************************************

// **************************************************
// Configure()-> using Microsoft.Extensions.DependencyInjection;
builder.Services.Configure<Infrastructure.Settings.ApplicationSettings>
	(builder.Configuration.GetSection(key: Infrastructure.Settings.ApplicationSettings.KeyName))
	// AddSingleton()-> using Microsoft.Extensions.DependencyInjection;
	.AddSingleton
	(implementationFactory: serviceType =>
	{
		var result =
			// GetRequiredService()-> using Microsoft.Extensions.DependencyInjection;
			serviceType.GetRequiredService
			<Microsoft.Extensions.Options.IOptions
			<Infrastructure.Settings.ApplicationSettings>>().Value;

		return result;
	});
// **************************************************

// **************************************************
// **************************************************
// **************************************************
builder.Services
	.AddAuthentication(defaultScheme: Infrastructure.Security.Utility.AuthenticationScheme)
	.AddCookie(authenticationScheme: Infrastructure.Security.Utility.AuthenticationScheme);
// **************************************************

// **************************************************
//builder.Services
//	.AddAuthentication(defaultScheme: Infrastructure.Security.Utility.AuthenticationScheme)
//	.AddCookie(authenticationScheme: Infrastructure.Security.Utility.AuthenticationScheme)
//	.AddGoogle(authenticationScheme: Microsoft.AspNetCore.Authentication.Google.GoogleDefaults.AuthenticationScheme,
//	configureOptions: options =>
//	{
//		options.ClientId =
//			builder.Configuration["ApplicationSettings:Authentication:Google:ClientId"];

//		options.ClientSecret =
//			builder.Configuration["ApplicationSettings:Authentication:Google:ClientSecret"];

//		// MapJsonKey() -> using Microsoft.AspNetCore.Authentication;
//		options.ClaimActions.MapJsonKey
//			(claimType: "urn:google:picture", jsonKey: "picture", valueType: "url");
//	})
//	;
// **************************************************
// **************************************************
// **************************************************

// **************************************************
// GetConnectionString() -> using Microsoft.Extensions.Configuration;
var connectionString =
	builder.Configuration.GetConnectionString(name: "ConnectionString");

// AddDbContext -> using Microsoft.Extensions.DependencyInjection;
builder.Services.AddDbContext<Data.DatabaseContext>
	(optionsAction: options =>
	{
		options
			// using Microsoft.EntityFrameworkCore;
			.UseLazyLoadingProxies();

		options
			// using Microsoft.EntityFrameworkCore;
			.UseSqlServer(connectionString: connectionString);
	});
// **************************************************

// **************************************************
var app =
	builder.Build();
// **************************************************

// IsDevelopment() -> using Microsoft.Extensions.Hosting;
if (app.Environment.IsDevelopment())
{
	// **************************************************
	// UseDeveloperExceptionPage() -> using Microsoft.AspNetCore.Builder;
	app.UseDeveloperExceptionPage();
	// **************************************************
}
else
{
	// **************************************************
	// UseGlobalException() -> using Infrastructure.Middlewares;
	app.UseGlobalException();
	// **************************************************

	// **************************************************
	// UseExceptionHandler() -> using Microsoft.AspNetCore.Builder;
	app.UseExceptionHandler("/Errors/Error");
	// **************************************************

	// **************************************************
	// The default HSTS value is 30 days.
	// You may want to change this for production scenarios,
	// see https://aka.ms/aspnetcore-hsts
	// UseHsts() -> using Microsoft.AspNetCore.Builder; 
	app.UseHsts();
	// **************************************************
}

// **************************************************
// UseHttpsRedirection() -> using Microsoft.AspNetCore.Builder;
app.UseHttpsRedirection();
// **************************************************

// **************************************************
// UseStaticFiles() -> using Microsoft.AspNetCore.Builder;
app.UseStaticFiles();
// **************************************************

// **************************************************
// UseActivationKeys() -> using Infrastructure.Middlewares;
app.UseActivationKeys();
// **************************************************

// **************************************************
// UseRouting() -> using Microsoft.AspNetCore.Builder;
app.UseRouting();
// **************************************************

// **************************************************
// UseAuthorization() -> using Microsoft.AspNetCore.Builder;
app.UseAuthentication();
// **************************************************

// **************************************************
// UseAuthorization() -> using Microsoft.AspNetCore.Builder;
app.UseAuthorization();
// **************************************************

// **************************************************
// UseCultureCookie() -> using Infrastructure.Middlewares;
app.UseCultureCookie();
// **************************************************

// **************************************************
// MapRazorPages() -> using Microsoft.AspNetCore.Builder;
app.MapRazorPages();
// **************************************************

// **************************************************
app.Run();
// **************************************************
