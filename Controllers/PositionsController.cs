using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace lab3.Controllers
{
    public class PositionsController : Controller
    {
        private readonly UniversityContext _context;

        public PositionsController(UniversityContext context)
        {
            _context = context;
        }

        // GET: Positions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Position.ToListAsync());
        }

        // GET: Positions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _context.Position
                .FirstOrDefaultAsync(m => m.PositionID == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // GET: Positions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Positions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PositionID,PositionName,HourlyRate")] Position position)
        {
            if (ModelState.IsValid)
            {
                _context.Add(position);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(position);
        }

        // GET: Positions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _context.Position.FindAsync(id);
            if (position == null)
            {
                return NotFound();
            }
            return View(position);
        }

        // POST: Positions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PositionID,PositionName,HourlyRate")] Position position)
        {
            if (id != position.PositionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(position);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PositionExists(position.PositionID))
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
            return View(position);
        }

        // GET: Positions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _context.Position
                .FirstOrDefaultAsync(m => m.PositionID == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // POST: Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var position = await _context.Position.FindAsync(id);
            if (position != null)
            {
                _context.Position.Remove(position);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PositionExists(int id)
        {
            return _context.Position.Any(e => e.PositionID == id);
        }
    }
}
