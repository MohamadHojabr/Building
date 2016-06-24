using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Buolding.Utility;

namespace DomainClasses.Models
{
    public class Portfolio : BaseEntity
    {
        #region Ctor

        /// <summary>
        ///     create one instance of <see cref="Portfolio" />
        /// </summary>
        public Portfolio()
        {
            PortfolioId = SequentialGuidGenerator.NewSequentialGuid();
        }

        #endregion

        #region Properties

        [Key]
        public Guid PortfolioId { get; set; }

        public string Name { get; set; }
        public string ThumbnailImage { get; set; }
        public string Describtion { get; set; }
        public int Rate { get; set; }

        #endregion

        #region NavigationProperties

        public Guid PersonalProfileId { get; set; }
        public virtual PersonalProfile PersonalProfile { get; set; }
        public Guid CompanyProfileId { get; set; }
        public virtual CompanyProfile CompanyProfile { get; set; }
        public virtual ICollection<PortfolioFile> PortfolioFiles { get; set; } 

        #endregion
    }
}
