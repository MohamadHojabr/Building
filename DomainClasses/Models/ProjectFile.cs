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
    public class ProjectFile
    {
        #region Ctor
        /// <summary>
        /// create one instance of <see cref="ProjectFile"/>
        /// </summary>

        public ProjectFile()
        {
            ProjectFileId = SequentialGuidGenerator.NewSequentialGuid();
        }

        #endregion

        #region Properties
        [Key]
        public Guid ProjectFileId { get; set; }
        [MaxLength(1024)]
        public string FileName { get; set; }

        [MaxLength(1024)]
        public string NewFileName { get; set; }

        [MaxLength(256)]
        public string LinkUrl { get; set; }

        public int Size { get; set; }

        [MaxLength(1024)]
        public string Type { get; set; }

        [MaxLength(256)]
        public string Comment { get; set; }

        #endregion

        #region NavigationProperties
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }
        #endregion

        #region NotMapped Prorperties

        [NotMapped]
        public string Url => "/Uploads/Project/" + NewFileName;

        [NotMapped]
        public string ThumbnailUrl => "/Uploads/Project/" + "thumb$" + NewFileName;

        [NotMapped]
        public string DeleteUrl => "/Uploads/Project/Delete/" + NewFileName;

        [NotMapped]
        public bool EditMode { get; set; }

        [NotMapped]
        public bool MarkAsDeleted { get; set; }

        [NotMapped]
        public string Error { get; set; }

        #endregion
    }
}
