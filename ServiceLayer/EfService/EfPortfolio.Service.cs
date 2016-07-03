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
    public class EfPortfolio:IPortfolio
    {
        IUnitOfWork _ouw;
        IDbSet<Portfolio> _portfolios;

        public EfPortfolio(IUnitOfWork ouw)
        {
            _ouw = ouw;
            _portfolios = _ouw.Set<Portfolio>();
        }

        public void AddOrUpdate(Portfolio portfolio)
        {
            if (portfolio == null)
            {
                throw new ArgumentNullException(nameof(portfolio));
            }
            _portfolios.AddOrUpdate(portfolio);
        }

        public void Delete(Portfolio portfolio)
        {
            _portfolios.Remove(portfolio);
        }

        public Portfolio Find(int id)
        {
            var unit = _portfolios.Find(id);
            return unit;
        }

        public IList<Portfolio> GetAll()
        {
            var list = _portfolios.ToList();
            return list;
        }
    }
}
