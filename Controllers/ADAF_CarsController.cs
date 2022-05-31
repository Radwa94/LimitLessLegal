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
    public class ADAF_CarsController : Controller
    {
        private readonly MyDbContext _context;

        public ADAF_CarsController(MyDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string id)
        {
            var mydbcontext = _context.ADAF_Carss.Where(x => 1 == 1);
            if (string.IsNullOrEmpty(id))
            {
                return View(await mydbcontext.ToListAsync());
            }
            else
            {
                mydbcontext = mydbcontext.Where(x => x.car_board.Contains(id) || x.car_chassis.Contains(id));
                return View(await mydbcontext.ToListAsync());
            }

        }



        // GET: ADAF_Cars
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.ADAF_Carss.ToListAsync());
        //}

        // GET: ADAF_Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aDAF_Cars = await _context.ADAF_Carss
                .FirstOrDefaultAsync(m => m.car_id == id);
            if (aDAF_Cars == null)
            {
                return NotFound();
            }

            return View(aDAF_Cars);
        }

        // GET: ADAF_Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ADAF_Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("car_id,car_board,car_chassis,car_motor,car_brand,license_start_date,license_end_date,license_examination_date,trafiic_name,person_used,driver_insurance,licenseimg,creation_user,last_update_user")] ADAF_Cars aDAF_Cars)
        {
            if (ModelState.IsValid)
            {


                var loginuser = int.Parse(HttpContext.Session.GetString("userid").ToString());
                aDAF_Cars.creation_user = loginuser;
                aDAF_Cars.last_update_user = loginuser;


                _context.Add(aDAF_Cars);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aDAF_Cars);
        }

        // GET: ADAF_Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aDAF_Cars = await _context.ADAF_Carss.FindAsync(id);
            if (aDAF_Cars == null)
            {
                return NotFound();
            }
            return View(aDAF_Cars);
        }

        // POST: ADAF_Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("car_id,car_board,car_chassis,car_motor,car_brand,license_start_date,license_end_date,license_examination_date,trafiic_name,person_used,driver_insurance,licenseimg,creation_user,last_update_user")] ADAF_Cars aDAF_Cars)
        {
            if (id != aDAF_Cars.car_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var loginuser = int.Parse(HttpContext.Session.GetString("userid").ToString());
                    aDAF_Cars.creation_user = loginuser;
                    aDAF_Cars.last_update_user = loginuser;

                    _context.Update(aDAF_Cars);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ADAF_CarsExists(aDAF_Cars.car_id))
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
            return View(aDAF_Cars);
        }

        // GET: ADAF_Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aDAF_Cars = await _context.ADAF_Carss
                .FirstOrDefaultAsync(m => m.car_id == id);
            if (aDAF_Cars == null)
            {
                return NotFound();
            }

            return View(aDAF_Cars);
        }

        // POST: ADAF_Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aDAF_Cars = await _context.ADAF_Carss.FindAsync(id);
            _context.ADAF_Carss.Remove(aDAF_Cars);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ADAF_CarsExists(int id)
        {
            return _context.ADAF_Carss.Any(e => e.car_id == id);
        }
      
    }
}
