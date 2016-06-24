using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Buolding.Utility;

namespace DomainClasses.Models
{
    public class UseLocation : BaseEntity
    {
        #region Ctor

        /// <summary>
        ///     create one instance of <see cref="UseLocation" />
        ///     محل استفاده ی محصول ثبت شده
        /// </summary>
        public UseLocation()
        {
            UseLocationId = SequentialGuidGenerator.NewSequentialGuid();
        }

        #endregion

        #region Properties

        [Key]
        public Guid UseLocationId { get; set; }

        [Required(ErrorMessage = "لطفا نام را وارد کنید")]
        [DisplayName("نام ")]
        [MaxLength(256)]
        public string Name { get; set; }

        [DisplayName("توضیحات ")]
        [AllowHtml]
        public string Describtion { get; set; }

        #endregion

        #region NavigationProperties

        public virtual ICollection<Product> Products { get; set; }

        #endregion
    }
}
