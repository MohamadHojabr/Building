using System;
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

        public int AreaCode { get; set; }
        public int Number { get; set; }
        public LocationType LocationType { get; set; }
        public PhoneType PhoneType { get; set; }

        #endregion

        #region NavigationProperties

        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }

        #endregion
    }
}
