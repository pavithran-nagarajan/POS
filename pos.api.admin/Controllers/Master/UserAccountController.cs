using Microsoft.AspNetCore.Mvc;

namespace pos.api.admin.Controllers.Master
{
    public class UserAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
