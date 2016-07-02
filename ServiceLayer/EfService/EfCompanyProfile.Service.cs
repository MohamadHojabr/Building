using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;
using ServiceLayer.IService;

namespace ServiceLayer.EfService
{
    public class EfCompanyProfile:ICompanyProfile
    {
        public void AddOrUpdate(CompanyProfile companyProfile)
        {
            throw new NotImplementedException();
        }

        public void Delete(CompanyProfile companyProfile)
        {
            throw new NotImplementedException();
        }

        public CompanyProfile Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyProfile> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
