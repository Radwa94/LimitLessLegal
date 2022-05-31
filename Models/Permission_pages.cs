using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


    public class Permission_pages
    {
        [Key]
        [Display(Name = "م")]
        public int page_id { get; set; }
        [Display(Name = "اسم الصفحة")]
        public string page_name { get; set; }
        [Display(Name = "مجموعة الصلاحيات")]
        public int permission_id { get; set; }
        [ForeignKey("permission_id")]
        public Permission_group Permission_group { get; set; }
    }

