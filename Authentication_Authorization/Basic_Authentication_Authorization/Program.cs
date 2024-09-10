var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();


app.UseRouting();
app.UseAuthorization();

//app.MapGet("/", () => "Hello World!");

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});


app.Run();
