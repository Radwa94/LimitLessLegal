using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MVC_Core_Store.Controllers
{
    public class Permission_pagesController : Controller
    {//settings
        private MyDbContext _context;
        public Permission_pagesController(MyDbContext context)
        {
            _context = context;
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
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
       
        
        // GET: Permission_pages
        public ActionResult Index()
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                var tbl = _context.Permission_pagess.Include(c => c.Permission_group).ToList();

                return View(tbl);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: Permission_pages/Details/5
        public ActionResult Details(int id)
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

        // GET: Permission_pages/Create
        public ActionResult Create()
        {

            bool isrole = get_roles();
            if (isrole == true)
            {
                var group_table = _context.Permission_groups.ToList();
                List<SelectListItem> lstgroups = new List<SelectListItem>();
                foreach (var item in group_table)
                {
                    lstgroups.Add(new SelectListItem { Text = item.permission_name, Value = item.permission_id.ToString() });
                }
                ViewBag.groups = lstgroups;
                //----------------------------
                List<listchekbox> lstchk = new List<listchekbox>();

                lstchk.Add(new listchekbox { page_title = "التراخيص", page_url = "/ADAF_District_license/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة التراخيص", page_url = "/ADAF_District_license/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف التراخيص", page_url = "/ADAF_District_license/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل التراخيص", page_url = "/ADAF_District_license/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل التراخيص", page_url = "/ADAF_District_license/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "أنواع التراخيص", page_url = "/ADAF_District_license_types/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة أنواع التراخيص", page_url = "/ADAF_District_license_types/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف أنواع التراخيص", page_url = "/ADAF_District_license_types/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل أنواع التراخيص", page_url = "/ADAF_District_license_types/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل أنواع التراخيص", page_url = "/ADAF_District_license_types/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "تفاصيل الفروع", page_url = "/ADAF_Branches/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة الفروع", page_url = "/ADAF_Branches/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف الفروع", page_url = "/ADAF_Branches/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل الفروع", page_url = "/ADAF_Branches/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف الفروع", page_url = "/ADAF_Branches/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "السيارات", page_url = "/ADAF_Cars/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة السيارات", page_url = "/ADAF_Cars/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف السيارات", page_url = "/ADAF_Cars/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل السيارات", page_url = "/ADAF_Cars/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل السيارات", page_url = "/ADAF_Cars/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "التوكيلات", page_url = "/LGL_Authorization/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة التوكيلات", page_url = "/LGL_Authorization/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف التوكيلات", page_url = "/LGL_Authorization/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل التوكيلات", page_url = "/LGL_Authorization/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل التوكيلات", page_url = "/LGL_Authorization/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "أنواع التوكيلات", page_url = "/LGL_Authorization_kinds/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة أنواع التوكيلات", page_url = "/LGL_Authorization_kinds/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف أنواع التوكيلات", page_url = "/LGL_Authorization_kinds/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل أنواع التوكيلات", page_url = "/LGL_Authorization_kinds/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل أنواع التوكيلات", page_url = "/LGL_Authorization_kinds/Edit", is_selected = false });


                lstchk.Add(new listchekbox { page_title = "نوع القضية", page_url = "/LGL_Cause/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة نوع القضية", page_url = "/LGL_Cause/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف نوع القضية", page_url = "/LGL_Cause/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل نوع القضية", page_url = "/LGL_Cause/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل نوع القضية", page_url = "/LGL_Cause/Edit", is_selected = false });


                lstchk.Add(new listchekbox { page_title = "صفة الموكل", page_url = "/LGL_Client_types/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة صفة الموكل", page_url = "/LGL_Client_types/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف صفة الموكل", page_url = "/LGL_Client_types/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل صفة الموكل", page_url = "/LGL_Client_types/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل صفة الموكل", page_url = "/LGL_Client_types/Edit", is_selected = false });


                lstchk.Add(new listchekbox { page_title = "الموكل", page_url = "/LGL_Clients/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة الموكل", page_url = "/LGL_Clients/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف الموكل", page_url = "/LGL_Clients/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل الموكل", page_url = "/LGL_Clients/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل الموكل", page_url = "/LGL_Clients/Edit", is_selected = false });


                lstchk.Add(new listchekbox { page_title = "المحاكم", page_url = "/LGL_Court/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة المحاكم", page_url = "/LGL_Court/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف المحاكم", page_url = "/LGL_Court/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل المحاكم", page_url = "/LGL_Court/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل المحاكم", page_url = "/LGL_Court/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "القضايا", page_url = "/LGL_Lawsuit/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة القضايا", page_url = "/LGL_Lawsuit/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف القضايا", page_url = "/LGL_Lawsuit/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل القضايا", page_url = "/LGL_Lawsuit/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل القضايا", page_url = "/LGL_Lawsuit/Edit", is_selected = false });


                lstchk.Add(new listchekbox { page_title = "ملفات القضايا", page_url = "/LGL_lawsuit_files/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة ملفات القضايا", page_url = "/LGL_lawsuit_files/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف ملفات القضايا", page_url = "/LGL_lawsuit_files/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل ملفات القضايا", page_url = "/LGL_lawsuit_files/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل ملفات القضايا", page_url = "/LGL_lawsuit_files/Edit", is_selected = false });


                lstchk.Add(new listchekbox { page_title = "حالة القضايا", page_url = "/LGL_Lawsuit_Status/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة حالة القضايا", page_url = "/LGL_Lawsuit_Status/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف حالة القضايا", page_url = "/LGL_Lawsuit_Status/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل حالة القضايا", page_url = "/LGL_Lawsuit_Status/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل حالة القضايا", page_url = "/LGL_Lawsuit_Status/Edit", is_selected = false });


                lstchk.Add(new listchekbox { page_title = "الخصوم", page_url = "/LGL_Litigant/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة الخصوم", page_url = "/LGL_Litigant/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف الخصوم", page_url = "/LGL_Litigant/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل الخصوم", page_url = "/LGL_Litigant/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل الخصوم", page_url = "/LGL_Litigant/Edit", is_selected = false });


                lstchk.Add(new listchekbox { page_title = "الجلسات", page_url = "/LGL_Sessions/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة الجلسات", page_url = "/LGL_Sessions/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف الجلسات", page_url = "/LGL_Sessions/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل الجلسات", page_url = "/LGL_Sessions/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل الجلسات", page_url = "/LGL_Sessions/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "العقود", page_url = "/LGL_Contracting/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة العقود", page_url = "/LGL_Contracting/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف العقود", page_url = "/LGL_Contracting/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل العقود", page_url = "/LGL_Contracting/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل العقود", page_url = "/LGL_Contracting/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "السنترال", page_url = "/ Central/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة السنترال", page_url = "/Central/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف السنترال", page_url = "/Central/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل االسنترال", page_url = "/Central/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل السنترال", page_url = "/Central/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "التحقيقات", page_url = "/ investigation/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة التحقيقات", page_url ="investigation/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذفالتحقيقات", page_url ="investigation/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل التحقيقات", page_url ="investigation/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل التحقيقات", page_url ="investigation/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "الاداره", page_url = "/ Department/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة الاداره", page_url = "Department/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف الاداره", page_url = "Department/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل الاداره", page_url = "Department/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل الاداره", page_url = "Department/Edit", is_selected = false });


                lstchk.Add(new listchekbox { page_title = "الوظيفه", page_url = "/Jop/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة الوظيفه", page_url = "Jop/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف الوظيفه", page_url = "Jop/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل الوظيفه", page_url ="Jop/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل الوظيفه", page_url ="Jop/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "نوع العقد", page_url = "/Contracttybe/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة نوع العقد", page_url ="Contracttybe/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف نوع العقد", page_url = "Contracttybe/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل نوع العقد", page_url = "Contracttybe/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل نوع العقد", page_url = "Contracttybe/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "نسبه الزياده السنويه", page_url = "/Percent_value/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة نسبه الزياده السنويه", page_url = "Percent_value/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف نسبه الزياده السنويه", page_url = "Percent_value/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل نسبه الزياده السنويه", page_url ="Percent_value/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل نسبه الزياده السنويه", page_url = "Percent_value/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "نوع الزياده السنويه", page_url = "/type_annual_increase/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة نوع الزياده السنويه", page_url = "type_annual_increase/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف نوع الزياده السنويه", page_url = "type_annual_increase/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل نوع الزياده السنويه", page_url = "type_annual_increase/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل نوع الزياده السنويه", page_url = "type_annual_increase/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "الصلاحيات ", page_url = "/Permission_pages/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة الصلاحيات", page_url ="/Permission_pages/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف الصلاحيات", page_url ="/Permission_pages/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل الصلاحيات", page_url ="/Permission_pages/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل الصلاحيات", page_url ="/Permission_pages/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "نوع مجموعات المستخدمين", page_url = "/Permission_group/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة مجموعات المستخدمين", page_url ="/Permission_group/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف مجموعات المستخدمين", page_url = "/Permission_group/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل مجموعات المستخدمين", page_url ="/Permission_group/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل مجموعات المستخدمين", page_url ="/Permission_group/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = " المستخدمين",page_url = "/Users/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "المستخدمين", page_url = "Users/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف المستخدمين",page_url ="/Users/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل المستخدمين",page_url ="/Users/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل المستخدمين",page_url ="/Users/Edit", is_selected = false });

                var model = new permisions
                {
                    lstchekbox = lstchk
                };

                return View(model);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }
    
        // POST: Permission_pages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(permisions permisions)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                try
                {

                    //delete first
                    var dbdelete = _context.Permission_pagess.Where(c => c.permission_id == permisions.group_id);
                    if (dbdelete != null)
                    {
                        _context.Permission_pagess.RemoveRange(dbdelete);
                        _context.SaveChanges();
                    }
                    foreach (var item in permisions.lstchekbox)
                    {
                        if (item.is_selected == true)
                        {
                            Permission_pages p = new Permission_pages();
                            p.permission_id = permisions.group_id;
                            p.page_name = item.page_url;
                            _context.Permission_pagess.Add(p);
                            _context.SaveChanges();
                        }
                    }

                    // TODO: Add insert logic here



                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
           
        }

        // GET: Permission_pages/Edit/5
        public ActionResult Edit(int id)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                var group_table = _context.Permission_groups.ToList();
                List<SelectListItem> lstgroups = new List<SelectListItem>();
                foreach (var item in group_table)
                {
                    lstgroups.Add(new SelectListItem { Text = item.permission_name, Value = item.permission_id.ToString() });
                }
                ViewBag.groups = lstgroups;
                //----------------------------
                List<listchekbox> lstchk = new List<listchekbox>();

                lstchk.Add(new listchekbox { page_title = "التراخيص", page_url = "/ADAF_District_license/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة التراخيص", page_url = "/ADAF_District_license/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف التراخيص", page_url = "/ADAF_District_license/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل التراخيص", page_url = "/ADAF_District_license/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل التراخيص", page_url = "/ADAF_District_license/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "أنواع التراخيص", page_url = "/ADAF_District_license_types/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة أنواع التراخيص", page_url = "/ADAF_District_license_types/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف أنواع التراخيص", page_url = "/ADAF_District_license_types/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل أنواع التراخيص", page_url = "/ADAF_District_license_types/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل أنواع التراخيص", page_url = "/ADAF_District_license_types/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "تفاصيل الفروع", page_url = "/ADAF_Branches/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة الفروع", page_url = "/ADAF_Branches/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف الفروع", page_url = "/ADAF_Branches/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل الفروع", page_url = "/ADAF_Branches/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف الفروع", page_url = "/ADAF_Branches/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "السيارات", page_url = "/ADAF_Cars/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة السيارات", page_url = "/ADAF_Cars/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف السيارات", page_url = "/ADAF_Cars/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل السيارات", page_url = "/ADAF_Cars/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل السيارات", page_url = "/ADAF_Cars/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "التوكيلات", page_url = "/LGL_Authorization/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة التوكيلات", page_url = "/LGL_Authorization/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف التوكيلات", page_url = "/LGL_Authorization/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل التوكيلات", page_url = "/LGL_Authorization/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل التوكيلات", page_url = "/LGL_Authorization/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "أنواع التوكيلات", page_url = "/LGL_Authorization_kinds/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة أنواع التوكيلات", page_url = "/LGL_Authorization_kinds/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف أنواع التوكيلات", page_url = "/LGL_Authorization_kinds/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل أنواع التوكيلات", page_url = "/LGL_Authorization_kinds/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل أنواع التوكيلات", page_url = "/LGL_Authorization_kinds/Edit", is_selected = false });


                lstchk.Add(new listchekbox { page_title = "التراخيص", page_url = "/LGL_Cause/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة التراخيص", page_url = "/LGL_Cause/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف التراخيص", page_url = "/LGL_Cause/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل التراخيص", page_url = "/LGL_Cause/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل التراخيص", page_url = "/LGL_Cause/Edit", is_selected = false });


                lstchk.Add(new listchekbox { page_title = "صفة الموكل", page_url = "/LGL_Client_types/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة صفة الموكل", page_url = "/LGL_Client_types/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف صفة الموكل", page_url = "/LGL_Client_types/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل صفة الموكل", page_url = "/LGL_Client_types/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل صفة الموكل", page_url = "/LGL_Client_types/Edit", is_selected = false });


                lstchk.Add(new listchekbox { page_title = "الموكل", page_url = "/LGL_Clients/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة الموكل", page_url = "/LGL_Clients/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف الموكل", page_url = "/LGL_Clients/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل الموكل", page_url = "/LGL_Clients/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل الموكل", page_url = "/LGL_Clients/Edit", is_selected = false });


                lstchk.Add(new listchekbox { page_title = "التراخيص", page_url = "/LGL_Court/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة التراخيص", page_url = "/LGL_Court/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف التراخيص", page_url = "/LGL_Court/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل التراخيص", page_url = "/LGL_Court/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل التراخيص", page_url = "/LGL_Court/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "القضايا", page_url = "/LGL_Lawsuit/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة القضايا", page_url = "/LGL_Lawsuit/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف القضايا", page_url = "/LGL_Lawsuit/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل القضايا", page_url = "/LGL_Lawsuit/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل القضايا", page_url = "/LGL_Lawsuit/Edit", is_selected = false });


                lstchk.Add(new listchekbox { page_title = "ملفات القضايا", page_url = "/LGL_lawsuit_files/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة ملفات القضايا", page_url = "/LGL_lawsuit_files/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف ملفات القضايا", page_url = "/LGL_lawsuit_files/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل ملفات القضايا", page_url = "/LGL_lawsuit_files/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل ملفات القضايا", page_url = "/LGL_lawsuit_files/Edit", is_selected = false });


                lstchk.Add(new listchekbox { page_title = "حالة القضايا", page_url = "/LGL_Lawsuit_Status/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة حالة القضايا", page_url = "/LGL_Lawsuit_Status/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف حالة القضايا", page_url = "/LGL_Lawsuit_Status/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل حالة القضايا", page_url = "/LGL_Lawsuit_Status/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل حالة القضايا", page_url = "/LGL_Lawsuit_Status/Edit", is_selected = false });


                lstchk.Add(new listchekbox { page_title = "الخصوم", page_url = "/LGL_Litigant/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة الخصوم", page_url = "/LGL_Litigant/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف الخصوم", page_url = "/LGL_Litigant/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل الخصوم", page_url = "/LGL_Litigant/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل الخصوم", page_url = "/LGL_Litigant/Edit", is_selected = false });


                lstchk.Add(new listchekbox { page_title = "الجلسات", page_url = "/LGL_Sessions/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة الجلسات", page_url = "/LGL_Sessions/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف الجلسات", page_url = "/LGL_Sessions/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل الجلسات", page_url = "/LGL_Sessions/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل الجلسات", page_url = "/LGL_Sessions/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "العقود", page_url = "/LGL_Contracting/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة العقود", page_url = "/LGL_Contracting/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف العقود", page_url = "/LGL_Contracting/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل العقود", page_url = "/LGL_Contracting/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل العقود", page_url = "/LGL_Contracting/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "السنترال", page_url = "/ Central/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة السنترال", page_url = "/Central/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف السنترال", page_url = "/Central/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل االسنترال", page_url = "/Central/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل السنترال", page_url = "/Central/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "التحقيقات", page_url = "/ investigation/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة التحقيقات", page_url = "investigation/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذفالتحقيقات", page_url = "investigation/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل التحقيقات", page_url = "investigation/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل التحقيقات", page_url = "investigation/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "الاداره", page_url = "/ Department/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة الاداره", page_url = "Department/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف الاداره", page_url = "Department/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل الاداره", page_url = "Department/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل الاداره", page_url = "Department/Edit", is_selected = false });


                lstchk.Add(new listchekbox { page_title = "الوظيفه", page_url = "/Jop/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة الوظيفه", page_url = "Jop/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف الوظيفه", page_url = "Jop/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل الوظيفه", page_url = "Jop/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل الوظيفه", page_url = "Jop/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "نوع العقد", page_url = "/Contracttybe/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة نوع العقد", page_url = "Contracttybe/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف نوع العقد", page_url = "Contracttybe/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل نوع العقد", page_url = "Contracttybe/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل نوع العقد", page_url = "Contracttybe/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "نسبه الزياده السنويه", page_url = "/Percent_value/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة نسبه الزياده السنويه", page_url = "Percent_value/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف نسبه الزياده السنويه", page_url = "Percent_value/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل نسبه الزياده السنويه", page_url = "Percent_value/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل نسبه الزياده السنويه", page_url = "Percent_value/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "نوع الزياده السنويه", page_url = "/type_annual_increase/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة نوع الزياده السنويه", page_url = "type_annual_increase/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف نوع الزياده السنويه", page_url = "type_annual_increase/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل نوع الزياده السنويه", page_url = "type_annual_increase/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل نوع الزياده السنويه", page_url = "type_annual_increase/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "الصلاحيات ", page_url = "/Permission_pages/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة الصلاحيات", page_url = "/Permission_pages/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف الصلاحيات", page_url = "/Permission_pages/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل الصلاحيات", page_url = "/Permission_pages/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل الصلاحيات", page_url = "/Permission_pages/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = "نوع مجموعات المستخدمين", page_url = "/Permission_group/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "اضافة مجموعات المستخدمين", page_url = "/Permission_group/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف مجموعات المستخدمين", page_url = "/Permission_group/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل مجموعات المستخدمين", page_url = "/Permission_group/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل مجموعات المستخدمين", page_url = "/Permission_group/Edit", is_selected = false });

                lstchk.Add(new listchekbox { page_title = " المستخدمين", page_url = "/Users/Index", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "المستخدمين", page_url = "Users/Create", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "حذف المستخدمين", page_url = "/Users/Delete", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تفاصيل المستخدمين", page_url = "/Users/Details", is_selected = false });
                lstchk.Add(new listchekbox { page_title = "تعديل المستخدمين", page_url = "/Users/Edit", is_selected = false });

                foreach (var item in lstchk)
                {
                    var tblchecked = _context.Permission_pagess.SingleOrDefault(c => c.page_name == item.page_url);
                    if (tblchecked != null)
                    {
                        item.is_selected = true;
                    }
                    else
                    {
                        item.is_selected = false;
                    }
                }

                var model = new permisions
                {
                    lstchekbox = lstchk,
                    group_id = id
                };


                return View(model);
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // POST: Permission_pages/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, permisions permisions)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                try
                {
                    // TODO: Add update logic here
                    //delete first
                    var dbdelete = _context.Permission_pagess.Where(c => c.permission_id == id);
                    if (dbdelete != null)
                    {
                        _context.Permission_pagess.RemoveRange(dbdelete);
                        _context.SaveChanges();
                    }
                    foreach (var item in permisions.lstchekbox)
                    {
                        if (item.is_selected == true)
                        {
                            Permission_pages p = new Permission_pages();
                            p.permission_id = permisions.group_id;
                            p.page_name = item.page_url;
                            _context.Permission_pagess.Add(p);
                            _context.SaveChanges();
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
            
        }

        // GET: Permission_pages/Delete/5
        public ActionResult Delete(int id)
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

        // POST: Permission_pages/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            bool isrole = get_roles();
            if (isrole == true)
            {
                try
                {
                    // TODO: Add delete logic here
                    var dbdelete = _context.Permission_pagess.Where(c => c.permission_id == id);
                    if (dbdelete != null)
                    {
                        _context.Permission_pagess.RemoveRange(dbdelete);
                        _context.SaveChanges();
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("noacces", "home");
            }
          
        }
    }
}