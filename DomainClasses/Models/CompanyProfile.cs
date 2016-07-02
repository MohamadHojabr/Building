using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Buolding.Utility;

namespace DomainClasses.Models
{
    public class CompanyProfile : BaseEntity
    {
        #region Ctor

        public CompanyProfile()
        {
            CompanyProfileId = SequentialGuidGenerator.NewSequentialGuid();
        }

        #endregion

        #region Properties

        [Key]
        public Guid CompanyProfileId { get; set; }
        [Required(ErrorMessage = "لطفا نام پروفایل را وارد کنید")]
        [DisplayName("نام برند")]
        public string CompanyName { get; set; }
        [DisplayName("شماره ثبت")]
        public string RegistrationNumber { get; set; }
        [Required(ErrorMessage = "لطفا زمینه فعالیت را وارد کنید")]
        [DisplayName("زمینه فعالیت")]
        public string FieldOfActivity { get; set; }
        [DisplayName("تصویر پروفایل")]
        public string ProfilePicture { get; set; }
        [DisplayName("آدرس شبکه اجتماعی گوگل پلاس")]
        [MaxLength(512)]
        public string SocialGooglePlus { get; set; }
        [DisplayName("آدرس شبکه اجتماعی فیس بوک")]
        [MaxLength(512)]

        public string SocialFacebok { get; set; }
        [DisplayName("آدرس شبکه اجتماعی توئیتر")]
        [MaxLength(512)]

        public string SocialTwiter { get; set; }
        [DisplayName("آدرس شبکه اجتماعی تلگرام")]
        [MaxLength(512)]

        public string SocialTelegram { get; set; }
        [DisplayName("آدرس شبکه اجتماعی اینستاگرام")]
        [MaxLength(512)]

        public string Socialinstagram { get; set; }

        #endregion

        #region NavigationProperties

        public virtual ApplicationUser RelatedUser { get; set; }
        public Guid MainCategoryId { get; set; }
        public virtual MainCategory MainCategory { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Portfolio> Portfolios { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<ImageGallery> ImageGalleries { get; set; }
        public virtual ICollection<VideoGallery> VideoGalleries { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        #endregion
    }
}
