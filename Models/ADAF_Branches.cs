using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


    public class ADAF_Branches
    {
         [Key]
        [Display(Name = "م")]
        public int branch_id { get; set; }
        [Display(Name = "الأسم")]
        public string branch_name { get; set; }

        [Display(Name = "مستخدم الانشاء")]
        public int creation_user { get; set; }
        [Display(Name = "اخر مستخدم تعديل")]
        public int last_update_user { get; set; }
        [Display(Name = "ايقاف")]
        public bool cause_disable { get; set; }
    }

