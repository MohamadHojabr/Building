using System;
using System.Collections.Generic;
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

        public string CompanyName { get; set; }
        public string RegistrationNumber { get; set; }
        public string Management { get; set; }
        public string FieldOfActivity { get; set; }
        public string ProfilePicture { get; set; }
        public string SocialGooglePlus { get; set; }
        public string SocialFacebok { get; set; }
        public string SocialTwiter { get; set; }
        public string SocialTelegram { get; set; }
        public string Socialinstagram { get; set; }

        #endregion

        #region NavigationProperties

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public Guid MainCategoryId { get; set; }
        public virtual MainCategory MainCategory { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Portfolio> Portfolios { get; set; }

        #endregion
    }
}
