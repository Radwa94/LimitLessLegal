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
    public class LGL_CourtController : Controller
    {
        private readonly MyDbContext _context;

        public LGL_CourtController(MyDbContext context)
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
        // GET: LGL_Court
        public async Task<IActionResult> Index()
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                return View(await _context.LGL_Courts.ToListAsync());
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: LGL_Court/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var lGL_Court = await _context.LGL_Courts
                    .FirstOrDefaultAsync(m => m.court_id == id);
                if (lGL_Court == null)
                {
                    return NotFound();
                }

                return View(lGL_Court);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: LGL_Court/Create
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

        // POST: LGL_Court/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("court_id,court_name,creation_user,last_update_user,court_disable")] LGL_Court lGL_Court)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(lGL_Court);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(lGL_Court);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: LGL_Court/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var lGL_Court = await _context.LGL_Courts.FindAsync(id);
                if (lGL_Court == null)
                {
                    return NotFound();
                }
                return View(lGL_Court);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // POST: LGL_Court/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("court_id,court_name,creation_user,last_update_user,court_disable")] LGL_Court lGL_Court)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id != lGL_Court.court_id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(lGL_Court);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!LGL_CourtExists(lGL_Court.court_id))
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
                return View(lGL_Court);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: LGL_Court/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var lGL_Court = await _context.LGL_Courts
                    .FirstOrDefaultAsync(m => m.court_id == id);
                if (lGL_Court == null)
                {
                    return NotFound();
                }

                return View(lGL_Court);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // POST: LGL_Court/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                var lGL_Court = await _context.LGL_Courts.FindAsync(id);
                _context.LGL_Courts.Remove(lGL_Court);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        private bool LGL_CourtExists(int id)
        {
            return _context.LGL_Courts.Any(e => e.court_id == id);
        }
    }
}
