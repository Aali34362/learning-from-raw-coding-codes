var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add cookie-based authentication
builder.Services.AddAuthentication("CookieAuth") // Specify the default scheme name
    .AddCookie("CookieAuth", config =>
    {
        config.Cookie.Name = "MyApp_Cookie";    // Name for the cookie
        config.LoginPath = "/Home/Authenticate"; // Path to redirect to if not authenticated
    });

var app = builder.Build();

// Add middleware to the request pipeline
app.UseRouting();


// Add authentication middleware
app.UseAuthentication(); // Ensure this comes before UseAuthorization
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();
