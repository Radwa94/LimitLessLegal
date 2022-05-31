using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


public class LGL_Client_types
    {
    
    [Key]
    [Display(Name = "م")]
    public int client_type_id { get; set; }

    [Display(Name = "الأسم")]
    public string client_type_name { get; set; }
    [Display(Name = "مستخدم الانشاء")]
    public int creation_user { get; set; }
    [Display(Name = "اخر مستخدم تعديل")]
    public int last_update_user { get; set; }
    [Display(Name = "ايقاف")]
    public bool client_type_disable { get; set; }
    }

