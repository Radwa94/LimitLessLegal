using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MVC_Core_Store.Controllers
{
    public class ReportsController : Controller
    { //settings
        private MyDbContext _context;
        public ReportsController(MyDbContext context)
        {
            _context = context;
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Sessions_Report(DateTime datefrom, DateTime dateto)
        {
            var rpt = _context.LGL_Sessionss.Where(c => c.LGL_Lawsuit.lawsuit_id == 2 && c.session_date.Value >= datefrom && c.session_next_date.Date <= dateto).Include(c => c.delay_reason).Include(c => c.lawsuit_id).ToList();

            return View(rpt);
        }
        public IActionResult Lawsuit_report(DateTime datefrom, DateTime dateto)
        {
            var rpt = _context.LGL_Lawsuits.Where(c => c.LGL_Clients.client_id == 1 && c.associate_date.Date >= datefrom && c.associate_date.Date <= dateto).Include(c => c.cause_id).Include(c => c.litigant_id).ToList();

            return View(rpt);
        }
        //public IActionResult reportSalesbranch(DateTime datefrom, DateTime dateto, string branch_id)
        //{
        //    var branches_table = _context.branches.ToList();
        //    List<SelectListItem> lstbranches = new List<SelectListItem>();
        //    lstbranches.Add(new SelectListItem { Text = "..اختر ..", Value = "" });
        //    foreach (var item in branches_table)
        //    {
        //        lstbranches.Add(new SelectListItem { Text = item.branch_name, Value = item.branch_id.ToString() });
        //    }
        //    ViewBag.branches = lstbranches;


        //    var rpt = _context.LGL_Lawsuits.Where(c => c.LGL_Clients.client_id == 1 && c.associate_date.Date >= datefrom && c.associate_date.Date <= dateto).Include(c => c.authorization_id).Include(c => c.litigant_id).ToList();

        //    return View(rpt);
        //}
        public IActionResult reportemployee(string userId)
        {
            var users_table = _context.Userss.ToList();
            List<SelectListItem> lst = new List<SelectListItem>();
            lst.Add(new SelectListItem { Text = "..اختر الجميع ..", Value = "" });
            foreach (var item in users_table)
            {
                lst.Add(new SelectListItem { Text = item.username, Value = item.userId.ToString() });
            }
            ViewBag.users = lst;
            //--------------------
            //اولا اعرض الجميع
            var rpt = _context.Userss.Include(c => c.Permission_group).ToList();
            //اذا اختار قيمة اذن ينفذ الشرط الاتي
            if (userId != null)
            {
            rpt = _context.Userss.Where(c => c.userId.ToString() == userId).Include(c => c.Permission_group).ToList();
            }
           
            return View(rpt);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}