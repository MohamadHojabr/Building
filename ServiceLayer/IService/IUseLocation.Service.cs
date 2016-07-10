using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;

namespace ServiceLayer.IService
{
    public interface IUseLocation:IDisposable
    {
        void AddOrUpdate(UseLocation useLocation);
        void Delete(UseLocation useLocation);
        UseLocation Find(int id);
        IList<UseLocation> GetAll();

    }
}
