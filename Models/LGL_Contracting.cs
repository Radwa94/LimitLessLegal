using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


    public class LGL_Contracting
    {
    [Key]
    [Display(Name = "م")]
    public int contracting_id { get; set; }

    [Display(Name = "الفرع")]
    public string branchesID { get; set; }
    [Display(Name = "العنوان ")]
    public string Address { get; set; }
    [Display(Name = "نوع العقد")]
    public string ID_Contracttybe { get; set; }
    [Display(Name = "تاريخ التحرير")]
    public DateTime writen_date { get; set; }
    [Display(Name = "القيمة الايجارية")]
    public float contract_value { get; set; }
    [Display(Name = "الزياده السنويه")]
    public string increase_perc { get; set; }
    [Display(Name = "عدد السنين")]
    public float yearsnumber { get; set; }
    [Display(Name = "تاريخ بداية ")]
    public DateTime start_date { get; set; }
    [Display(Name = "تاريخ نهاية ")]
    public DateTime end_date { get; set; }
    [Display(Name = "الطرف الاول")]
    public string owner_name { get; set; }
    [Display(Name = "الطرف الثاني")]
    public string tenant_name { get; set; }

    [Display(Name = "مهله الترك")]
    public string leavetime { get; set; }

    [Display(Name = "قيمة التامين")]
    public float Insurance_value { get; set; }
    [Display(Name = "نوع الزياده السنويه")]
    public string ID_TypeAnnualIncrease { get; set; }

    [Display(Name = "بند حوالة العقد")]
    public string Contract_transfer_clause { get; set; }

    [Display(Name = "رقم الرخصه")]
    public string licensenumber { get; set; }
    [Display(Name = "المنطقه الطبيه التابع لها ")]
    public string medicalarea { get; set; }
    [Display(Name = "تاريخ اصدار الترخيص")]
    public DateTime Licensedate { get; set; }
    [Display(Name = "المدير المسؤل")]
    public string ManagingDirector { get; set; }

    [Display(Name = "ملاحظات")]
    public string contract_notes { get; set; }
    [Display(Name = "مستخدم الانشاء")]
    public int creation_user { get; set; }
    [Display(Name = "اخر مستخدم تعديل")]
    public int last_update_user { get; set; }

    [Display(Name = "صوره العقد")]
    public string Conimg { get; set; }
    [Display(Name = "ايقاف")]
    public bool cause_disable { get; set; }
    [Display(Name = "السنه")]
    public string Year { get; set; }
    [Display(Name = "تبداء من")]
    public DateTime? Startfrom { get; set; }
    [Display(Name = "القيمه الايجاريه")]
    public string Montvalue { get; set; }
    public string Year1 { get; set; }
    public DateTime? Startfrom1 { get; set; }
    public string Montvalue1 { get; set; }
    public string Year2 { get; set; }
    public DateTime? Startfrom2 { get; set; }
    public string Montvalue2 { get; set; }
    public string Year3 { get; set; }
    public DateTime? Startfrom3 { get; set; }
    public string Montvalue3 { get; set; }
    public string Year4 { get; set; }
    public DateTime? Startfrom4 { get; set; }
    public string Montvalue4 { get; set; }
    public string Year5 { get; set; }
    public DateTime? Startfrom5 { get; set; }
    public string Montvalue5 { get; set; }
    public string Year6 { get; set; }
    public DateTime? Startfrom6 { get; set; }
    public string Montvalue6 { get; set; }
    public string Year7 { get; set; }
    public DateTime? Startfrom7 { get; set; }
    public string Montvalue7 { get; set; }
    public string Year8 { get; set; }
    public DateTime? Startfrom8 { get; set; }
    public string Montvalue8 { get; set; }

}


