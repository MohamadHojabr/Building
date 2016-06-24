using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Buolding.Utility;
using DomainClasses.Enums;

namespace DomainClasses.Models
{
    public class Contact : BaseEntity
    {
        #region Ctor

        /// <summary>
        ///     create one instance of <see cref="Contact" />
        /// </summary>
        public Contact()
        {
            ContactId = SequentialGuidGenerator.NewSequentialGuid();
        }

        #endregion

        #region Properties

        [Key]
        public Guid ContactId { get; set; }

        [Required(ErrorMessage = "لطفا پیش شماره را وارد کنید")]
        [DisplayName("پیش شماره")]
        public int AreaCode { get; set; }
        [Required(ErrorMessage = "لطفا شماره را وارد کنید")]
        [DisplayName("شماره")]
        public int Number { get; set; }
        [Required(ErrorMessage = "لطفا محل را انتخاب کنید")]
        [DisplayName("تلفن محل")]
        public LocationType LocationType { get; set; }
        [Required(ErrorMessage = "لطفا محل را انتخاب کنید")]
        [DisplayName("تلفن محل")]
        public PhoneType PhoneType { get; set; }

        #endregion

        #region NavigationProperties

        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }

        #endregion
    }
}
