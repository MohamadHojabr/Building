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
    public class EfCompanyProfile:ICompanyProfile
    {
        IUnitOfWork _ouw;
        IDbSet<CompanyProfile> _companyProfiles;

        public EfCompanyProfile(IUnitOfWork ouw)
        {
            _ouw = ouw;
            _companyProfiles = _ouw.Set<CompanyProfile>();
        }

        public void AddOrUpdate(CompanyProfile companyProfile)
        {
            if (companyProfile == null)
            {
                throw new ArgumentNullException(nameof(companyProfile));
            }
            _companyProfiles.AddOrUpdate(companyProfile);
        }

        public void Delete(CompanyProfile companyProfile)
        {
            _companyProfiles.Remove(companyProfile);
        }

        public CompanyProfile Find(int id)
        {
            var unit = _companyProfiles.Find(id);
            return unit;
        }

        public IList<CompanyProfile> GetAll()
        {
            var list = _companyProfiles.ToList();
            return list;
        }
    }
}
