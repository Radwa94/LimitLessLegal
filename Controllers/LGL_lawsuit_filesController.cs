using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LimitLessLegal.Controllers
{
    public class LGL_lawsuit_filesController : Controller
    {
        private readonly MyDbContext _context;

        public LGL_lawsuit_filesController(MyDbContext context)
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
        // GET: LGL_lawsuit_files
        public async Task<IActionResult> Index()
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                var myDbContext = _context.LGL_lawsuit_filess.Include(l => l.LGL_Lawsuit);
                return View(await myDbContext.ToListAsync());
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: LGL_lawsuit_files/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var lGL_lawsuit_files = await _context.LGL_lawsuit_filess
                    .Include(l => l.LGL_Lawsuit)
                    .FirstOrDefaultAsync(m => m.lawsuit_files_id == id);
                if (lGL_lawsuit_files == null)
                {
                    return NotFound();
                }

                return View(lGL_lawsuit_files);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: LGL_lawsuit_files/Create
        public IActionResult Create()
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                ViewData["lawsuit_id"] = new SelectList(_context.LGL_Lawsuits, "lawsuit_id", "lawsuit_number");
                return View();
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // POST: LGL_lawsuit_files/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("lawsuit_files_id,lawsuit_id,lawsuit_files_img,creation_user,last_update_user")] LGL_lawsuit_files lGL_lawsuit_files, List<IFormFile> files)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (ModelState.IsValid)
                {
                    string filename = "";
                    if (files != null)
                    {
                        foreach (var file in files)
                        {
                            filename = file.FileName;
                            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/lawsuit", file.FileName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }
                        }
                    }

                    lGL_lawsuit_files.lawsuit_files_img = filename;
                    _context.Add(lGL_lawsuit_files);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["lawsuit_id"] = new SelectList(_context.LGL_Lawsuits, "lawsuit_id", "lawsuit_number", lGL_lawsuit_files.lawsuit_id);
                return View(lGL_lawsuit_files);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: LGL_lawsuit_files/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var lGL_lawsuit_files = await _context.LGL_lawsuit_filess.FindAsync(id);
                if (lGL_lawsuit_files == null)
                {
                    return NotFound();
                }
                ViewData["lawsuit_id"] = new SelectList(_context.LGL_Lawsuits, "lawsuit_id", "lawsuit_number", lGL_lawsuit_files.lawsuit_id);
                return View(lGL_lawsuit_files);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // POST: LGL_lawsuit_files/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("lawsuit_files_id,lawsuit_id,lawsuit_files_img,creation_user,last_update_user")] LGL_lawsuit_files lGL_lawsuit_files, List<IFormFile> files)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id != lGL_lawsuit_files.lawsuit_files_id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        string filename = "";
                        if (files != null)
                        {
                            foreach (var file in files)
                            {
                                filename = file.FileName;
                                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/lawsuit", file.FileName);
                                using (var stream = new FileStream(path, FileMode.Create))
                                {
                                    file.CopyTo(stream);
                                }
                            }
                        }

                        lGL_lawsuit_files.lawsuit_files_img = filename;
                        _context.Update(lGL_lawsuit_files);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!LGL_lawsuit_filesExists(lGL_lawsuit_files.lawsuit_files_id))
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
                ViewData["lawsuit_id"] = new SelectList(_context.LGL_Lawsuits, "lawsuit_id", "lawsuit_number", lGL_lawsuit_files.lawsuit_id);
                return View(lGL_lawsuit_files);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
           
        }

        // GET: LGL_lawsuit_files/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var lGL_lawsuit_files = await _context.LGL_lawsuit_filess
                    .Include(l => l.LGL_Lawsuit)
                    .FirstOrDefaultAsync(m => m.lawsuit_files_id == id);
                if (lGL_lawsuit_files == null)
                {
                    return NotFound();
                }

                return View(lGL_lawsuit_files);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // POST: LGL_lawsuit_files/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                var lGL_lawsuit_files = await _context.LGL_lawsuit_filess.FindAsync(id);
                _context.LGL_lawsuit_filess.Remove(lGL_lawsuit_files);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        private bool LGL_lawsuit_filesExists(int id)
        {
            return _context.LGL_lawsuit_filess.Any(e => e.lawsuit_files_id == id);
        }
    }
}
