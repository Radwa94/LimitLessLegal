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
    public class LGL_Lawsuit_StatusController : Controller
    {
        private readonly MyDbContext _context;

        public LGL_Lawsuit_StatusController(MyDbContext context)
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
        // GET: LGL_Lawsuit_Status
        public async Task<IActionResult> Index()
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                return View(await _context.LGL_Lawsuit_Statuss.ToListAsync());
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: LGL_Lawsuit_Status/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var lGL_Lawsuit_Status = await _context.LGL_Lawsuit_Statuss
                    .FirstOrDefaultAsync(m => m.lawsuit_Status_id == id);
                if (lGL_Lawsuit_Status == null)
                {
                    return NotFound();
                }

                return View(lGL_Lawsuit_Status);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: LGL_Lawsuit_Status/Create
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

        // POST: LGL_Lawsuit_Status/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("lawsuit_Status_id,lawsuit_Status_name,creation_user,last_update_user,lawsuit_Status_disable")] LGL_Lawsuit_Status lGL_Lawsuit_Status)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(lGL_Lawsuit_Status);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(lGL_Lawsuit_Status);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: LGL_Lawsuit_Status/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var lGL_Lawsuit_Status = await _context.LGL_Lawsuit_Statuss.FindAsync(id);
                if (lGL_Lawsuit_Status == null)
                {
                    return NotFound();
                }
                return View(lGL_Lawsuit_Status);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
          
        }

        // POST: LGL_Lawsuit_Status/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("lawsuit_Status_id,lawsuit_Status_name,creation_user,last_update_user,lawsuit_Status_disable")] LGL_Lawsuit_Status lGL_Lawsuit_Status)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id != lGL_Lawsuit_Status.lawsuit_Status_id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(lGL_Lawsuit_Status);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!LGL_Lawsuit_StatusExists(lGL_Lawsuit_Status.lawsuit_Status_id))
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
                return View(lGL_Lawsuit_Status);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: LGL_Lawsuit_Status/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var lGL_Lawsuit_Status = await _context.LGL_Lawsuit_Statuss
                    .FirstOrDefaultAsync(m => m.lawsuit_Status_id == id);
                if (lGL_Lawsuit_Status == null)
                {
                    return NotFound();
                }

                return View(lGL_Lawsuit_Status);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
           
        }

        // POST: LGL_Lawsuit_Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                var lGL_Lawsuit_Status = await _context.LGL_Lawsuit_Statuss.FindAsync(id);
                _context.LGL_Lawsuit_Statuss.Remove(lGL_Lawsuit_Status);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        private bool LGL_Lawsuit_StatusExists(int id)
        {
            return _context.LGL_Lawsuit_Statuss.Any(e => e.lawsuit_Status_id == id);
        }
    }
}
