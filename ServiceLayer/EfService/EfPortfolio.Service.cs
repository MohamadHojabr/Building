using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;
using ServiceLayer.IService;

namespace ServiceLayer.EfService
{
    public class EfPortfolio:IPortfolio
    {
        public void AddOrUpdate(Portfolio portfolio)
        {
            throw new NotImplementedException();
        }

        public void Delete(Portfolio portfolio)
        {
            throw new NotImplementedException();
        }

        public Portfolio Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Portfolio> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
