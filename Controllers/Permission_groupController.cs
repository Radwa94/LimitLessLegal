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
    public class Permission_groupController : Controller
    {
        private readonly MyDbContext _context;

        public Permission_groupController(MyDbContext context)
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
        // GET: Permission_group
        public async Task<IActionResult> Index()
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                return View(await _context.Permission_groups.ToListAsync());
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: Permission_group/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var permission_group = await _context.Permission_groups
                    .FirstOrDefaultAsync(m => m.permission_id == id);
                if (permission_group == null)
                {
                    return NotFound();
                }

                return View(permission_group);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: Permission_group/Create
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

        // POST: Permission_group/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("permission_id,permission_name")] Permission_group permission_group)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(permission_group);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(permission_group);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: Permission_group/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var permission_group = await _context.Permission_groups.FindAsync(id);
                if (permission_group == null)
                {
                    return NotFound();
                }
                return View(permission_group);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // POST: Permission_group/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("permission_id,permission_name")] Permission_group permission_group)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id != permission_group.permission_id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(permission_group);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!Permission_groupExists(permission_group.permission_id))
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
                return View(permission_group);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: Permission_group/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var permission_group = await _context.Permission_groups
                    .FirstOrDefaultAsync(m => m.permission_id == id);
                if (permission_group == null)
                {
                    return NotFound();
                }

                return View(permission_group);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // POST: Permission_group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                var permission_group = await _context.Permission_groups.FindAsync(id);
                _context.Permission_groups.Remove(permission_group);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        private bool Permission_groupExists(int id)
        {
            return _context.Permission_groups.Any(e => e.permission_id == id);
        }
    }
}
