using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);
TokenCredential identity = builder.Environment.IsDevelopment() ? new DefaultAzureCredential() : 
new ManagedIdentityCredential();

builder.Configuration.AddAzureKeyVault(
    new Uri("https://threadmongokeyapril2023.vault.azure.net/"),
    identity
);
// Add services to the container.
// builder.Services.AddRazorPages();
// builder.Services.AddServerSideBlazor();
builder.ConfigureServices();

var app = builder.Build();

// RegisteredWaitHandle Syncfusin License
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzEwODU5QDMyMzAyZTMyMmUzMGZGMDdFRGd4ZVhJS2dDK1RPWDRXc0NsdjJPRGgxWDdVSmYveXVuNFZRdEE9");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseRewriter(
    new RewriteOptions().Add(
        context =>{
            if(context.HttpContext.Request.Path =="/MicrosoftIdentity/Account/SignedOut")
            {
                context.HttpContext.Response.Redirect("/Identity/Account/Logout");
            }
        }
    )
);

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
