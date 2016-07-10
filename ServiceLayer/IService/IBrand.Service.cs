using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;

namespace ServiceLayer.IService
{
    public interface IBrand:IDisposable
    {
        void AddOrUpdate(Brand brand);
        void Delete(Brand brand);
        Brand Find(int id);
        IList<Brand> GetAll();

    }
}
