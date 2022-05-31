using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


public class LGL_Authorization
{
    [Key]
    [Display(Name = "م")]
    public int authorization_id { get; set; }
    [Required]
    [Display(Name = "رقم التوكيل")]
    public string authorization_code { get; set; }
    [Display(Name = "مصدر التوكيل")]
    public string authorization_source { get; set; }
    [Display(Name = "حرف التوكيل")]
    public string authorization_character { get; set; }
    [Display(Name = "السنه")]
    public string authorization_year { get; set; }
    [Display(Name = "نوع التوكيل")]
    public int authorization_kinds_id { get; set; }
    [Display(Name = "نوع التوكيل")]
    [ForeignKey("authorization_kinds_id")]
    public LGL_Authorization_kinds LGL_Authorization_kinds { get; set; }

    [Display(Name = "اسم التوكيل")]
    public string authorization_name { get; set; }
    [Display(Name = "الموكل")]
    public string Client_name { get; set; }
        [Display(Name = "مستخدم الانشاء")]
        public int creation_user { get; set; }
        [Display(Name = "اخر مستخدم تعديل")]
        public int last_update_user { get; set; }
    [Display(Name = "صورة التوكيل")]
    [DataType(DataType.ImageUrl)]
    public string authorization_img { get; set; }
    [Display(Name = "ايقاف")]        
        public bool authorization_disable { get; set; }

    }

