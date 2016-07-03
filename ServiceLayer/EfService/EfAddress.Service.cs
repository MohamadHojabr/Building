using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using DomainClasses.Models;
using ServiceLayer.IService;

namespace ServiceLayer.EfService
{
    public class EfAddress : IAddress
    {
        IUnitOfWork _ouw;
        IDbSet<Address> _addresses;

        public EfAddress(IUnitOfWork ouw)
        {
            _ouw = ouw;
            _addresses = _ouw.Set<Address>();
        }


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
