using Microsoft.AspNetCore.Mvc;

namespace MusicListFinal.Controllers
{
    public class MusicController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
