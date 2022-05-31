using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


    public class LGL_Cause
    {
        [Key]
        [Display(Name = "م")]
        public int cause_id { get; set; }
        [Required]
        [Display(Name = "نوع القضيه")]
        public string cause_name { get; set; }
        [Display(Name = "مستخدم الانشاء")]
        public int creation_user { get; set; }
        [Display(Name = "اخر مستخدم تعديل")]
        public int last_update_user { get; set; }
        [Display(Name = "ايقاف")]
        public bool cause_disable { get; set; }

    }

