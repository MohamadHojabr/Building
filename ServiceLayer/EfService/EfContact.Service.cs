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
    public class EfContact:IContact
    {
        IUnitOfWork _ouw;
        IDbSet<Contact> _contacts;

        public EfContact(IUnitOfWork ouw)
        {
            _ouw = ouw;
            _contacts = _ouw.Set<Contact>();
        }

        public void AddOrUpdate(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }
            _contacts.AddOrUpdate(contact);
        }

        public void Delete(Contact contact)
        {
            _contacts.Remove(contact);
        }

        public Contact Find(int id)
        {
            var unit = _contacts.Find(id);
            return unit;
        }

        public IList<Contact> GetAll()
        {
            var list = _contacts.ToList();
            return list;
        }
    }
}
