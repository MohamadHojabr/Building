using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Buolding.Utility;

namespace DomainClasses.Models
{
    public class Brand : BaseEntity
    {
        #region Ctor

        /// <summary>
        ///     create one instance of <see cref="Brand" />
        /// </summary>
        public Brand()
        {
            BrandId = SequentialGuidGenerator.NewSequentialGuid();
        }

        #endregion

        #region Properties

        [Key]
        public Guid BrandId { get; set; }
        [Required(ErrorMessage = "لطفا نام برند را وارد کنید")]
        [DisplayName("نام برند")]
        [MaxLength(256)]
        public string Name { get; set; }
        [DisplayName("توضیحات")]
        [MaxLength(1024)]
        public string Describtion { get; set; }

        #endregion

        #region NavigationProperties

        public virtual ICollection<Product> Products { get; set; }

        #endregion
    }
}
