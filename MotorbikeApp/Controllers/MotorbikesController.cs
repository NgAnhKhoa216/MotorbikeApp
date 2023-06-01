using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotorbikeApp.Data;
using MotorbikeApp.Models;

namespace MotorbikeApp.Controllers
{
    public class MotorbikesController : Controller
    {
        private readonly MotorbikeAppContext _context;

        public MotorbikesController(MotorbikeAppContext context)
        {
            _context = context;
        }

        // GET: Motorbikes
        public async Task<IActionResult> Index()
        {
              return _context.Motorbike != null ? 
                          View(await _context.Motorbike.ToListAsync()) :
                          Problem("Entity set 'MotorbikeAppContext.Motorbike'  is null.");
        }

        // GET: Motorbikes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Motorbike == null)
            {
                return NotFound();
            }

            var motorbike = await _context.Motorbike
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motorbike == null)
            {
                return NotFound();
            }

            return View(motorbike);
        }

        // GET: Motorbikes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Motorbikes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Branch,Product,Description,Contact,Feedback,Admin")] Motorbike motorbike)
        {
            if (ModelState.IsValid)
            {
                _context.Add(motorbike);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(motorbike);
        }

        // GET: Motorbikes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Motorbike == null)
            {
                return NotFound();
            }

            var motorbike = await _context.Motorbike.FindAsync(id);
            if (motorbike == null)
            {
                return NotFound();
            }
            return View(motorbike);
        }

        // POST: Motorbikes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Branch,Product,Description,Contact,Feedback,Admin")] Motorbike motorbike)
        {
            if (id != motorbike.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motorbike);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotorbikeExists(motorbike.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(motorbike);
        }

        // GET: Motorbikes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Motorbike == null)
            {
                return NotFound();
            }

            var motorbike = await _context.Motorbike
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motorbike == null)
            {
                return NotFound();
            }

            return View(motorbike);
        }

        // POST: Motorbikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Motorbike == null)
            {
                return Problem("Entity set 'MotorbikeAppContext.Motorbike'  is null.");
            }
            var motorbike = await _context.Motorbike.FindAsync(id);
            if (motorbike != null)
            {
                _context.Motorbike.Remove(motorbike);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotorbikeExists(int id)
        {
          return (_context.Motorbike?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
