using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buolding.Utility;

namespace DomainClasses.Models
{
    public class PersonalProfile : BaseEntity
    {
        #region Ctor

        public PersonalProfile()
        {
            PersonalProfileId = SequentialGuidGenerator.NewSequentialGuid();
        }

        #endregion


        #region Properties
        [Key]
        public Guid PersonalProfileId { get; set; }
        [Required(ErrorMessage = "لطفا نام را وارد کنید")]
        [DisplayName("نام ")]
        [MaxLength(256)]
        public string Name { get; set; }
        [Required(ErrorMessage = "لطفا نام خانوادگی را وارد کنید")]
        [DisplayName("نام خانوادگی ")]
        [MaxLength(256)]
        public string LastName { get; set; }
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
