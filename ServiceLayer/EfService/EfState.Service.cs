using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Building.Common.Extentions;
using ServiceLayer.IService;
using ServiceLayer.Settings;

namespace ServiceLayer.EfService
{
    public class EfState:IState
    {
        #region Fields

        private readonly HttpContextBase _httpContextBase;

        #endregion

        #region Ctor

        public EfState(HttpContextBase httpContextBase)
        {
            _httpContextBase = httpContextBase;
        }
        #endregion
        public IList<SelectListItem> GetAsSelectListItemAsync(string selected, string path)
        {
            var lst = from e in XDocument.Load(_httpContextBase.Server.MapPath(path)).Root.Elements(OwnConstants.State) select e;
            var states = lst.Select(a => a.Attribute(OwnConstants.Name).Value);
            return
                states.OrderBy(a => a).Select(a => new SelectListItem { Value = a, Text = a, Selected = selected.HasValue() && a == selected })
                    .ToList();

        }

    }
}
