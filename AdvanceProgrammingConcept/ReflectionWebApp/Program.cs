using Microsoft.AspNetCore.Authorization;
using ReflectionWebApp;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddAuthentication("Cookie")
                        .AddCookie("Cookie");

        builder.Services.AddAuthorization(config =>
        {
            var policyBuilder = new AuthorizationPolicyBuilder();

            config.DefaultPolicy = policyBuilder
                .AddRequirements(new AutoGeneratedClaim())
                .Build();
        });

        builder.Services.AddScoped<IAuthorizationHandler, AuthHandler>();

        builder.Services.AddSingleton<ClaimsService>();

        builder.Services.AddControllersWithViews();



        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        else
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();
        app.MapDefaultControllerRoute();
        app.MapRazorPages();

        app.Run();
    }
}