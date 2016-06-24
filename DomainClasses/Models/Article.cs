using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public string Name { get; set; }
        public string Summary { get; set; }
        public string ArticleText { get; set; }
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
