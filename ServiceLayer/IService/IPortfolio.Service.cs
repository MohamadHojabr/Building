using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;

namespace ServiceLayer.IService
{
    public interface IPortfolio:IDisposable
    {
        void AddOrUpdate(Portfolio portfolio);
        void Delete(Portfolio portfolio);
        Portfolio Find(int id);
        IList<Portfolio> GetAll();

    }
}
