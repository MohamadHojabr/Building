using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Buolding.Utility;
using DomainClasses.Enums;

namespace DomainClasses.Models
{
    public class Address : BaseEntity
    {
        #region Ctor

        /// <summary>
        ///     create one instance of <see cref="Address" />
        /// </summary>
        public Address()
        {
            AddressId = SequentialGuidGenerator.NewSequentialGuid();
        }

        #endregion

        #region Properties

        [Key]
        public Guid AddressId { get; set; }
        [Required(ErrorMessage = "لطفا محل را انتخاب کنید")]
        [DisplayName("آدرس محل")]
        public LocationType LocationType { get; set; }
        [Required(ErrorMessage = "لطفا استان را انتخاب کنید")]
        [DisplayName("استان")]
        [MaxLength(256)]
        public string State { get; set; }
        [Required(ErrorMessage = "لطفا شهر را انتخاب کنید")]
        [DisplayName("شهر")]
        [MaxLength(256)]
        public string City { get; set; }
        [DisplayName("آدرس کامل")]
        [MaxLength(1024)]
        public string CompleteAddress { get; set; }

        #endregion

        #region NavigationProperties

        public Guid PersonalProfileId { get; set; }
        public virtual PersonalProfile PersonalProfile { get; set; }
        public Guid CompanyProfileId { get; set; }
        public virtual CompanyProfile CompanyProfile { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }

        #endregion
    }
}
