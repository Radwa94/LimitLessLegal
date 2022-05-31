using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


    public class Users
    {
        [Key]
    [Display(Name = "م")]
    public int userId { get; set; }
    [Display(Name = "اسم المستخدم")]
    public string username { get; set; }
    [Display(Name = "كلمة المرور")]
    public string userpassword { get; set; }
    [Display(Name = "البريد الألكترونى")]
    [DataType(DataType.EmailAddress)]
    public string useremail { get; set; }
    [Display(Name = "تاريخ الأضافة")]
    public DateTime date_add { get; set; }
    [Display(Name = "مجموعة الصلاحيات")]
    public int permission_id { get; set; }
    [ForeignKey("permission_id")]
    public Permission_group Permission_group { get; set; }

}

