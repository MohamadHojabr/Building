using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;
using ServiceLayer.IService;

namespace ServiceLayer.EfService
{
    public class EfPersonalProfile:IPersonalProfile
    {
        public void AddOrUpdate(PersonalProfile personalProfile)
        {
            throw new NotImplementedException();
        }

        public void Delete(PersonalProfile personalProfile)
        {
            throw new NotImplementedException();
        }

        public PersonalProfile Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<PersonalProfile> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
