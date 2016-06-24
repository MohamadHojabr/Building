using System;
using System.Collections.Generic;
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

        public LocationType LocationType { get; set; }
        public string State { get; set; }
        public string City { get; set; }
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
