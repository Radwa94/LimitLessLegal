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
    public class ADAF_BranchesController : Controller
    {
        private readonly MyDbContext _context;

        public ADAF_BranchesController(MyDbContext context)
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
        // GET: Branches
        public async Task<IActionResult> Index()
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                return View(await _context.ADAF_Branchess.ToListAsync());
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
        }

        // GET: Branches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
            {
                return NotFound();
            }

            var aDAF_Branches = await _context.ADAF_Branchess
                .FirstOrDefaultAsync(m => m.branch_id == id);
            if (aDAF_Branches == null)
            {
                return NotFound();
            }

            return View(aDAF_Branches);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
        }

       

        // GET: Branches/Create
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

        // POST: Branches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("branch_id,branch_name,creation_user,last_update_user,cause_disable")] ADAF_Branches aDAF_Branches)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (ModelState.IsValid)
            {
                _context.Add(aDAF_Branches);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aDAF_Branches);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
        }

        // GET: Branches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
            {
                return NotFound();
            }

            var aDAF_Branches = await _context.ADAF_Branchess.FindAsync(id);
            if (aDAF_Branches == null)
            {
                return NotFound();
            }
            return View(aDAF_Branches);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
        }

        // POST: Branches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("branch_id,branch_name,creation_user,last_update_user,cause_disable")] ADAF_Branches aDAF_Branches)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id != aDAF_Branches.branch_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aDAF_Branches);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ADAF_BranchesExists(aDAF_Branches.branch_id))
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
            return View(aDAF_Branches);
        }
            else
            {
                return RedirectToAction("noacces", "home");
    }
}

        // GET: Branches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                if (id == null)
            {
                return NotFound();
            }

            var aDAF_Branches = await _context.ADAF_Branchess
                .FirstOrDefaultAsync(m => m.branch_id == id);
            if (aDAF_Branches == null)
            {
                return NotFound();
            }

            return View(aDAF_Branches);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            bool isrole = get_roles();
            if (isrole == true)
            {
                var aDAF_Branches = await _context.ADAF_Branchess.FindAsync(id);
            _context.ADAF_Branchess.Remove(aDAF_Branches);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
            else
            {
                return RedirectToAction("noacces", "home");
            }
}

        private bool ADAF_BranchesExists(int id)
        {
           
                return _context.ADAF_Branchess.Any(e => e.branch_id == id);
           
        }
    }
}
