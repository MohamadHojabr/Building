using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using DomainClasses.Models;
using ServiceLayer.IService;

namespace ServiceLayer.EfService
{
    public class EfProduct:IProduct
    {
        IUnitOfWork _ouw;
        IDbSet<Product> _products;

        public EfProduct(IUnitOfWork ouw)
        {
            _ouw = ouw;
            _products = _ouw.Set<Product>();
        }


        public void AddOrUpdate(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _products.AddOrUpdate(product);
        }

        public void Delete(Product product)
        {
            _products.Remove(product);
        }

        public Product Find(int id)
        {
            var unit = _products.Find(id);
            return unit;
        }

        public IList<Product> GetAll()
        {
            var list = _products.ToList();
            return list;
        }
    }
}
