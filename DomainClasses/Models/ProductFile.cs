using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buolding.Utility;

namespace DomainClasses.Models
{
    public class ProductFile
    {
        #region Ctor
        /// <summary>
        /// create one instance of <see cref="ProductFile"/>
        /// </summary>

        public ProductFile()
        {
            ProductFileId = SequentialGuidGenerator.NewSequentialGuid();
        }

        #endregion

        #region Properties
        [Key]
        public Guid ProductFileId { get; set; }

        #endregion

        #region NavigationProperties
        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; }
        #endregion

    }
}
