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
    public class LGL_ClientsController : Controller
    {
        private readonly MyDbContext _context;

        public LGL_ClientsController(MyDbContext context)
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
        // GET: LGL_Clients
        public async Task<IActionResult> Index()
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                var myDbContext = _context.LGL_Clientss.Include(l => l.LGL_Client_types);
                return View(await myDbContext.ToListAsync());
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: LGL_Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var lGL_Clients = await _context.LGL_Clientss
                    .Include(l => l.LGL_Client_types)
                    .FirstOrDefaultAsync(m => m.client_id == id);
                if (lGL_Clients == null)
                {
                    return NotFound();
                }

                return View(lGL_Clients);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
          
        }

        // GET: LGL_Clients/Create
        public IActionResult Create()
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                ViewData["client_type_id"] = new SelectList(_context.LGL_Client_typess, "client_type_id", "client_type_name");
                return View();
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // POST: LGL_Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("client_id,client_name,client_address,associate_date,ph1,ph2,nationid,client_type_id,creation_user,last_update_user,client_disable")] LGL_Clients lGL_Clients)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (ModelState.IsValid)
                {
                    var loginuser = int.Parse(HttpContext.Session.GetString("userid").ToString());
                    lGL_Clients.creation_user = loginuser;
                    lGL_Clients.last_update_user = loginuser;

                    _context.Add(lGL_Clients);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["client_type_id"] = new SelectList(_context.LGL_Client_typess, "client_type_id", "client_type_name", lGL_Clients.client_type_id);
                return View(lGL_Clients);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: LGL_Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var lGL_Clients = await _context.LGL_Clientss.FindAsync(id);
                if (lGL_Clients == null)
                {
                    return NotFound();
                }
                ViewData["client_type_id"] = new SelectList(_context.LGL_Client_typess, "client_type_id", "client_type_name", lGL_Clients.client_type_id);
                return View(lGL_Clients);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
           
        }

        // POST: LGL_Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("client_id,client_name,client_address,associate_date,ph1,ph2,nationid,client_type_id,creation_user,last_update_user,client_disable")] LGL_Clients lGL_Clients)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id != lGL_Clients.client_id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        var loginuser = int.Parse(HttpContext.Session.GetString("userid").ToString());
                        lGL_Clients.creation_user = loginuser;
                        lGL_Clients.last_update_user = loginuser;

                        _context.Update(lGL_Clients);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!LGL_ClientsExists(lGL_Clients.client_id))
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
                ViewData["client_type_id"] = new SelectList(_context.LGL_Client_typess, "client_type_id", "client_type_name", lGL_Clients.client_type_id);
                return View(lGL_Clients);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: LGL_Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var lGL_Clients = await _context.LGL_Clientss
                    .Include(l => l.LGL_Client_types)
                    .FirstOrDefaultAsync(m => m.client_id == id);
                if (lGL_Clients == null)
                {
                    return NotFound();
                }

                return View(lGL_Clients);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
          
        }

        // POST: LGL_Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                var lGL_Clients = await _context.LGL_Clientss.FindAsync(id);
                _context.LGL_Clientss.Remove(lGL_Clients);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
           
        }

        private bool LGL_ClientsExists(int id)
        {
            return _context.LGL_Clientss.Any(e => e.client_id == id);
        }
    }
}
