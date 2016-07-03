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
    public class EfPersonalProfile:IPersonalProfile
    {
        IUnitOfWork _ouw;
        IDbSet<PersonalProfile> _personalProfiles;

        public EfPersonalProfile(IUnitOfWork ouw)
        {
            _ouw = ouw;
            _personalProfiles = _ouw.Set<PersonalProfile>();
        }

        public void AddOrUpdate(PersonalProfile personalProfile)
        {
            if (personalProfile == null)
            {
                throw new ArgumentNullException(nameof(personalProfile));
            }
            _personalProfiles.AddOrUpdate(personalProfile);
        }

        public void Delete(PersonalProfile personalProfile)
        {
            _personalProfiles.Remove(personalProfile);
        }

        public PersonalProfile Find(int id)
        {
            var unit = _personalProfiles.Find(id);
            return unit;
        }

        public IList<PersonalProfile> GetAll()
        {
            var list = _personalProfiles.ToList();
            return list;
        }
    }
}
