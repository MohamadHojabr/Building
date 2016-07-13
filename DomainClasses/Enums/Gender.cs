using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.Enums
{
    /// <summary>
    /// مشخص کننده جنسیت کاربر  
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// زن
        /// </summary>
        [Display(Name = "مرد")]
        Male,
        /// <summary>
        /// مرد
        /// </summary>
        [Display(Name = "زن")]
        Female,
    }

}
