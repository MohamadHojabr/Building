using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;
using ServiceLayer.IService;

namespace ServiceLayer.EfService
{
    public class EfAddress : IAddress
    {
        public void AddOrUpdate(Address address)
        {
            throw new NotImplementedException();
        }

        public void Delete(Address address)
        {
            throw new NotImplementedException();
        }

        public Address Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Address> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
