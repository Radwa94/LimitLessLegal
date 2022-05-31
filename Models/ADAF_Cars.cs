using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


    public class ADAF_Cars
    {
        [Key]
        [Display(Name = "م")]
        public int car_id { get; set; }
        [Display(Name = "رقم اللوحة")]
        public string car_board { get; set; }
        [Display(Name = "رقم الشاسيه")]
        public string car_chassis { get; set; }
        [Display(Name = "رقم الموتور")]
        public string car_motor { get; set; }
        [Display(Name = "ماركة السيارة")]
        public string car_brand { get; set; }
        [Display(Name = "تاريخ اصدار الرخصه")]
        public DateTime license_start_date { get; set; }
        [Display(Name = "تاريخ انتهاء الرخصه")]
        public DateTime license_end_date { get; set; }
        [Display(Name = "تاريخ الفحص")]
        public DateTime license_examination_date { get; set; }
        [Display(Name = "المرور")]
        public string trafiic_name { get; set; }
        [Display(Name = "حيازة")]
        public string person_used { get; set; }
        [Display(Name = "السائق المؤمن عليه")]
        public string   driver_insurance { get; set; }
       [Display(Name = "صوره الرخصه")]
        public string licenseimg { get; set; }
        [Display(Name = "مستخدم الانشاء")]
        public int creation_user { get; set; }
        [Display(Name = "اخر مستخدم تعديل")]
        public int last_update_user { get; set; }
        
    }

