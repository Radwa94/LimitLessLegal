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
    public class LGL_Authorization_kindsController : Controller
    {
        private readonly MyDbContext _context;

        public LGL_Authorization_kindsController(MyDbContext context)
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
        // GET: LGL_Authorization_kinds
        public async Task<IActionResult> Index()
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                return View(await _context.LGL_Authorization_kindss.ToListAsync());
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: LGL_Authorization_kinds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var lGL_Authorization_kinds = await _context.LGL_Authorization_kindss
                    .FirstOrDefaultAsync(m => m.authorization_kinds_id == id);
                if (lGL_Authorization_kinds == null)
                {
                    return NotFound();
                }

                return View(lGL_Authorization_kinds);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
           
        }

        // GET: LGL_Authorization_kinds/Create
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

        // POST: LGL_Authorization_kinds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("authorization_kinds_id,authorization_kinds_name,creation_user,last_update_user,authorization_kinds_disable")] LGL_Authorization_kinds lGL_Authorization_kinds)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(lGL_Authorization_kinds);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(lGL_Authorization_kinds);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: LGL_Authorization_kinds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var lGL_Authorization_kinds = await _context.LGL_Authorization_kindss.FindAsync(id);
                if (lGL_Authorization_kinds == null)
                {
                    return NotFound();
                }
                return View(lGL_Authorization_kinds);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // POST: LGL_Authorization_kinds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("authorization_kinds_id,authorization_kinds_name,creation_user,last_update_user,authorization_kinds_disable")] LGL_Authorization_kinds lGL_Authorization_kinds)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id != lGL_Authorization_kinds.authorization_kinds_id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(lGL_Authorization_kinds);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!LGL_Authorization_kindsExists(lGL_Authorization_kinds.authorization_kinds_id))
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
                return View(lGL_Authorization_kinds);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: LGL_Authorization_kinds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var lGL_Authorization_kinds = await _context.LGL_Authorization_kindss
                    .FirstOrDefaultAsync(m => m.authorization_kinds_id == id);
                if (lGL_Authorization_kinds == null)
                {
                    return NotFound();
                }

                return View(lGL_Authorization_kinds);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // POST: LGL_Authorization_kinds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                var lGL_Authorization_kinds = await _context.LGL_Authorization_kindss.FindAsync(id);
                _context.LGL_Authorization_kindss.Remove(lGL_Authorization_kinds);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
         
        }

        private bool LGL_Authorization_kindsExists(int id)
        {
            return _context.LGL_Authorization_kindss.Any(e => e.authorization_kinds_id == id);
        }
    }
}
