using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


    public class Department
    {
        [Key]

        [Display(Name = "مسلسل")]
        public int ID_Department { get; set; }

        [Display(Name = "الاداره")]
        public string Name { get; set; }
    }
