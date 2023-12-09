using Microsoft.AspNetCore.Mvc;
using MusicListFinal.Models;

namespace MusicListFinal.Controllers
{
    public class ArtistController : Controller
    {
        private readonly ArtistContext _context;

        public ArtistController(ArtistContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Artist());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var artist = _context.Artists.Find(id);

            if (artist == null)
            {
                return NotFound(); //
            }

            return View(artist);
        }

        [HttpPost]
        public IActionResult Edit(Artist artist)
        {
            if (ModelState.IsValid)
            {
                if (artist.ArtistId == 0)
                {
                    _context.Artists.Add(artist);
                }
                else
                {
                    _context.Artists.Update(artist);
                }

                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (artist.ArtistId == 0) ? "Add" : "Edit";
                return View(artist);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var artist = _context.Artists.Find(id);

            if (artist == null)
            {
                return NotFound(); // 
            }

            return View(artist);
        }

        [HttpPost]
        public IActionResult Delete(Artist artist)
        {
            _context.Artists.Remove(artist);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        // New route that takes a variable other than id
        [HttpGet]
        [Route("artist/{name}")]
        public IActionResult ArtistByName(string name)
        {
            var artist = _context.Artists.FirstOrDefault(a => a.Name == name);

            if (artist == null)
            {
                return NotFound(); // Returns a 404 Not Found result if the artist is not found
            }

            return View("Edit", artist);
        }
    }
}
