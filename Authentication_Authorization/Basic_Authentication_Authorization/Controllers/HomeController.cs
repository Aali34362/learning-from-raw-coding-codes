using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        return RedirectToAction("Index");
    }

}
