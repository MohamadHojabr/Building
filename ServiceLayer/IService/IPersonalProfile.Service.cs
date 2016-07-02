using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;

namespace ServiceLayer.IService
{
    public interface IPersonalProfile
    {
        void AddOrUpdate(PersonalProfile personalProfile);
        void Delete(PersonalProfile personalProfile);
        PersonalProfile Find(int id);
        IList<PersonalProfile> GetAll();

    }
}
