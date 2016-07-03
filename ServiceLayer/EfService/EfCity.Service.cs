using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using ServiceLayer.IService;
using ServiceLayer.Settings;

namespace ServiceLayer.EfService
{
    public class EfCity : ICity
    {
        #region Fields

        private readonly HttpContextBase _httpContextBase;

        #endregion

        #region Ctor

        public EfCity(HttpContextBase httpContextBase)
        {
            _httpContextBase = httpContextBase;
        }
        #endregion
        public IList<SelectListItem> GetAsSelectListByStateNameAsync(string state, string selected, string path)
        {
            var lst = from e in XDocument.Load(_httpContextBase.Server.MapPath(path)).Root.Elements(OwnConstants.State) where e.Attribute(OwnConstants.Name).Value == state select e;
            var cities = lst.SelectMany(a => a.Elements(OwnConstants.City));
            return
                cities.OrderBy(a => a.Value).Select(a => new SelectListItem { Value = a.Value, Text = a.Value, Selected = a.Value == selected })
                    .ToList();
        }

    }
}
