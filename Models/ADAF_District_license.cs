using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


    public class ADAF_District_license
    {
        [Key]
        [Display(Name = "م")]
        public int district_license_id { get; set; }


        [Display(Name = "الفرع")]
        public int branch_id { get; set; }
        [Display(Name = "الفرع")]
        [ForeignKey("branch_id")]
        public ADAF_Branches ADAF_Branches { get; set; }


        [Display(Name = "نوع الترخيص")]
        public string district_license_type_id { get; set; }


        [Display(Name = "تاريخ الترخيص")]
        public DateTime license_start { get; set; }
        [Display(Name = "تاريخ انتهاء الترخيص")]
        public DateTime license_end { get; set; }
        [Display(Name = "الحى المصدر للترخيص")]
        public string district_name { get; set; }

         [Display(Name = "صوره الترخيص")]
         public string district_img { get; set; }

         [Display(Name = "ملاحظات")]
        public string license_notes { get; set; }
    [Display(Name = "مستخدم الانشاء")]
    public int creation_user { get; set; }
    [Display(Name = "اخر مستخدم تعديل")]
    public int last_update_user { get; set; }
}