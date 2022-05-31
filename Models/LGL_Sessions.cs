using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


    public class LGL_Sessions
    {
        [Key]
        [Display(Name = "م")]
        public int sessions_id { get; set; }

     [Display(Name = "رقم القضية")]
      public int lawsuit_id { get; set; }
     [ForeignKey("lawsuit_id")]
     [Display(Name = "رقم القضية")]
     public LGL_Lawsuit LGL_Lawsuit { get; set; }
   
    [Display(Name = "السنه")]
    public string year { get; set; }
    [Display(Name = "النوع")]
    public string type { get; set; }
    [Display(Name = "الدائره")]
    public string area { get; set; }
    [Display(Name = "المحكمة")]
    public string court_id { get; set; }

    [Display(Name = "سبب التأجيل")]
    public string delay_reason { get; set; }
   
   
    [Display(Name = "الخصم")]
    public string litigant_id { get; set; }
    [Display(Name = "الجلسه القادمه")]
        public DateTime session_next_date { get; set; }
    [Display(Name = "الموضوع")]
    public string subject { get; set; }

    [Display(Name = "مستخدم الانشاء")]
        public int creation_user { get; set; }
        [Display(Name = "اخر مستخدم تعديل")]
        public int last_update_user { get; set; }
    [Display(Name = "منتهيه")]
    public bool finished { get; set; }

    [Display(Name = "رقم الرول")]
    public string rollno { get; set; }
    [Display(Name = "تاريخ الجلسة")]
    public DateTime? session_date { get; set; }
    [Display(Name = "القرار")]
    public string decision { get; set; }
    [Display(Name = "المطلوب")]
    public string requests { get; set; }




}

