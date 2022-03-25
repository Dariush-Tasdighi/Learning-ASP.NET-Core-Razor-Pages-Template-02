// **************************************************
using Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
// GetConnectionString() -> using Microsoft.Extensions.Configuration;
var connectionString =
	builder.Configuration.GetConnectionString("ConnectionString");

// AddDbContext -> using Microsoft.Extensions.DependencyInjection;
builder.Services.AddDbContext<Persistence.DatabaseContext>(options =>
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
// UseRouting() -> using Microsoft.AspNetCore.Builder;
app.UseRouting();
// **************************************************

// **************************************************
// UseAuthorization() -> using Microsoft.AspNetCore.Builder;
//app.UseAuthentication();
// **************************************************

// **************************************************
// UseAuthorization() -> using Microsoft.AspNetCore.Builder;
//app.UseAuthorization();
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
