using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Building.Common.Helpers;

namespace DomainClasses
{
    public abstract class BaseEntity
    {
        public DateTime? CreatedOn { set; get; }

        public string CreatedBy { set; get; }

        public string CreatedOnPersian => CreatedOn.HasValue ? ((DateTime)CreatedOn).ToPeString("yyyy/MM/dd  HH:mm:ss") : string.Empty;


        public string ModifiedOnPersian => ModifiedOn.HasValue ? ((DateTime)ModifiedOn).ToPeString("yyyy/MM/dd  HH:mm:ss") : string.Empty;

        public DateTime? ModifiedOn { set; get; }

        public string ModifiedBy { set; get; }
    }
}
