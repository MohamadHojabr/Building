using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;
using ServiceLayer.IService;

namespace ServiceLayer.EfService
{
    public class EfUseLocation:IUseLocation
    {
        public void AddOrUpdate(UseLocation useLocation)
        {
            throw new NotImplementedException();
        }

        public void Delete(UseLocation useLocation)
        {
            throw new NotImplementedException();
        }

        public UseLocation Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<UseLocation> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
