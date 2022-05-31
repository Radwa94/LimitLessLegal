using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


    public class LGL_Authorization_kinds
    {
        [Key]
        [Display(Name = "م")]
        public int authorization_kinds_id { get; set; }
        [Required]
        [Display(Name = "الأسـم")]
        public string authorization_kinds_name { get; set; }
        [Display(Name = "مستخدم الانشاء")]
        public int creation_user { get; set; }
        [Display(Name = "اخر مستخدم تعديل")]
        public int last_update_user { get; set; }
        [Display(Name = "ايقاف")]
        public bool authorization_kinds_disable { get; set; }
    }

