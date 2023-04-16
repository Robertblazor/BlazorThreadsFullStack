using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Syncfusion.Blazor;

namespace BlazorThreadsUi
{
    public static class RegisterServices
    {
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor().AddMicrosoftIdentityConsentHandler();
            builder.Services.AddMemoryCache();
            builder.Services.AddControllersWithViews().AddMicrosoftIdentityUI();
            builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                            .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAdB2C"));
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin",policy =>
                {
                    policy.RequireClaim("jobTitle","Admin");
                }
                    );
            });
            builder.Services.AddSingleton<IDbConnection, DbConnection>();
            builder.Services.AddScoped<IMetricExternalCollection, MongoMetricExternalCollection>();
            builder.Services.AddScoped<IMetricInternalCollection, MongoMetricInternalCollection>();
            builder.Services.AddScoped<IMetricWireCollection, MongoMetricWireCollection>();
            builder.Services.AddScoped<IStandardExternalCollection, MongoStandardExternalCollection>();
            builder.Services.AddScoped<IStandardInternalCollection,MongoStandardInternalCollection>();
            builder.Services.AddScoped<IStandardWireCollection, MongoStandardWireCollection>();
            builder.Services.AddSingleton<IUserCollection, MongoUserCollection>();
            // builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });
        }

    }
}