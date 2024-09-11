using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Basic_Authentication_Authorization.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [Authorize]
    public IActionResult Secret()
    {
        return View();
    }

    public IActionResult Authenticate()
    {
        var MyApp_Cookie = new List<Claim>()
        {
            new Claim(ClaimTypes.Name,"Bob"),
            new Claim(ClaimTypes.Email,"Bob@gmail.com"),
            new Claim("MyApp_Cookie.Details","Valid User")
        };
        var licenseClaims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name,"Bob The Builder"),
            new Claim(ClaimTypes.Email,"BobTheBuilder@gmail.com"),
            new Claim("DrivingLicense","A+")
        };

        var myAppCookieIdentity = new ClaimsIdentity(MyApp_Cookie, "My App Cookies");
        var licenseIdentity = new ClaimsIdentity(licenseClaims, "Government");
        var userPrincipal = new ClaimsPrincipal(new[] { myAppCookieIdentity, licenseIdentity });
        HttpContext.SignInAsync(userPrincipal);
        return RedirectToAction("Index");
    }
}
/*
Understanding the Flow:

    Accessing a Secured Action (e.g., Secret):
        When you access a protected action (one decorated with [Authorize], like Secret()), ASP.NET Core checks if the user is authenticated.
        If the user is not authenticated, ASP.NET Core automatically redirects the user to the login page, which is defined by config.LoginPath. In your case, this path is set to "/Home/Authenticate".
    The Authenticate() Action Gets Called:
        When an unauthenticated user tries to access /Home/Secret, the framework redirects them to /Home/Authenticate, which is your custom authentication method.
        The Authenticate() action creates claims for the user, signs them in using the cookie-based authentication, and then redirects the user back to the Index() action.
    After Authentication:
        Once the user is signed in, the ClaimsPrincipal is stored in the cookie, and the user is considered authenticated.
        The next time the user tries to access /Home/Secret, ASP.NET Core will allow access because the user is now authenticated.

Triggering the Authentication Flow:

Here’s how the flow works in practice:

    User accesses a protected resource (e.g., /Home/Secret):
        User goes to https://localhost/Home/Secret.
        The [Authorize] attribute kicks in, and since the user is not authenticated, they are redirected to /Home/Authenticate.
    Authenticate() action is invoked:
        The browser hits the /Home/Authenticate URL.
        The Authenticate() action creates the claims, signs in the user, and redirects them back to /Home/Index.
    User is now authenticated:
        The user is now authenticated, and their claims are stored in a cookie.
        If they try to access /Home/Secret again, ASP.NET Core will see that they are authenticated and allow them to access the page.

How to Test It:

    Access /Home/Secret directly in the browser.
        Before the user is authenticated, this will redirect them to /Home/Authenticate.
    Authenticate the user:
        The Authenticate() action will run, sign in the user with a cookie, and redirect them to /Home/Index.
    Access /Home/Secret again:
        Now that the user is authenticated, they will be able to view the Secret page.

Explanation of the Flow:

    Login Redirection: The reason you are redirected to /Home/Authenticate is that the [Authorize] attribute is protecting the Secret() action. Since the user is not logged in, ASP.NET Core follows the LoginPath you defined (/Home/Authenticate) to handle the login process.
    Sign-In Logic: The Authenticate() method builds a ClaimsPrincipal for the user and then calls HttpContext.SignInAsync() to sign them in using the cookie authentication scheme ("CookieAuth"). This creates a session for the user.
    Post-Authentication Redirect: After signing in, the Authenticate() action redirects the user to the Index() action, but the user is now authenticated.

How to Improve the Flow (Optional):

If you want the user to be redirected back to the Secret() page after logging in, you can pass the URL they were trying to access as part of the authentication process:

    Modify the Authenticate() action to return the user to the page they initially requested. You can pass a ReturnUrl parameter.
    In the login redirection, you can pass the original URL to the Authenticate() action as the ReturnUrl parameter, so the user is returned to the original page after login.

Conclusion:

Your Authenticate() method gets called when the user tries to access a secured resource (e.g., Secret()), and they are not authenticated. This action signs them in and redirects them. To trigger this flow, just try accessing the /Home/Secret page when not logged in.

Let me know if you have more questions or need further clarification!
 */