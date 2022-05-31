using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class LGL_Clients
    {
    [Key]
    [Display(Name = "م")]
    public int client_id { get; set; }

    [Display(Name = "الأسـم")]
    public string client_name { get; set; }
    [Display(Name = "العنوان")]
    
    public string client_address     { get; set; }
    [Display(Name = "تاريخ القيد ")]
    [DataType(DataType.Date)]
    public DateTime associate_date { get; set; }
    [Display(Name = "تليفون 1")]
    [DataType(DataType.PhoneNumber)]
    public string ph1 { get; set; }
    [Display(Name = "تليفون 2")]
    [DataType(DataType.PhoneNumber)]
    public string ph2 { get; set; }
    [Display(Name = "الرقم القومى")]
    public string nationid { get; set; }

    [Display(Name = "صفه الموكل")]
    public int client_type_id { get; set; }
    [ForeignKey("client_type_id")]
    public LGL_Client_types LGL_Client_types { get; set; }

    [Display(Name = "ايقاف")]
    public bool client_disable { get; set; }
    [Display(Name = "مستخدم الانشاء")]
    public int creation_user { get; set; }
    [Display(Name = "اخر مستخدم تعديل")]
    public int last_update_user { get; set; }
}

