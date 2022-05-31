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
    public class LGL_LawsuitController : Controller
    {
        private readonly MyDbContext _context;

        public LGL_LawsuitController(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string id , string id2, string id3, string id4, string id5, string id6, string id7, string id8)
        {
            var mydbcontext = _context.LGL_Lawsuits.Where(x => 1 == 1);
            ViewData["cause_id"] = new SelectList(_context.LGL_Causes, "cause_id", "cause_name");
            ViewData["client_id"] = new SelectList(_context.LGL_Clientss, "client_id", "client_name");
            ViewData["ID_Judgment"] = new SelectList(_context.Judgment, "ID_Judgment", "Judgmentn");
            ViewData["court_id"] = new SelectList(_context.LGL_Courts, "court_id", "court_name");
            ViewData["lawsuit_Status_id"] = new SelectList(_context.LGL_Lawsuit_Statuss, "lawsuit_Status_id", "lawsuit_Status_name");
            ViewData["litigant_id"] = new SelectList(_context.LGL_Litigants, "litigant_id", "litigant_name");
            ViewData["client_type_id"] = new SelectList(_context.LGL_Client_typess, "client_type_id", "client_type_name");
            if (string.IsNullOrEmpty(id))
            {
                return View(await mydbcontext.ToListAsync());
            }
            else
            {
                mydbcontext = mydbcontext.Where(x => x.lGL_Court.court_name == id || x.lawsuit_circle == id2 || x.LGL_Cause.cause_name == id3 || x.cause_year == id4 || x.lGL_Litigant.litigant_name == id5 || x.lGL_Lawsuit_Status.lawsuit_Status_name ==id6 || x.lawsuit_number == id7 || x.judgment.Judgmentn == id8);
                return View(await mydbcontext.ToListAsync());
            }


        }
            // GET: LGL_Lawsuit
            //public async Task<IActionResult> Index()
            //{
            //    var myDbContext = _context.LGL_Lawsuits.Include(l => l.LGL_Cause).Include(l => l.LGL_Clients).Include(l => l.judgment).Include(l => l.lGL_Court).Include(l => l.lGL_Lawsuit_Status).Include(l => l.lGL_Litigant);
            //    return View(await myDbContext.ToListAsync());
            //

            // GET: LGL_Lawsuit/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var lGL_Lawsuit = await _context.LGL_Lawsuits
                    .Include(l => l.LGL_Cause)
                    .Include(l => l.LGL_Clients)
                    .Include(l => l.judgment)
                    .Include(l => l.lGL_Court)
                    .Include(l => l.lGL_Lawsuit_Status)
                    .Include(l => l.lGL_Litigant)
                    .Include(l => l.LGL_Client_Types)
                    .FirstOrDefaultAsync(m => m.lawsuit_id == id);
                if (lGL_Lawsuit == null)
                {
                    return NotFound();
                }

                return View(lGL_Lawsuit);
            }

            // GET: LGL_Lawsuit/Create
            public IActionResult Create()
            {
                ViewData["cause_id"] = new SelectList(_context.LGL_Causes, "cause_id", "cause_name");
                ViewData["client_id"] = new SelectList(_context.LGL_Clientss, "client_id", "client_name");
                ViewData["ID_Judgment"] = new SelectList(_context.Judgment, "ID_Judgment", "Judgmentn");
                ViewData["court_id"] = new SelectList(_context.LGL_Courts, "court_id", "court_name");
                ViewData["lawsuit_Status_id"] = new SelectList(_context.LGL_Lawsuit_Statuss, "lawsuit_Status_id", "lawsuit_Status_name");
                ViewData["litigant_id"] = new SelectList(_context.LGL_Litigants, "litigant_id", "litigant_name");
                ViewData["client_type_id"] = new SelectList(_context.LGL_Client_typess, "client_type_id", "client_type_name");

                return View();
            }

            // POST: LGL_Lawsuit/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("lawsuit_id,lawsuit_number,cause_year,cause_id,lawsuit_circle,court_id,sitting_date_first,litigant_id,client_id,client_type_id,ID_Judgment,PronouncingJudgment,lawsuit_degree,trapping_number,lawsuit_Status_id,associate_date,lawsuit_description,creation_user,last_update_user,lawsuitfile")] LGL_Lawsuit lGL_Lawsuit)
            {
                if (ModelState.IsValid)
                {
                var loginuser = int.Parse(HttpContext.Session.GetString("userid").ToString());
                lGL_Lawsuit.last_update_user = loginuser;
                lGL_Lawsuit.creation_user = loginuser;
                    _context.Add(lGL_Lawsuit);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["cause_id"] = new SelectList(_context.LGL_Causes, "cause_id", "cause_name", lGL_Lawsuit.cause_id);
                ViewData["client_id"] = new SelectList(_context.LGL_Clientss, "client_id", "client_name", lGL_Lawsuit.client_id);
                ViewData["ID_Judgment"] = new SelectList(_context.Judgment, "ID_Judgment", "Judgmentn", lGL_Lawsuit.ID_Judgment);
                ViewData["court_id"] = new SelectList(_context.LGL_Courts, "court_id", "court_name", lGL_Lawsuit.court_id);
                ViewData["lawsuit_Status_id"] = new SelectList(_context.LGL_Lawsuit_Statuss, "lawsuit_Status_id", "lawsuit_Status_name", lGL_Lawsuit.lawsuit_Status_id);
                ViewData["litigant_id"] = new SelectList(_context.LGL_Litigants, "litigant_id", "litigant_name", lGL_Lawsuit.litigant_id);
                ViewData["client_type_id"] = new SelectList(_context.LGL_Client_typess, "client_type_id", "client_type_name");

                return View(lGL_Lawsuit);
            }

            // GET: LGL_Lawsuit/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var lGL_Lawsuit = await _context.LGL_Lawsuits.FindAsync(id);
                if (lGL_Lawsuit == null)
                {
                    return NotFound();
                }
                ViewData["cause_id"] = new SelectList(_context.LGL_Causes, "cause_id", "cause_name", lGL_Lawsuit.cause_id);
                ViewData["client_id"] = new SelectList(_context.LGL_Clientss, "client_id", "client_name", lGL_Lawsuit.client_id);
                ViewData["ID_Judgment"] = new SelectList(_context.Judgment, "ID_Judgment", "Judgmentn", lGL_Lawsuit.ID_Judgment);
                ViewData["court_id"] = new SelectList(_context.LGL_Courts, "court_id", "court_name", lGL_Lawsuit.court_id);
                ViewData["lawsuit_Status_id"] = new SelectList(_context.LGL_Lawsuit_Statuss, "lawsuit_Status_id", "lawsuit_Status_name", lGL_Lawsuit.lawsuit_Status_id);
                ViewData["litigant_id"] = new SelectList(_context.LGL_Litigants, "litigant_id", "litigant_name", lGL_Lawsuit.litigant_id);
                ViewData["client_type_id"] = new SelectList(_context.LGL_Client_typess, "client_type_id", "client_type_name");

                return View(lGL_Lawsuit);
            }

            // POST: LGL_Lawsuit/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("lawsuit_id,lawsuit_number,cause_year,cause_id,lawsuit_circle,court_id,sitting_date_first,litigant_id,client_id,client_type_id,ID_Judgment,PronouncingJudgment,lawsuit_degree,trapping_number,lawsuit_Status_id,associate_date,lawsuit_description,creation_user,last_update_user,lawsuitfile")] LGL_Lawsuit lGL_Lawsuit)
            {
                if (id != lGL_Lawsuit.lawsuit_id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                    var loginuser = int.Parse(HttpContext.Session.GetString("userid").ToString());
                    lGL_Lawsuit.last_update_user = loginuser;
                    lGL_Lawsuit.creation_user = loginuser;
                    _context.Update(lGL_Lawsuit);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!LGL_LawsuitExists(lGL_Lawsuit.lawsuit_id))
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
                ViewData["cause_id"] = new SelectList(_context.LGL_Causes, "cause_id", "cause_name", lGL_Lawsuit.cause_id);
                ViewData["client_id"] = new SelectList(_context.LGL_Clientss, "client_id", "client_name", lGL_Lawsuit.client_id);
                ViewData["ID_Judgment"] = new SelectList(_context.Judgment, "ID_Judgment", "Judgmentn", lGL_Lawsuit.ID_Judgment);
                ViewData["court_id"] = new SelectList(_context.LGL_Courts, "court_id", "court_name", lGL_Lawsuit.court_id);
                ViewData["lawsuit_Status_id"] = new SelectList(_context.LGL_Lawsuit_Statuss, "lawsuit_Status_id", "lawsuit_Status_name", lGL_Lawsuit.lawsuit_Status_id);
                ViewData["litigant_id"] = new SelectList(_context.LGL_Litigants, "litigant_id", "litigant_name", lGL_Lawsuit.litigant_id);
                ViewData["client_type_id"] = new SelectList(_context.LGL_Client_typess, "client_type_id", "client_type_name");

                return View(lGL_Lawsuit);
            }

            // GET: LGL_Lawsuit/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var lGL_Lawsuit = await _context.LGL_Lawsuits
                    .Include(l => l.LGL_Cause)
                    .Include(l => l.LGL_Clients)
                    .Include(l => l.judgment)
                    .Include(l => l.lGL_Court)
                    .Include(l => l.lGL_Lawsuit_Status)
                    .Include(l => l.lGL_Litigant)
                    .Include(l => l.LGL_Client_Types)
                    .FirstOrDefaultAsync(m => m.lawsuit_id == id);
                if (lGL_Lawsuit == null)
                {
                    return NotFound();
                }

                return View(lGL_Lawsuit);
            }

            // POST: LGL_Lawsuit/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var lGL_Lawsuit = await _context.LGL_Lawsuits.FindAsync(id);
                _context.LGL_Lawsuits.Remove(lGL_Lawsuit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool LGL_LawsuitExists(int id)
            {
                return _context.LGL_Lawsuits.Any(e => e.lawsuit_id == id);
            }
        }
    } 




