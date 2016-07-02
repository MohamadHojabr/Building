using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;

namespace ServiceLayer.IService
{
    public interface IProduct
    {
        void AddOrUpdate(Product product);
        void Delete(Product product);
        Product Find(int id);
        IList<Product> GetAll();

    }
}
