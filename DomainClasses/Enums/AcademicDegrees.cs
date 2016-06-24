using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.Enums
{
    /// <summary>
    /// مقاطع تحصیلات دانشگاهی
    /// </summary>
    public enum AcademicDegrees
    {
        /// <summary>
        ///  ابتدایی 
        /// </summary>
        [Display(Name = "ابتدایی")]
        Elementary = 5,

        /// <summary>
        ///  متوسطه 
        /// </summary>
        [Display(Name = "متوسطه")]
        MiddleSchool = 10,

        /// <summary>
        ///  دیپلم 
        /// </summary>
        [Display(Name = "دیپلم")]
        Diploma = 15,

        /// <summary>
        ///  لیسانس 
        /// </summary>
        [Display(Name = "کارشناسی")]
        BS = 20,
        /// <summary>
        /// فوق لیسانس
        /// </summary>
        [Display(Name = "کارشناسی ارشد")]
        MS = 25,
        /// <summary>
        /// دکتری
        /// </summary>
        [Display(Name = "دکتری")]
        PhD = 30,
        /// <summary>
        /// دوره های تخصصی دیگر
        /// </summary>
        [Display(Name = "دوره های تخصصی دیگر")]
        Other = 35
    }

}
