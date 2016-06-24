using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Buolding.Utility;

namespace DomainClasses.Models
{
    public class VideoGallery : BaseEntity
    {
        #region Ctor

        /// <summary>
        ///     create one instance of <see cref="VideoGallery" />
        /// </summary>
        public VideoGallery()
        {
            VideoGalleryId = SequentialGuidGenerator.NewSequentialGuid();
        }

        #endregion

        #region Properties

        [Key]
        public Guid VideoGalleryId { get; set; }

        [Required(ErrorMessage = "لطفا نام را وارد کنید")]
        [DisplayName("نام ")]
        [MaxLength(256)]
        public string Name { get; set; }

        [DisplayName("توضیحات")]
        [AllowHtml]
        public string Describtion { get; set; }

        [DisplayName("تصویر ")]
        public string ThumbnailImage { get; set; }

        public int Rate { get; set; }

        #endregion

        #region NavigationProperties

        public Guid PersonalProfileId { get; set; }
        public virtual PersonalProfile PersonalProfile { get; set; }
        public Guid CompanyProfileId { get; set; }
        public virtual CompanyProfile CompanyProfile { get; set; }

        public ICollection<VideoGalleryFile> VideoGalleryFiles { get; set; }

        #endregion
    }
}
