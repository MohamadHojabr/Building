using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;
using ServiceLayer.IService;

namespace ServiceLayer.EfService
{
    public class EfProduct:IProduct
    {
        public void AddOrUpdate(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
