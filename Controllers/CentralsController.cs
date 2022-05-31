using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LimitLessLegal.Controllers
{
    public class CentralsController : Controller
    {
        private readonly MyDbContext _context;

        public CentralsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Centrals
        public async Task<IActionResult> Index(string SearchString)
        {
            var myDbContext = _context.Central.Include(c => c.aDAF_Branches);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Centrals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var central = await _context.Central
                .Include(c => c.aDAF_Branches)
                .FirstOrDefaultAsync(m => m.ID_central == id);
            if (central == null)
            {
                return NotFound();
            }

            return View(central);
        }

        // GET: Centrals/Create
        public IActionResult Create()
        {
            ViewData["branch_id"] = new SelectList(_context.ADAF_Branchess, "branch_id", "branch_name");
            return View();
        }

        // POST: Centrals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_central,branch_id,LandlineNumber1,LandlineNumber,MobileNo,AffiliateCentral,InternetBillValue,Subscriptiondate,Thebunch,CorrectTheSituation,FromCts,ToCts,Note")] Central central)
        {
            if (ModelState.IsValid)
            {
                _context.Add(central);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["branch_id"] = new SelectList(_context.ADAF_Branchess, "branch_id", "branch_name", central.branch_id);
            return View(central);
        }

        // GET: Centrals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var central = await _context.Central.FindAsync(id);
            if (central == null)
            {
                return NotFound();
            }
            ViewData["branch_id"] = new SelectList(_context.ADAF_Branchess, "branch_id", "branch_name", central.branch_id);
            return View(central);
        }

        // POST: Centrals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_central,branch_id,LandlineNumber1,LandlineNumber,MobileNo,AffiliateCentral,InternetBillValue,Subscriptiondate,Thebunch,CorrectTheSituation,FromCts,ToCts,Note")] Central central)
        {
            if (id != central.ID_central)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(central);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CentralExists(central.ID_central))
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
            ViewData["branch_id"] = new SelectList(_context.ADAF_Branchess, "branch_id", "branch_name", central.branch_id);
            return View(central);
        }

        // GET: Centrals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var central = await _context.Central
                .Include(c => c.aDAF_Branches)
                .FirstOrDefaultAsync(m => m.ID_central == id);
            if (central == null)
            {
                return NotFound();
            }

            return View(central);
        }

        // POST: Centrals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var central = await _context.Central.FindAsync(id);
            _context.Central.Remove(central);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CentralExists(int id)
        {
            return _context.Central.Any(e => e.ID_central == id);
        }
    }
}
