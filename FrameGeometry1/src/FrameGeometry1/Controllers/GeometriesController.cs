using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FrameGeometry1.Data;
using FrameGeometry1.Models;
using Microsoft.AspNetCore.Authorization;

namespace FrameGeometry1.Controllers
{
    [Authorize]
    public class GeometriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GeometriesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Geometries
        public async Task<IActionResult> Index()
        {
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
        public async Task<IActionResult> Create([Bind("ID,HTA,HTL,STA,STL,bbdrop,chainstay,color,enabled,make,model,reach,size,stack,standover,wheelbase,wheeldiameter")] Geometry geometry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(geometry);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(geometry);
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
            return View(geometry);
        }

        // POST: Geometries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,HTA,HTL,STA,STL,bbdrop,chainstay,color,enabled,make,model,reach,size,stack,standover,wheelbase,wheeldiameter")] Geometry geometry)
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
