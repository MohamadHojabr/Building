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
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }
            _addresses.AddOrUpdate(address);
        }

        public void Delete(Address address)
        {
            _addresses.Remove(address);
        }

        public Address Find(int id)
        {
            var unit = _addresses.Find(id);
            return unit;
        }

        public IList<Address> GetAll()
        {
            var list = _addresses.ToList();
            return list;
        }
    }
}
