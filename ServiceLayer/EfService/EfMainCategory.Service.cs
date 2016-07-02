using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;
using ServiceLayer.IService;

namespace ServiceLayer.EfService
{
    public class EfMainCategory:IMainCategory
    {
        public void AddOrUpdate(MainCategory mainCategory)
        {
            throw new NotImplementedException();
        }

        public void Delete(MainCategory mainCategory)
        {
            throw new NotImplementedException();
        }

        public MainCategory Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<MainCategory> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
