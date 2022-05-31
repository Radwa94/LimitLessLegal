using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


    public class Judgment
    {
    [Key]

    [Display(Name = "المسلسل")]
    public int ID_Judgment { get; set; }

    [Display(Name = "الحكم")]
    public string Judgmentn { get; set; }
}

