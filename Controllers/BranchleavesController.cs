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
    public class BranchleavesController : Controller
    {
        private readonly MyDbContext _context;

        public BranchleavesController(MyDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index(string id)
        {
            var mydbcontext = _context.branchleaves.Where(x => 1 == 1);
            if (string.IsNullOrEmpty(id))
            {
                return View(await mydbcontext.ToListAsync());
            }
            else
            {
                mydbcontext = mydbcontext.Where(x => x.Company_name.Contains(id) || x.name_licens_holder.Contains(id) || x.Name_responsible_manager.Contains(id));
                return View(await mydbcontext.ToListAsync());
            }

        }


        //// GET: Branchleaves
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.branchleaves.ToListAsync());
        //}

        // GET: Branchleaves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchleave = await _context.branchleaves
                .FirstOrDefaultAsync(m => m.id == id);
            if (branchleave == null)
            {
                return NotFound();
            }

            return View(branchleave);
        }

        // GET: Branchleaves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Branchleaves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,branch,Company_name,name_licens_holder,Name_responsible_manager,date_being_hired,nationaid_owner_img,nationaid_manager_img,card_owner_img,card_manager_img,license_number_owner,License_number_Manager,address,license_number,medical_district")] Branchleave branchleave)
        {
            if (ModelState.IsValid)
            {
                var loginuser = int.Parse(HttpContext.Session.GetString("userid").ToString());
                branchleave.creation_user = loginuser;
                branchleave.last_update_user = loginuser;

                _context.Add(branchleave);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(branchleave);
        }

        // GET: Branchleaves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchleave = await _context.branchleaves.FindAsync(id);
            if (branchleave == null)
            {
                return NotFound();
            }
            return View(branchleave);
        }

        // POST: Branchleaves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,lawsuit_id,year,type,area,court_id,delay_reason,session_next_date,subject,rollno,session_date,decision,requests")] Branchleave branchleave)
        {
            if (id != branchleave.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var loginuser = int.Parse(HttpContext.Session.GetString("userid").ToString());
                    branchleave.creation_user = loginuser;
                    branchleave.last_update_user = loginuser;

                    _context.Update(branchleave);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BranchleaveExists(branchleave.id))
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
            return View(branchleave);
        }

        // GET: Branchleaves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchleave = await _context.branchleaves
                .FirstOrDefaultAsync(m => m.id == id);
            if (branchleave == null)
            {
                return NotFound();
            }

            return View(branchleave);
        }

        // POST: Branchleaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var branchleave = await _context.branchleaves.FindAsync(id);
            _context.branchleaves.Remove(branchleave);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BranchleaveExists(int id)
        {
            return _context.branchleaves.Any(e => e.id == id);
        }
    }
}
