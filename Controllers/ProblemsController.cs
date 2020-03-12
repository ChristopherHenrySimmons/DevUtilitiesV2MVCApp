using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevUtilitiesV2MVCApp.Models;

namespace DevUtilitiesV2MVCApp.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly DevelopmentUtilitiesV2Context _context;

        public ProblemsController(DevelopmentUtilitiesV2Context context)
        {
            _context = context;
        }

        // GET: Problems
        public async Task<IActionResult> Index()
        {
            return View(await _context.Problems.ToListAsync());
        }

        // GET: Problems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problems = await _context.Problems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (problems == null)
            {
                return NotFound();
            }

            return View(problems);
        }

        // GET: Problems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Problems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Solution,SolutionLink,Details,PostedDate,ModifiedDate")] Problems problems)
        {
            if (ModelState.IsValid)
            {
                _context.Add(problems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(problems);
        }

        // GET: Problems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problems = await _context.Problems.FindAsync(id);
            if (problems == null)
            {
                return NotFound();
            }
            return View(problems);
        }

        // POST: Problems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Solution,SolutionLink,Details,PostedDate,ModifiedDate")] Problems problems)
        {
            if (id != problems.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(problems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProblemsExists(problems.Id))
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
            return View(problems);
        }

        // GET: Problems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problems = await _context.Problems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (problems == null)
            {
                return NotFound();
            }

            return View(problems);
        }

        // POST: Problems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var problems = await _context.Problems.FindAsync(id);
            _context.Problems.Remove(problems);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProblemsExists(int id)
        {
            return _context.Problems.Any(e => e.Id == id);
        }
    }
}
