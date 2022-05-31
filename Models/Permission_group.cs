using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


    public class Permission_group
    {
    [Key]
    [Display(Name = "م")]
    public int permission_id { get; set; }
    [Display(Name = "الأسم")]
    public string permission_name { get; set; }
    }

