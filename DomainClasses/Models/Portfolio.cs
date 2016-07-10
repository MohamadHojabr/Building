using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Buolding.Utility;

namespace DomainClasses.Models
{
    public class Portfolio : BaseEntity
    {
        #region Ctor

        /// <summary>
        ///     create one instance of <see cref="Portfolio" />
        /// </summary>
        public Portfolio()
        {
            PortfolioId = SequentialGuidGenerator.NewSequentialGuid();
        }

        #endregion

        #region Properties

        [Key]
        public Guid PortfolioId { get; set; }

        [Required(ErrorMessage = "لطفا نام را وارد کنید")]
        [DisplayName("نام ")]
        [MaxLength(256)]
        public string Name { get; set; }

        [DisplayName("تصویر ")]
        public string ThumbnailImage { get; set; }

        [DisplayName("توضیحات ")]
        [AllowHtml]
        public string Describtion { get; set; }

        public int Rate { get; set; }

        #endregion

        #region NavigationProperties

        public Guid ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual ICollection<PortfolioFile> PortfolioFiles { get; set; }

        #endregion
    }
}
