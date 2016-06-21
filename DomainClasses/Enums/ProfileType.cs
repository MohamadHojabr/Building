using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.Enums
{
    /// <summary>
    /// مشخص کننده نوع پروفایل کاربری  
    /// </summary>
    public enum ProfileType
    {
        /// <summary>
        /// نوع پروفایل شخصی
        /// </summary>
        [Display(Name = "شخصی")]
        Personal,
        /// <summary>
        /// نوع پروفایل شرکتی
        /// </summary>
        [Display(Name = "شرکتی")]
        Company,
    }
}
