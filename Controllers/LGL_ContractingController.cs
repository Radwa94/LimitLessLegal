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
    public class LGL_ContractingController : Controller
    {
        private readonly MyDbContext _context;

        public LGL_ContractingController(MyDbContext context)
        {
            _context = context;
        }

        // GET: LGL_Contracting
        public async Task<IActionResult> Index(string id)
        {
           // var loginuser = int.Parse(HttpContext.Session.GetString("userid").ToString());
        
    
            var mydbcontext = _context.LGL_Contractings.Where(x => 1 == 1);
            if(string.IsNullOrEmpty(id))
            {
                return View(await mydbcontext.ToListAsync());
            }
            else
            {
                mydbcontext = mydbcontext.Where(x => x.branchesID.Contains(id) || x.ID_Contracttybe.Contains(id) || x.Year.Contains(id) || x.ManagingDirector.Contains(id));
                return View(await mydbcontext.ToListAsync());
            }
           
        }
        // GET: LGL_Contracting
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.LGL_Contractings.ToListAsync());
        //}

        // GET: LGL_Contracting/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lGL_Contracting = await _context.LGL_Contractings
                .FirstOrDefaultAsync(m => m.contracting_id == id);
            if (lGL_Contracting == null)
            {
                return NotFound();
            }

            return View(lGL_Contracting);
        }

        // GET: LGL_Contracting/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LGL_Contracting/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("contracting_id,branchesID,Address,ID_Contracttybe,writen_date,contract_value,increase_perc,yearsnumber,start_date,end_date,owner_name,tenant_name,leavetime,Insurance_value,ID_TypeAnnualIncrease,Contract_transfer_clause,licensenumber,medicalarea,Licensedate,ManagingDirector,contract_notes,creation_user,last_update_user,Conimg,cause_disable,Year,Startfrom,Montvalue,Year1,Startfrom1,Montvalue1,Year2,Startfrom2,Montvalue2,Year3,Startfrom3,Montvalue3,Year4,Startfrom4,Montvalue4,Year5,Startfrom5,Montvalue5,Year6,Startfrom6,Montvalue6,Year7,Startfrom7,Montvalue7,Year8,Startfrom8,Montvalue8")] LGL_Contracting lGL_Contracting)
        {
            if (ModelState.IsValid)
            {

                var loginuser = int.Parse(HttpContext.Session.GetString("userid").ToString());
                lGL_Contracting.creation_user = loginuser;
                lGL_Contracting.last_update_user = loginuser;


                _context.Add(lGL_Contracting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lGL_Contracting);
        }

        // GET: LGL_Contracting/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lGL_Contracting = await _context.LGL_Contractings.FindAsync(id);
            if (lGL_Contracting == null)
            {
                return NotFound();
            }
            return View(lGL_Contracting);
        }

        // POST: LGL_Contracting/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("contracting_id,branchesID,Address,ID_Contracttybe,writen_date,contract_value,increase_perc,yearsnumber,start_date,end_date,owner_name,tenant_name,leavetime,Insurance_value,ID_TypeAnnualIncrease,Contract_transfer_clause,licensenumber,medicalarea,Licensedate,ManagingDirector,contract_notes,creation_user,last_update_user,Conimg,cause_disable,Year,Startfrom,Montvalue,Year1,Startfrom1,Montvalue1,Year2,Startfrom2,Montvalue2,Year3,Startfrom3,Montvalue3,Year4,Startfrom4,Montvalue4,Year5,Startfrom5,Montvalue5,Year6,Startfrom6,Montvalue6,Year7,Startfrom7,Montvalue7,Year8,Startfrom8,Montvalue8")] LGL_Contracting lGL_Contracting)
        {
            if (id != lGL_Contracting.contracting_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var loginuser = int.Parse(HttpContext.Session.GetString("userid").ToString());
                    lGL_Contracting.creation_user = loginuser;
                    lGL_Contracting.last_update_user = loginuser;

                    _context.Update(lGL_Contracting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LGL_ContractingExists(lGL_Contracting.contracting_id))
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
            return View(lGL_Contracting);
        }

        // GET: LGL_Contracting/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lGL_Contracting = await _context.LGL_Contractings
                .FirstOrDefaultAsync(m => m.contracting_id == id);
            if (lGL_Contracting == null)
            {
                return NotFound();
            }

            return View(lGL_Contracting);
        }

        // POST: LGL_Contracting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lGL_Contracting = await _context.LGL_Contractings.FindAsync(id);
            _context.LGL_Contractings.Remove(lGL_Contracting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LGL_ContractingExists(int id)
        {
            return _context.LGL_Contractings.Any(e => e.contracting_id == id);
        }
    }
}
