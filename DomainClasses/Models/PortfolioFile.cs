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
    public class PortfolioFile
    {
        #region Ctor
        /// <summary>
        /// create one instance of <see cref="PortfolioFile"/>
        /// </summary>

        public PortfolioFile()
        {
            PortfolioFileId = SequentialGuidGenerator.NewSequentialGuid();
        }

        #endregion

        #region Properties
        [Key]
        public Guid PortfolioFileId { get; set; }
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
        public Guid PortfolioId { get; set; }
        public virtual Portfolio Portfolio { get; set; }
        #endregion

        #region NotMapped Prorperties

        [NotMapped]
        public string Url => "/Uploads/Portfolio/" + NewFileName;

        [NotMapped]
        public string ThumbnailUrl => "/Uploads/Portfolio/" + "thumb$" + NewFileName;

        [NotMapped]
        public string DeleteUrl => "/Uploads/Portfolio/Delete/" + NewFileName;

        [NotMapped]
        public bool EditMode { get; set; }

        [NotMapped]
        public bool MarkAsDeleted { get; set; }

        [NotMapped]
        public string Error { get; set; }

        #endregion


    }
}
