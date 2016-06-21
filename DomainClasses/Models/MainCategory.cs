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
    public class MainCategory
    {

        #region Ctor
        /// <summary>
        /// create one instance of <see cref="MainCategory"/>
        /// </summary>
        
        public MainCategory()
        {
            Id = SequentialGuidGenerator.NewSequentialGuid();
        }

        #endregion

        #region Properties
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Describtion { get; set; }
        [NotMapped]
        public bool Checked { get; set; }

        #endregion

        #region NavigationProperties
        public int? ParentId { get; set; }
        public virtual MainCategory Parent { get; set; }
        public virtual ICollection<MainCategory> Children { get; set; }

        public virtual ICollection<PersonalProfile> Profile { get; set; }

        #endregion
    }
}
