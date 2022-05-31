using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LimitLessLegal.Controllers
{
    public class JudgmentsController : Controller
    {
        private readonly MyDbContext _context;

        public JudgmentsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Judgments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Judgment.ToListAsync());
        }

        // GET: Judgments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var judgment = await _context.Judgment
                .FirstOrDefaultAsync(m => m.ID_Judgment == id);
            if (judgment == null)
            {
                return NotFound();
            }

            return View(judgment);
        }

        // GET: Judgments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Judgments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Judgment,Judgmentn")] Judgment judgment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(judgment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(judgment);
        }

        // GET: Judgments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var judgment = await _context.Judgment.FindAsync(id);
            if (judgment == null)
            {
                return NotFound();
            }
            return View(judgment);
        }

        // POST: Judgments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Judgment,Judgmentn")] Judgment judgment)
        {
            if (id != judgment.ID_Judgment)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(judgment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JudgmentExists(judgment.ID_Judgment))
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
            return View(judgment);
        }

        // GET: Judgments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var judgment = await _context.Judgment
                .FirstOrDefaultAsync(m => m.ID_Judgment == id);
            if (judgment == null)
            {
                return NotFound();
            }

            return View(judgment);
        }

        // POST: Judgments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var judgment = await _context.Judgment.FindAsync(id);
            _context.Judgment.Remove(judgment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JudgmentExists(int id)
        {
            return _context.Judgment.Any(e => e.ID_Judgment == id);
        }
    }
}
