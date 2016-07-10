using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Building.Common.Helpers;

namespace DomainClasses
{
    public abstract class BaseEntity
    {
        public DateTime? CreatedOn { set; get; }
        [DisplayName("درج توسط")]

        public string CreatedBy { set; get; }
        [DisplayName("تاریخ درج")]
        public string CreatedOnPersian => CreatedOn.HasValue ? ((DateTime)CreatedOn).ToPeString("yyyy/MM/dd  HH:mm:ss") : string.Empty;

        [DisplayName("تاریخ ویرایش")]

        public string ModifiedOnPersian => ModifiedOn.HasValue ? ((DateTime)ModifiedOn).ToPeString("yyyy/MM/dd  HH:mm:ss") : string.Empty;

        public DateTime? ModifiedOn { set; get; }
        [DisplayName("ویرایش توسط")]

        public string ModifiedBy { set; get; }
    }
}
