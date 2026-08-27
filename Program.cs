using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inambu_Manufacturing_Pty.Components;
using Inambu_Manufacturing_Pty.Components.Account;
using Inambu_Manufacturing_Pty.Data;
using System.Security.Claims;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Inambu_Manufacturing_Pty.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

// custom services
builder.Services.AddScoped<IMeasurementService, MeasurementService>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// the logout logic for users using the POST method
// app.MapPost("/Account/Logout", async (
//     ClaimsPrincipal user, // clears the auth cookies
//     SignInManager<ApplicationUser> signInManager,
//     [FromForm] string returnUrl) =>
// {
//     await signInManager.SignOutAsync(); // actual logout it clears the authentication cookie server-side.
//     return TypedResults.LocalRedirect($"~/{returnUrl}");
// });

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    // Department Manager (Bob Lockwood) → Finance Director (Alice Liddle) → CEO (Jeff Sidebottom) 
    var newStaff = new[]
    {
        new { Email = "boblockwood1@gmail.com", Name = "Bob Lockwood", Level = StaffLevel.DepartmentManager },
        new { Email = "aliceliddle@gmail.com", Name = "Alice Liddle", Level = StaffLevel.FinanceDirector },
        new { Email = "jeffsidebottom@gmail.com", Name = "Jeff Sidebottom", Level = StaffLevel.CEO }
    };

    foreach (var staff in newStaff)
    {
        if (await userManager.FindByEmailAsync(staff.Email) == null)
        {
            var user = new ApplicationUser
            {
                UserName = staff.Email,
                Email = staff.Email,
                EmailConfirmed = true,
                DisplayName = staff.Name,
                StaffLevel = staff.Level
            };
            await userManager.CreateAsync(user, "SomeStrongPasswor1#");
        }
    }
}

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
