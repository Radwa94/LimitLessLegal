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
    public class LGL_LitigantController : Controller
    {
        private readonly MyDbContext _context;

        public LGL_LitigantController(MyDbContext context)
        {
            _context = context;
        }
        public bool get_roles()
        {
            bool isrole = false;
            string permission_id = HttpContext.Session.GetString("permission_id");
            string page_current = HttpContext.Request.Path;

            var db = _context.Permission_pagess.Where(c => c.permission_id.ToString() == permission_id && c.page_name == page_current).Select(x => x.page_name).ToList();
            if (db.Count != 0)
            {
                isrole = true;
            }
            else
            {
                isrole = false;
            }
            return isrole;
        }
        // GET: LGL_Litigant
        public async Task<IActionResult> Index()
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                return View(await _context.LGL_Litigants.ToListAsync());
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: LGL_Litigant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var lGL_Litigant = await _context.LGL_Litigants
                    .FirstOrDefaultAsync(m => m.litigant_id == id);
                if (lGL_Litigant == null)
                {
                    return NotFound();
                }

                return View(lGL_Litigant);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: LGL_Litigant/Create
        public IActionResult Create()
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                return View();
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // POST: LGL_Litigant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("litigant_id,litigant_name,creation_user,last_update_user,litigant_disable")] LGL_Litigant lGL_Litigant)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(lGL_Litigant);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(lGL_Litigant);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: LGL_Litigant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var lGL_Litigant = await _context.LGL_Litigants.FindAsync(id);
                if (lGL_Litigant == null)
                {
                    return NotFound();
                }
                return View(lGL_Litigant);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // POST: LGL_Litigant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("litigant_id,litigant_name,creation_user,last_update_user,litigant_disable")] LGL_Litigant lGL_Litigant)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id != lGL_Litigant.litigant_id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(lGL_Litigant);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!LGL_LitigantExists(lGL_Litigant.litigant_id))
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
                return View(lGL_Litigant);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: LGL_Litigant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var lGL_Litigant = await _context.LGL_Litigants
                    .FirstOrDefaultAsync(m => m.litigant_id == id);
                if (lGL_Litigant == null)
                {
                    return NotFound();
                }

                return View(lGL_Litigant);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // POST: LGL_Litigant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                var lGL_Litigant = await _context.LGL_Litigants.FindAsync(id);
                _context.LGL_Litigants.Remove(lGL_Litigant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        private bool LGL_LitigantExists(int id)
        {
            return _context.LGL_Litigants.Any(e => e.litigant_id == id);
        }
    }
}
