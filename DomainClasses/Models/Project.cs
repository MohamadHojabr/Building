using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Buolding.Utility;

namespace DomainClasses.Models
{
    public class Project
    {
        #region Ctor

        /// <summary>
        ///     create one instance of <see cref="Project" />
        /// </summary>
        public Project()
        {
            ProjectId = SequentialGuidGenerator.NewSequentialGuid();
        }

        #endregion

        #region Properties

        [Key]
        public Guid ProjectId { get; set; }

        [Required(ErrorMessage = "لطفا نام را وارد کنید")]
        [DisplayName("نام ")]
        [MaxLength(256)]
        public string Name { get; set; }

        [DisplayName("تصویر ")]
        public string ThumbnailImage { get; set; }

        [DisplayName("توضیحات ")]
        [AllowHtml]
        public string Describtion { get; set; }

        [DisplayName("تاریخ شروع پروژه ")]
        public DateTime? ProjectStartDate { get; set; }

        [DisplayName("تاریخ اتمام پروژه ")]
        public DateTime? ProjectEndDate { get; set; }

        [DisplayName("محل اجرای پروژه ")]
        public string OperationPlace { get; set; }

        [DisplayName("کارفرما ")]
        [MaxLength(256)]
        public string Employer { get; set; }

        [DisplayName("رضایت نامه کار فرما ")]
        public string Testimonial { get; set; }

        #endregion

        #region NavigationProperties

        public Guid PersonalProfileId { get; set; }
        public virtual PersonalProfile PersonalProfile { get; set; }
        public Guid CompanyProfileId { get; set; }
        public virtual CompanyProfile CompanyProfile { get; set; }

        public ICollection<ProductFile> ProductFiles { get; set; }

        #endregion
    }
}
