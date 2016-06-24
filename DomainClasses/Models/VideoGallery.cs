using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buolding.Utility;

namespace DomainClasses.Models
{
    public class VideoGallery:BaseEntity
    {
        #region Ctor
        /// <summary>
        /// create one instance of <see cref="VideoGallery"/>
        /// </summary>

        public VideoGallery()
        {
            VideoGalleryId = SequentialGuidGenerator.NewSequentialGuid();
        }

        #endregion

        #region Properties
        [Key]
        public Guid VideoGalleryId { get; set; }
        public string Name { get; set; }
        public string Describtion { get; set; }
        public string ThumbnailImage { get; set; }
        public int Rate { get; set; }
        #endregion

        #region NavigationProperties
        public Guid PersonalProfileId { get; set; }
        public virtual PersonalProfile PersonalProfile { get; set; }
        public Guid CompanyProfileId { get; set; }
        public virtual CompanyProfile CompanyProfile { get; set; }

        public ICollection<VideoGalleryFile> VideoGalleryFiles { get; set; } 
        #endregion

    }
}
