using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

    public class Branchleave
    {
    [Key]
    [Display(Name = "م")]
    public int id { get; set; }


    [Display(Name = "الفروع")]
    public int branch { get; set; }
    
    [ForeignKey("branch_idا")]
    public ADAF_Branches ADAF_Branches { get; set; }


    [Display(Name = "اسم الموسسه")]
    public string Company_name { get; set; }
    [Display(Name = "اسم صاحب الترخيص")]
    public string name_licens_holder { get; set; }
    [Display(Name = "اسم المدير المسؤل")]
    public string Name_responsible_manager { get; set; }
    [Display(Name = "تاريخ التعين")]
    public DateTime date_being_hired { get; set; }
    [Display(Name = "صوره بطاقه الصاحب")]
    public string nationaid_owner_img { get; set; }
    [Display(Name = "صوره بطاقه المدير")]
    public string nationaid_manager_img { get; set; }
    [Display(Name = "صوره الكارنيه")]
    public string card_owner_img { get; set; }
    [Display(Name = "صوره كارنيه المدير")]
    public string card_manager_img { get; set; }
    [Display(Name = "رقم تليفون ")]
    public string license_number_owner { get; set; }
    [Display(Name = "صوره ترحيص مزاوله المهنه للمدير")]
    public string License_number_Manager { get; set; }
    [Display(Name = "قيمه راتب المدير")]
    public string address { get; set; }
    [Display(Name = "رقم الرخصه")]
    public string license_number { get; set; }
    [Display(Name = "المنطقه الطبيه التبع لها")]
    public string medical_district { get; set; }
    [Display(Name = "مستخدم الانشاء")]
    public int creation_user { get; set; }
    [Display(Name = "اخر مستخدم تعديل")]
    public int last_update_user { get; set; }

}
