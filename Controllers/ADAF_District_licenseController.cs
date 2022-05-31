using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LimitLessLegal.Controllers
{
    public class ADAF_District_licenseController : Controller
    {
        private readonly MyDbContext _context;

        public ADAF_District_licenseController(MyDbContext context)
        {
            _context = context;
        }

        // GET: ADAF_District_license
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.ADAF_District_licenses.Include(a => a.ADAF_Branches);
            return View(await myDbContext.ToListAsync());
        }

        // GET: ADAF_District_license/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aDAF_District_license = await _context.ADAF_District_licenses
                .Include(a => a.ADAF_Branches)
                .FirstOrDefaultAsync(m => m.district_license_id == id);
            if (aDAF_District_license == null)
            {
                return NotFound();
            }

            return View(aDAF_District_license);
        }

        // GET: ADAF_District_license/Create
        public IActionResult Create()
        {
            ViewData["branch_id"] = new SelectList(_context.ADAF_Branchess, "branch_id", "branch_name");
            return View();
        }

        // POST: ADAF_District_license/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("district_license_id,branch_id,district_license_type_id,license_start,license_end,district_name,district_img,license_notes,creation_user,last_update_user")] ADAF_District_license aDAF_District_license)
        {
            if (ModelState.IsValid)
            {

                var loginuser = int.Parse(HttpContext.Session.GetString("userid").ToString());
                aDAF_District_license.creation_user = loginuser;
                aDAF_District_license.last_update_user = loginuser;

                _context.Add(aDAF_District_license);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["branch_id"] = new SelectList(_context.ADAF_Branchess, "branch_id", "branch_name", aDAF_District_license.branch_id);
            return View(aDAF_District_license);
        }

        // GET: ADAF_District_license/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aDAF_District_license = await _context.ADAF_District_licenses.FindAsync(id);
            if (aDAF_District_license == null)
            {
                return NotFound();
            }
            ViewData["branch_id"] = new SelectList(_context.ADAF_Branchess, "branch_id", "branch_id", aDAF_District_license.branch_id);
            return View(aDAF_District_license);
        }

        // POST: ADAF_District_license/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("district_license_id,branch_id,district_license_type_id,license_start,license_end,district_name,district_img,license_notes,creation_user,last_update_user")] ADAF_District_license aDAF_District_license)
        {
            if (id != aDAF_District_license.district_license_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var loginuser = int.Parse(HttpContext.Session.GetString("userid").ToString());
                    aDAF_District_license.creation_user = loginuser;
                    aDAF_District_license.last_update_user = loginuser;

                    _context.Update(aDAF_District_license);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ADAF_District_licenseExists(aDAF_District_license.district_license_id))
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
            ViewData["branch_id"] = new SelectList(_context.ADAF_Branchess, "branch_id", "branch_id", aDAF_District_license.branch_id);
            return View(aDAF_District_license);
        }

        // GET: ADAF_District_license/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aDAF_District_license = await _context.ADAF_District_licenses
                .Include(a => a.ADAF_Branches)
                .FirstOrDefaultAsync(m => m.district_license_id == id);
            if (aDAF_District_license == null)
            {
                return NotFound();
            }

            return View(aDAF_District_license);
        }

        // POST: ADAF_District_license/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aDAF_District_license = await _context.ADAF_District_licenses.FindAsync(id);
            _context.ADAF_District_licenses.Remove(aDAF_District_license);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ADAF_District_licenseExists(int id)
        {
            return _context.ADAF_District_licenses.Any(e => e.district_license_id == id);
        }
    }
}
