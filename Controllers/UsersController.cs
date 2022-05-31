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
    public class UsersController : Controller
    {
        private readonly MyDbContext _context;

        public UsersController(MyDbContext context)
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
        // GET: Users
        public async Task<IActionResult> Index()
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                var myDbContext = _context.Userss.Include(u => u.Permission_group);
                return View(await myDbContext.ToListAsync());
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var users = await _context.Userss
                    .Include(u => u.Permission_group)
                    .FirstOrDefaultAsync(m => m.userId == id);
                if (users == null)
                {
                    return NotFound();
                }

                return View(users);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                ViewData["permission_id"] = new SelectList(_context.Permission_groups, "permission_id", "permission_name");
                return View();
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("userId,username,userpassword,useremail,date_add,permission_id")] Users users)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(users);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["permission_id"] = new SelectList(_context.Permission_groups, "permission_id", "permission_name", users.permission_id);
                return View(users);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var users = await _context.Userss.FindAsync(id);
                if (users == null)
                {
                    return NotFound();
                }
                ViewData["permission_id"] = new SelectList(_context.Permission_groups, "permission_id", "permission_name", users.permission_id);
                return View(users);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("userId,username,userpassword,useremail,date_add,permission_id")] Users users)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id != users.userId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(users);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!UsersExists(users.userId))
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
                ViewData["permission_id"] = new SelectList(_context.Permission_groups, "permission_id", "permission_name", users.permission_id);
                return View(users);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var users = await _context.Userss
                    .Include(u => u.Permission_group)
                    .FirstOrDefaultAsync(m => m.userId == id);
                if (users == null)
                {
                    return NotFound();
                }

                return View(users);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                var users = await _context.Userss.FindAsync(id);
                _context.Userss.Remove(users);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        private bool UsersExists(int id)
        {
            return _context.Userss.Any(e => e.userId == id);
        }
    }
}
