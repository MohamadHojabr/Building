using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ServiceLayer.IService
{
    /// <summary>
    /// نشان دهنده الزامات ارائه دهنده سرویس استان
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// واکشی لیست استان ها برای نمایش در لیست آبشاری
        /// </summary>
        /// <returns></returns>
        IList<SelectListItem> GetAsSelectListItemAsync(string selected, string path);
    }

}
