using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;
using ServiceLayer.IService;

namespace ServiceLayer.EfService
{
    public class EfContact:IContact
    {
        public void AddOrUpdate(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void Delete(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Contact Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Contact> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
