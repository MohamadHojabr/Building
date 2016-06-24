using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Buolding.Utility;

namespace DomainClasses.Models
{
    public class Article : BaseEntity
    {
        #region Ctor

        /// <summary>
        ///     create one instance of <see cref="Article" />
        /// </summary>
        public Article()
        {
            ArticleId = SequentialGuidGenerator.NewSequentialGuid();
        }

        #endregion

        #region Properties

        [Key]
        public Guid ArticleId { get; set; }
        [Required(ErrorMessage = "لطفا نام مقاله را وارد کنید")]
        [DisplayName("نام مقاله")]
        [MaxLength(256)]
        public string Name { get; set; }
        [DisplayName("خلاصه مقاله")]
        public string Summary { get; set; }
        [Required(ErrorMessage = "لطفا متن مقاله را وارد کنید")]
        [DisplayName("متن مقاله")]
        [AllowHtml]
        public string ArticleText { get; set; }
        [DisplayName("منابع مقاله")]
        public string ArticleSource { get; set; }
        public int Rate { get; set; }
        public string ThumbnailImage { get; set; }

        #endregion

        #region NavigationProperties

        public Guid PersonalProfileId { get; set; }
        public virtual PersonalProfile PersonalProfile { get; set; }
        public Guid CompanyProfileId { get; set; }
        public virtual CompanyProfile CompanyProfile { get; set; }

        public ICollection<ArticleFile> ArticleFiles { get; set; }

        #endregion
    }
}
