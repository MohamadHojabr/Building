using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;

namespace ServiceLayer.IService
{
    public interface IMainCategory
    {
        void AddOrUpdate(MainCategory mainCategory);
        void Delete(MainCategory mainCategory);
        MainCategory Find(int id);
        IList<MainCategory> GetAll();

    }
}
