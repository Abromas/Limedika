using Azure.Identity;
using Limedika.Business;
using Limedika.Components;
using Limedika.Data;
using Limedika.Models;
using Limedika.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var keyVaultEndpoint = builder.Configuration[Constants.AppSettings.AzureKeyVaultEndpoint];

if (!string.IsNullOrEmpty(keyVaultEndpoint))
{
    try
    {
        var keyVaultUri = new Uri(keyVaultEndpoint);
        builder.Configuration.AddAzureKeyVault(keyVaultUri, new DefaultAzureCredential());
    }
    catch (Exception ex)
    {
        var logger = LoggerFactory.Create(loggingBuilder => loggingBuilder.AddConsole()).CreateLogger("KeyVault");
        logger.LogError(ex, "An error occurred while accessing Azure Key Vault. Falling back to appsettings.");
    }
}
else
{
    var logger = LoggerFactory.Create(loggingBuilder => loggingBuilder.AddConsole()).CreateLogger("KeyVault");
    logger.LogWarning("Azure Key Vault endpoint is not configured. Falling back to appsettings.");
}

// Conditionally add appsettings.json configuration for development
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

    builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(Constants.AppSettings.DbConnectionStringDevelopment)));
}
else
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString(Constants.KeyVaultKeys.DatabaseConnectionString)));
}

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCustomServices();

// Configure the file size limit
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 10 * 1024 * 1024; // 10 MB
    options.ValueCountLimit = int.MaxValue; // If needed, for large forms
    options.MultipartHeadersLengthLimit = int.MaxValue; // If needed, for large headers
});

if (builder.Environment.IsDevelopment())
{
    builder.Services.Configure<PostItApiSettings>(builder.Configuration.GetSection("PostItApi"));
}
else
{
    var postItApiSettings = new PostItApiSettings
    {
        BaseUrl = builder.Configuration[Constants.KeyVaultKeys.PostItApiBaseUrl],
        ApiKey = builder.Configuration[Constants.KeyVaultKeys.PostItApiKey]
    };
    builder.Services.AddSingleton(postItApiSettings);
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
