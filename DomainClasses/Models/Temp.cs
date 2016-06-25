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
    public class Temp
    {
        #region Ctor
        /// <summary>
        /// create one instance of <see cref="Temp"/>
        /// </summary>

        public Temp()
        {
            TempId = SequentialGuidGenerator.NewSequentialGuid();
        }

        #endregion

        #region Properties
        [Key]
        public Guid TempId { get; set; }

        #endregion

        #region NavigationProperties

        #endregion

    }
}
