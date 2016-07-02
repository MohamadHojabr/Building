using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;

namespace ServiceLayer.IService
{
    public interface ICompanyProfile
    {
        void AddOrUpdate(CompanyProfile companyProfile);
        void Delete(CompanyProfile companyProfile);
        CompanyProfile Find(int id);
        IList<CompanyProfile> GetAll();
    }
}
