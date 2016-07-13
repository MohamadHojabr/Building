using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building.ViewModels.Account
{
    public class UploadFileViewModel
    {
        public string FileName { get; set; }

        [MaxLength(1024)]
        public string NewFileName { get; set; }

        [MaxLength(256)]
        public string LinkUrl { get; set; }

        public int Size { get; set; }

        [MaxLength(1024)]
        public string Type { get; set; }

    }
}
