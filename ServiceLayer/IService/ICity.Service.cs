using System.Collections.Generic;
using System.Web.Mvc;

namespace ServiceLayer.IService
{
    /// <summary>
    /// نشان دهنده الزامات ارائه دهنده سرویس شهر
    /// </summary>
    public interface ICity
    {
        /// <summary>
        /// نمایش لیست شهر ها به صورت آبشاری 
        /// </summary>
        /// <param name="state">نام استان</param>
        /// <param name="selected">انتخاب شده</param>
        /// <param name="path"></param>
        /// <returns></returns>
        IList<SelectListItem> GetAsSelectListByStateNameAsync(string state, string selected, string path);

    }
}
