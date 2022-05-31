using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


    public class Central
    {
        [Key]

        [Display(Name = "مسلسل")]
        public int ID_central { get; set; }



        [Display(Name = "الفروع")]
        public int branch_id { get; set; }
        [Display(Name = "الفروع")]
        [ForeignKey("branch_id")]
        public ADAF_Branches aDAF_Branches { get; set; }



        [Display(Name = "رقم التليفون الارضي1 ")]
        public string LandlineNumber1 { get; set; }

        [Display(Name = "رقم التليفون الارضي2 ")]
        public string LandlineNumber { get; set; }

        [Display(Name = "رقم الموبيل ")]
        public string MobileNo { get; set; }

        [Display(Name = "السنترال التابع له")]
        public string AffiliateCentral { get; set; }

        [Display(Name = "قيمه فاتوره الانترنت ")]
        public string InternetBillValue { get; set; }

        [Display(Name = "تاريخ الاشتراك")]
        public DateTime Subscriptiondate { get; set; }

        [Display(Name = "الباقه")]
        public string Thebunch { get; set; }

        [Display(Name = "تصحيح الوضع ")]
        public string CorrectTheSituation { get; set; }

        [Display(Name = "من")]
        public string FromCts { get; set; }

        [Display(Name = "الي")]
        public string ToCts { get; set; }

        [Display(Name = "ملاحظات")]
        public string Note { get; set; }
    [Display(Name = "مستخدم الانشاء")]
    public int creation_user { get; set; }
    [Display(Name = "اخر مستخدم تعديل")]
    public int last_update_user { get; set; }

}

