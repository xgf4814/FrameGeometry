using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FrameGeometry.Data;
using FrameGeometry.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.IO;
using CsvHelper;

namespace FrameGeometry.Controllers
{
    [Authorize]
    public class GeometriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private UserManager<ApplicationUser> _userManager;

        public GeometriesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Geometries
        public async Task<IActionResult> Index()
        {
            ViewData["UserGUID"] = _userManager.GetUserId(User);
            return View(await _context.Geometry.ToListAsync());
        }

        // GET: Geometries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var geometry = await _context.Geometry.SingleOrDefaultAsync(m => m.ID == id);
            if (geometry == null)
            {
                return NotFound();
            }

            return View(geometry);
        }

        // GET: Geometries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Geometries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,HTA,HTL,STA,STL,bbdrop,chainstay,color,enabled,make,model,reach,size,stack,standover,wheelbase,wheeldiameter,userGUID")] Geometry geometry)
        {
            if (ModelState.IsValid)
            {
                geometry.userGUID = _userManager.GetUserId(User);
                _context.Add(geometry);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(geometry);
        }

        // GET: Geometries/Upload
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(IFormFile file_in)
        {
            // full path to file in temp location
            var filePath = Path.GetTempFileName();
            
            var s = string.Empty;
            using (var reader = new StreamReader(file_in.OpenReadStream()))
            {
                var csv = new CsvReader(reader);
                csv.ReadHeader();
                var records = csv.GetRecords<Geometry>();
                foreach (Geometry g in records)
                {
                    g.userGUID = _userManager.GetUserId(User);
                    _context.Add(g);
                }
                await _context.SaveChangesAsync();
            }
            
            
            //return Ok(new { filePath, s, file_in.Length });
            return RedirectToAction("Index");

        }

        // GET: Geometries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var geometry = await _context.Geometry.SingleOrDefaultAsync(m => m.ID == id);
            if (geometry == null)
            {
                return NotFound();
            }
            /*
            if (geometry.userGUID != _userManager.GetUserId(User) && _userManager.GetUserName(User) != "xanderfiss@gmail.com")
            {
                return RedirectToAction("Index");
            }
            */
            return View(geometry);
        }

        // POST: Geometries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,HTA,HTL,STA,STL,bbdrop,chainstay,color,enabled,make,model,reach,size,stack,standover,wheelbase,wheeldiameter,userGUID")] Geometry geometry)
        {
            if (id != geometry.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(geometry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeometryExists(geometry.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            /*
            if (geometry.userGUID != _userManager.GetUserId(User) && _userManager.GetUserName(User) != "xanderfiss@gmail.com")
            {
                return RedirectToAction("Index");
            }
            */
            return View(geometry);
        }

        // GET: Geometries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var geometry = await _context.Geometry.SingleOrDefaultAsync(m => m.ID == id);
            if (geometry == null)
            {
                return NotFound();
            }
            /*
            if (geometry.userGUID != _userManager.GetUserId(User) && _userManager.GetUserName(User) != "xanderfiss@gmail.com")
            {
                return RedirectToAction("Index");
            }
            */
            return View(geometry);
        }

        // POST: Geometries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var geometry = await _context.Geometry.SingleOrDefaultAsync(m => m.ID == id);
            _context.Geometry.Remove(geometry);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool GeometryExists(int id)
        {
            return _context.Geometry.Any(e => e.ID == id);
        }
    }
}
