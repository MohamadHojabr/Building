using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;

namespace ServiceLayer.IService
{
    public interface IAddress:IDisposable
    {
        void AddOrUpdate(Address address);
        void Delete(Address address);
        Address Find(int id);
        IList<Address> GetAll();
    }
}
