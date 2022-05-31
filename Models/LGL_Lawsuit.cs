using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


    public class LGL_Lawsuit
    {
        [Key]
        [Display(Name = "م")]
        public int lawsuit_id { get; set; }
    [Display(Name = "رقم القضية")]
    public string lawsuit_number { get; set; }
    [Display(Name = "السنه")]
    public string cause_year { get; set; }

    [Display(Name = "نوع القضية")]
    public int cause_id { get; set; }
    [Display(Name = "نوع القضية")]
    [ForeignKey("cause_id")]
    public LGL_Cause LGL_Cause { get; set; }
    [Display(Name = "الدائرة")]
    public string lawsuit_circle { get; set; }

    [Display(Name = "المحكمة")]
    public int court_id { get; set; }
    [Display(Name = "المحكمة")]
    [ForeignKey("court_id")]
    public LGL_Court lGL_Court { get; set; }

    [Display(Name = "تاريخ الجلسة")]
    public DateTime sitting_date_first { get; set; }
    [Display(Name = "الخصم")]
    public int litigant_id { get; set; }
    [Display(Name = "الخصم")]
    [ForeignKey("litigant_id")]
    public LGL_Litigant lGL_Litigant { get; set; }

    [Display(Name = "الموكل")]
     public int client_id { get; set; }
        [Display(Name = "الموكل")]
         [ForeignKey("client_id")]
        public LGL_Clients LGL_Clients { get; set; }

     [Display(Name = "صفه الموكل")]
     public int client_type_id { get; set; }
     [Display(Name = "صفه الموكل")]
     [ForeignKey("LGL_Client_types")] 
     public LGL_Client_types LGL_Client_Types { get; set; }


    [Display(Name = "الحكم")]
    public int ID_Judgment { get; set; }
    [Display(Name = "الحكم")]
    [ForeignKey("ID_Judgment")]
    public Judgment judgment { get; set; }


    [Display(Name = "منطوق الحكم")]
    public string PronouncingJudgment { get; set; }

    [Display(Name = "درجة القضية")]
    public string lawsuit_degree { get; set; }

    [Display(Name = "رقم الحصر")]
    public string trapping_number { get; set; }
    [Display(Name = "حالة القضية")]
    public int lawsuit_Status_id { get; set; }
    [Display(Name = "حالة القضية")]
    [ForeignKey("lawsuit_Status_id")]
    public LGL_Lawsuit_Status lGL_Lawsuit_Status { get; set; }
    [Display(Name = "تاريخ قيد القضية")]
    public DateTime associate_date { get; set; }
    [Display(Name = "موضوع القضية")]
    public string lawsuit_description { get; set; }
    [Display(Name = "مستخدم الانشاء")]
    public int creation_user { get; set; }
    [Display(Name = "اخر مستخدم تعديل")]
    public int last_update_user { get; set; }
    [Display(Name = "ملفات القضية")]
    public string lawsuitfile { get; set; }

}

