using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FrameGeometry1.Data;
using FrameGeometry1.Models;

namespace FrameGeometry1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        /*
        public IActionResult Index()
        {
            return View();
        }
        */

        
        // GET: Geometries
        public async Task<IActionResult> Index()
        {
            //Console.WriteLine(await _context.Geometry.ToListAsync());
            return View(await _context.Geometry.ToListAsync());
        }
        

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
