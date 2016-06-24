using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Buolding.Utility;

namespace DomainClasses.Models
{
    public class Product : BaseEntity
    {
        #region Ctor

        /// <summary>
        ///     create one instance of <see cref="Product" />
        /// </summary>
        public Product()
        {
            ProductId = SequentialGuidGenerator.NewSequentialGuid();
        }

        #endregion

        #region Properties

        [Key]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "لطفا نام را وارد کنید")]
        [DisplayName("نام ")]
        [MaxLength(256)]
        public string Name { get; set; }

        [DisplayName("توضیحات ")]
        [AllowHtml]
        public string Describtion { get; set; }

        public int Rate { get; set; }

        #endregion

        #region NavigationProperties

        public Guid BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public Guid UseLocationId { get; set; }
        public virtual UseLocation UseLocation { get; set; }
        public Guid PersonalProfileId { get; set; }
        public virtual PersonalProfile PersonalProfile { get; set; }
        public Guid CompanyProfileId { get; set; }
        public virtual CompanyProfile CompanyProfile { get; set; }
        public virtual ICollection<ProductFile> ProductFiles { get; set; }

        #endregion
    }
}
