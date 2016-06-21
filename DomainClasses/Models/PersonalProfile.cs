using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buolding.Utility;

namespace DomainClasses.Models
{
    public class PersonalProfile
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
        public string Name { get; set; }
        public string LastName { get; set; }
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
        #endregion
    }
}
