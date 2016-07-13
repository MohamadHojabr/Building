using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Building.Common.Helpers;
using DomainClasses.Enums;

namespace Building.ViewModels.Account
{
    public class CreateUserViewModel
    {
        [Required]
        [Display(Name = "نقش ها")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "گذر واژه")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار گذر واژه")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [DisplayName("نوع پروفایل ")]
        public ProfileType ProfileType { get; set; }

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
        public string Comment { get; set; }

        public DateTime? BirthDate { get; set; }
        public string BirthDatePersian
        {
            get
            {
                if (BirthDate.HasValue)
                    return ((DateTime)BirthDate).ToPersianDateTime2(includeHourMinute: false);

                return string.Empty;
            }
            set { BirthDate = PersianDate.ToGregorianDate2(value); }
        }
        [Required(ErrorMessage = "جنسیت را مشخص نکرده اید")]
        [DisplayName("جنسیت ")]
        public Gender Gender { get; set; }
        public Guid MainCategoryId { get; set; }

    }
}
