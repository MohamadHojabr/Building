using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.Enums
{
    /// <summary>
    /// مشخص کننده نوع محل ثبتی در آدرس  
    /// </summary>

    public enum LocationType
    {
        /// <summary>
        /// مغازه
        /// </summary>
        [Display(Name = "مغازه")]
        Shop = 5,
        /// <summary>
        /// شرکت
        /// </summary>
        [Display(Name = "شرکت")]
        Company = 10,
        /// <summary>
        /// مرکز
        /// </summary>
        [Display(Name = "مرکز")]
        Center = 15,
        /// <summary>
        /// موسسه
        /// </summary>
        [Display(Name = "موسسه")]
        Institution = 20,

        /// <summary>
        /// فروشگاه
        /// </summary>
        [Display(Name = "فروشگاه")]
        DepartmentStore = 20,

        /// <summary>
        /// انبار
        /// </summary>
        [Display(Name = "انبار")]
        Warehouse = 20,

        /// <summary>
        /// شعبه
        /// </summary>
        [Display(Name = "شعبه")]
        Branch = 20,



    }
}
