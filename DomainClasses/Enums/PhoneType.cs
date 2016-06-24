using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.Enums
{
    /// <summary>
    /// مشخص کننده نوع تلفن درج شده در آدرس  
    /// </summary>

    public enum PhoneType
    {
        /// <summary>
        /// تلفن ثابت منزل
        /// </summary>
        [Display(Name = "تلفن ثابت منزل")]
        PhoneHome = 5,
        /// <summary>
        /// تلفن ثابت شرکت
        /// </summary>
        [Display(Name = "تلفن ثابت شرکت")]
        PhoneCompany = 10,
        /// <summary>
        /// فکس
        /// </summary>
        [Display(Name = "فکس")]
        Fax = 15,
        /// <summary>
        /// تلفن همراه
        /// </summary>
        [Display(Name = "تلفن همراه")]
        Mobile = 20,


    }
}
