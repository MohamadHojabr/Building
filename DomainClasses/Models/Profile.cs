﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Building.Common.Helpers;
using Buolding.Utility;
using DomainClasses.Enums;

namespace DomainClasses.Models
{
    public class Profile:BaseEntity
    {
        #region Ctor
        /// <summary>
        /// create one instance of <see cref="DomainClasses.Models.Profile"/>
        /// </summary>

        public Profile()
        {
            //ProfileId = SequentialGuidGenerator.NewSequentialGuid();
        }

        #endregion

        #region Properties
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "نوع پروفایل را مشخص نکرده اید")]
        [DisplayName("نوع پروفایل ")]
        public ProfileType ProfileType { get; set; }

        [Required(ErrorMessage = "جنسیت را مشخص نکرده اید")]
        [DisplayName("جنسیت ")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "لطفا نام را وارد کنید")]
        [DisplayName("نام ")]
        [MaxLength(256)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "لطفا نام خانوادگی را وارد کنید")]
        [DisplayName("نام خانوادگی ")]
        [MaxLength(256)]
        public string LastName { get; set; }

        [DisplayName("تصویر پروفایل")]
        public string ProfilePicture { get; set; }
        [MaxLength(256)]
        [DisplayName("توضیحات")]
        public string Comment { get; set; }
        [DisplayName("تاریخ تولد")]

        [DataType(DataType.DateTime, ErrorMessage = "فرمت تاریخ صحیح نیست")]
        [Display(Name = "تاریخ")]
        [Required(ErrorMessage = "تاریخ تولد را وارد کنید")]
        public DateTime BirthDate { get; set; }

        [NotMapped]
        [Display(Name = "تاریخ")]
        [DataType(DataType.DateTime, ErrorMessage = "فرمت تاریخ صحیح نیست")]
        public string BirthDateString
        {
            get
            {
                return BirthDate.ToPersianDateTime2(includeHourMinute: false);
            }
            set
            {
                BirthDate = PersianDate.ToGregorianDate2(value);
            }
        }


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
        public string SocialInstagram { get; set; }
        #endregion

        #region Property If Profile is compony
        //[Required(ErrorMessage = "لطفا نام پروفایل را وارد کنید")]
        [DisplayName("نام برند")]
        public string CompanyName { get; set; }
        [DisplayName("شماره ثبت")]
        public string RegistrationNumber { get; set; }
        //[Required(ErrorMessage = "لطفا زمینه فعالیت را وارد کنید")]
        [DisplayName("زمینه فعالیت")]
        public string FieldOfActivity { get; set; }

        #endregion

        #region NavigationProperties
        //public string UserId { get; set; }
        [ForeignKey("Id")]
        public virtual ApplicationUser RelatedUser { get; set; }
        public Guid MainCategoryId { get; set; }
        public virtual MainCategory MainCategory { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Portfolio> Portfolios { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<ImageGallery> ImageGalleries { get; set; }
        public virtual ICollection<VideoGallery> VideoGalleries { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProfileFile> ProfileFiles { get; set; }
        #endregion

        #region NotMapped props
        [DisplayName("نام و نام خانوادگی")]

        [NotMapped]
        public string FullName => FirstName + " " + LastName;
        [NotMapped]
        public string PictureUrl => "/Uploads/Profile/" + ProfilePicture;


        #endregion

    }
}
