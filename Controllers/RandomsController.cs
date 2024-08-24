using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practice1.Data;
using Practice1.Models;

namespace Practice1.Controllers
{
    public class RandomsController : Controller
    {
        private readonly Practice1Context _context;

        public RandomsController(Practice1Context context)
        {
            _context = context;
        }

        // GET: Randoms
        public async Task<IActionResult> Index(string randomsDescription, string searchString)
        {
            if (_context.Randoms == null)
            {
                return Problem("Entity set 'RandomsDescription.Randoms'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> descriptionQuery = from m in _context.Randoms
                                            orderby m.Description
                                            select m.Description;
            var randoms = from m in _context.Randoms
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                randoms = randoms.Where(s => s.Title!.ToUpper().Contains(searchString.ToUpper()));
            }

            if (!string.IsNullOrEmpty(randomsDescription))
            {
                randoms = randoms.Where(x => x.Description == randomsDescription);
            }

            var randomsDescriptionVM = new RandomsDescriptionViewModel
            {
                Descriptions = new SelectList(await descriptionQuery.Distinct().ToListAsync()),
                RandomList = await randoms.ToListAsync()
            };

            return View(randomsDescriptionVM);
        }

        // GET: Randoms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Randoms == null)
            {
                return NotFound();
            }

            var randoms = await _context.Randoms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (randoms == null)
            {
                return NotFound();
            }

            return View(randoms);
        }

        // GET: Randoms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Randoms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Description,Number")] Randoms randoms)
        {
            if (ModelState.IsValid)
            {
                _context.Add(randoms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(randoms);
        }

        // GET: Randoms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Randoms == null)
            {
                return NotFound();
            }

            var randoms = await _context.Randoms.FindAsync(id);
            if (randoms == null)
            {
                return NotFound();
            }
            return View(randoms);
        }

        // POST: Randoms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Description,Number")] Randoms randoms)
        {
            if (id != randoms.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(randoms);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RandomsExists(randoms.Id))
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
            return View(randoms);
        }

        // GET: Randoms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Randoms == null)
            {
                return NotFound();
            }

            var randoms = await _context.Randoms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (randoms == null)
            {
                return NotFound();
            }

            return View(randoms);
        }

        // POST: Randoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Randoms == null)
            {
                return Problem("Entity set 'Practice1Context.Randoms'  is null.");
            }
            var randoms = await _context.Randoms.FindAsync(id);
            if (randoms != null)
            {
                _context.Randoms.Remove(randoms);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RandomsExists(int id)
        {
          return (_context.Randoms?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
