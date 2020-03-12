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
    public class CodeBlocksController : Controller
    {
        private readonly DevelopmentUtilitiesV2Context _context;

        public CodeBlocksController(DevelopmentUtilitiesV2Context context)
        {
            _context = context;
        }

        // GET: CodeBlocks
        public async Task<IActionResult> Index()
        {
            return View(await _context.CodeBlocks.ToListAsync());
        }

        // GET: CodeBlocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeBlocks = await _context.CodeBlocks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (codeBlocks == null)
            {
                return NotFound();
            }

            return View(codeBlocks);
        }

        // GET: CodeBlocks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CodeBlocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Block,Langue,Function,PostedDate,ModifiedDate")] CodeBlocks codeBlocks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(codeBlocks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(codeBlocks);
        }

        // GET: CodeBlocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeBlocks = await _context.CodeBlocks.FindAsync(id);
            if (codeBlocks == null)
            {
                return NotFound();
            }
            return View(codeBlocks);
        }

        // POST: CodeBlocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Block,Langue,Function,PostedDate,ModifiedDate")] CodeBlocks codeBlocks)
        {
            if (id != codeBlocks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(codeBlocks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CodeBlocksExists(codeBlocks.Id))
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
            return View(codeBlocks);
        }

        // GET: CodeBlocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeBlocks = await _context.CodeBlocks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (codeBlocks == null)
            {
                return NotFound();
            }

            return View(codeBlocks);
        }

        // POST: CodeBlocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var codeBlocks = await _context.CodeBlocks.FindAsync(id);
            _context.CodeBlocks.Remove(codeBlocks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CodeBlocksExists(int id)
        {
            return _context.CodeBlocks.Any(e => e.Id == id);
        }
    }
}
