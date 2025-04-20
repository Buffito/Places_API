using Microsoft.AspNetCore.Mvc;

namespace Places_API.Controllers
{
    public class PlaceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
