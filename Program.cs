using BasicAuthorization.Authorization;
using BasicAuthorization.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//Register the handlers in DI. If the handlers inject any of the other services, which has a different lifetime scope, then we may have to use it.
builder.Services.AddSingleton<IAuthorizationHandler, IsAccountNotDisabledHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, IsEmployeeHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, IsVIPCustomerHandler>();

//Register the handlers in DI. This Handler is for the Resource-base Authorization implementation.
builder.Services.AddSingleton<IAuthorizationHandler, DocumentAuthorizationHandler>();

builder.Services.AddRazorPages();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

//Here we build a Claim Based Authorization.
// We can also have a policy with multiple Claims. Below we have a Claim "Permission" with the value "IT" and a separate "IT" Claim. (The user must satisfy both conditions).
//The "Permission" Claim with any other value is not allowed.
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("Admin", policy => policy.RequireClaim("Admin", "IT").RequireClaim("IT"));
//});

//Create the policy using the requirement:
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("canManageProduct", policyBuilder => policyBuilder.AddRequirements(
        new IsAccountEnabledRequirement(),
        new IsAllowedToEditProductRequirement()));
});


//Policy for Resource based authorization:
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("sameAuthorPolicy", policy => policy.AddRequirements(
         new SameAuthorRequirement()));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}").RequireAuthorization();
//app.MapRazorPages().RequireAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
