using Data.EntityModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKorpa.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class SlikaController : Controller
    {
        //private readonly ImageDbContext _context;

        //public ImageController(ImageDbContext context)
        //{
        //    _context = context;
        //}

        // GET: Image
        public async Task<IActionResult> Index()
        { return View(); }

        // GET: Image/Create
        public IActionResult Create()
        { return View(); }

        // POST: Image/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageId,Title,ImageName")] Slika imageModel)
        { return View(); }

        // GET: Image/Delete/5
        public async Task<IActionResult> Delete(int? id)
        { return View(); }

        // POST: Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        { return View(); }
    }
}
