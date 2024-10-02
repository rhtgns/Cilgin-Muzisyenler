using Microsoft.AspNetCore.Mvc;

namespace Cilgin_Muzisyenler.Controllers
{
    public class MusicianController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
