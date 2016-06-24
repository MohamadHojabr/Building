using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Buolding.Utility;

namespace DomainClasses.Models
{
    public class Brand : BaseEntity
    {
        #region Ctor

        /// <summary>
        ///     create one instance of <see cref="Brand" />
        /// </summary>
        public Brand()
        {
            BrandId = SequentialGuidGenerator.NewSequentialGuid();
        }

        #endregion

        #region Properties

        [Key]
        public Guid BrandId { get; set; }

        public string Name { get; set; }
        public string Describtion { get; set; }

        #endregion

        #region NavigationProperties

        public virtual ICollection<Product> Products { get; set; }

        #endregion
    }
}
