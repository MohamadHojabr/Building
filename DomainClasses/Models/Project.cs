using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buolding.Utility;

namespace DomainClasses.Models
{
    public class Project
    {
        #region Ctor
        /// <summary>
        /// create one instance of <see cref="Project"/>
        /// </summary>

        public Project()
        {
            ProjectId = SequentialGuidGenerator.NewSequentialGuid();
        }

        #endregion

        #region Properties
        [Key]
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string ThumbnailImage { get; set; }
        public string Describtion { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
        public string OperationPlace { get; set; }
        public string Employer { get; set; }
        public string Testimonial { get; set; }

        #endregion

        #region NavigationProperties
        public Guid PersonalProfileId { get; set; }
        public virtual PersonalProfile PersonalProfile { get; set; }
        public Guid CompanyProfileId { get; set; }
        public virtual CompanyProfile CompanyProfile { get; set; }

        public ICollection<ProductFile> ProductFiles { get; set; }
        #endregion

    }
}
