using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using PlaDiC.Data;
using PlaDiC.WebPortal;
using PlaDiC.WebPortal.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

// Add services to the container.
builder.Services.AddControllersWithViews();




var connI = builder.Configuration.GetConnectionString("IdentityConnection");
var connD = builder.Configuration.GetConnectionString("DataConnection");

ViewHelper.Configure(connD!);

builder.Services.AddDbContext<PlaDiCIdentityDBContext>(o => o.UseFirebird(connI));
builder.Services.AddDbContext<PlaDiCDBContext>(o => o.UseFirebird(connD, b=>b.MigrationsAssembly("PlaDiC.WebPortal")));

builder.Services.AddAuthentication()
    //.AddCookie(IdentityConstants.ApplicationScheme)
    .AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

builder.Services
    .AddIdentity<User, Role>(
    o =>
    {
        o.Password.RequireDigit = true;
        o.Password.RequireLowercase = true;
        o.Password.RequireUppercase = true;
        o.Password.RequireNonAlphanumeric = false;
        o.Password.RequiredLength = 8;
        o.User.RequireUniqueEmail = true;

        o.SignIn.RequireConfirmedEmail = true;

        o.Lockout.AllowedForNewUsers = true;
        o.Lockout.MaxFailedAccessAttempts = 5;

    }
    )
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<PlaDiCIdentityDBContext>()
    .AddApiEndpoints()
    ;
 
builder.Services.AddEndpointsApiExplorer() ;
builder.Services.AddSwaggerGen() ;

// Enable directory browsing
builder.Services.AddDirectoryBrowser();


var app = builder.Build();

app.MapIdentityApi<User>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseHttpsRedirection();
}
else { 
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

#region Directory browsing

var fileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.WebRootPath, "images/gallery"));
var requestPath = "/gallery";

// Enable displaying browser links.
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = fileProvider,
    RequestPath = requestPath
});

app.UseDirectoryBrowser(new DirectoryBrowserOptions
{
    FileProvider = fileProvider,
    RequestPath = requestPath
});

#endregion

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}");


app.MapControllerRoute(
    name: "viewName",
    pattern: "{controller}/{*viewName}",
    defaults: new { action = "DisplayAnyView" });


app.Run();
