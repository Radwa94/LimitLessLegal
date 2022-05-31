using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


public class Jop
{
    [Key]

    [Display(Name = "المسلسل")]
    public int ID_jop { get; set; }

    [Display(Name = "الوظيفه")]
    public string Name { get; set; }
}
