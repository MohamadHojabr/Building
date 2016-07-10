using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;

namespace ServiceLayer.IService
{
    public interface IContact:IDisposable
    {
        void AddOrUpdate(Contact contact);
        void Delete(Contact contact);
        Contact Find(int id);
        IList<Contact> GetAll();

    }
}
