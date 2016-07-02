using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;
using ServiceLayer.IService;

namespace ServiceLayer.EfService
{
    public class EfBrand:IBrand
    {
        public void AddOrUpdate(Brand brand)
        {
            throw new NotImplementedException();
        }

        public void Delete(Brand brand)
        {
            throw new NotImplementedException();
        }

        public Brand Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Brand> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
