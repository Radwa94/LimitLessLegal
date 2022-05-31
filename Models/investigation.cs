using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


    public class investigation
    {
    [Key]
    [Display(Name = "مسلسل")]
    public int ID_investigation { get; set; }
    [Display(Name = "رقم الشكوي/السنه")]
    public string Noofcomplain { get; set; }
    [Display(Name = "اسم الموظف ")]
    public string Employeename { get; set; }
    [Display(Name = "الكود الوظيفي")]
    public string Employeeid { get; set; }
    [Display(Name = "الرقم القومي")]
    public string Nationalid { get; set; }
    [Display(Name = "الوظيفه")]
    public int ID_jop { get; set; }
    [Display(Name = "الوظيفه")]
    [ForeignKey("ID_jop")]
    public Jop jop { get; set; }
    [Display(Name = "الشكوي")]
    public string NatureComplaint { get; set; }
    [Display(Name = "تاريخ التحقيق")]
    public DateTime Invstdate { get; set; }
    [Display(Name = "القرار")]
    public string Decisionafterinvst { get; set; }
   
    [Display(Name = "ملاحظات")]
    public string Invstnotes { get; set; }

    [Display(Name = "الاداره")]
    public int ID_Department { get; set; }
    [Display(Name = "الاداره")]
    [ForeignKey("ID_Department")]
    public Department department { get; set; }

    [Display(Name = "المحقق")]
    public string Investigator { get; set; }
    [Display(Name = "كود الوظيفي المحقق")]
    public string Idinvist { get; set; }
    [Display(Name = "ملف التحقيق")]
    public string Invimage { get; set; }

    [Display(Name = "مستخدم الانشاء")]
    public int creation_user { get; set; }
    [Display(Name = "اخر مستخدم تعديل")]
    public int last_update_user { get; set; }

}


