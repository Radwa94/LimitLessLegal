using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


    public class LGL_lawsuit_files
    {
        [Key]
        [Display(Name = "م")]
        public int lawsuit_files_id { get; set; }
        [Display(Name = "القضية")]
        public int lawsuit_id { get; set; }
        [ForeignKey("lawsuit_id")]
        public LGL_Lawsuit LGL_Lawsuit { get; set; }
        [Display(Name = "ملفات القضيه")]
        [DataType(DataType.ImageUrl)]
        public string lawsuit_files_img { get; set; }
        [Display(Name = "مستخدم الانشاء")]
        public int creation_user { get; set; }
        [Display(Name = "اخر مستخدم تعديل")]
        public int last_update_user { get; set; }
    }

