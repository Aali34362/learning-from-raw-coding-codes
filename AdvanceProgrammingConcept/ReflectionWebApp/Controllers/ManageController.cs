using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReflectionWebApp.Controllers
{
    public class ManageController : Controller
    {
        [HttpGet()]
        public string Secure()
        {
            return "";
        }

        [HttpGet("{boi}")]
        public string Secure(string boi)
        {
            return "";
        }

        public string Secret()
        {
            return "";
        }

        [AllowAnonymous]
        public string Allowed()
        {
            return "";
        }
    }
}
