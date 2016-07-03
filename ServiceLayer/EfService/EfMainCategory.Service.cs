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
    public class EfMainCategory:IMainCategory
    {
        IUnitOfWork _ouw;
        IDbSet<MainCategory> _categories;

        public EfMainCategory(IUnitOfWork ouw)
        {
            _ouw = ouw;
            _categories = _ouw.Set<MainCategory>();
        }

        public void AddOrUpdate(MainCategory mainCategory)
        {
            if (mainCategory == null)
            {
                throw new ArgumentNullException(nameof(mainCategory));
            }
            _categories.AddOrUpdate(mainCategory);
        }

        public void Delete(MainCategory mainCategory)
        {
            _categories.Remove(mainCategory);
        }

        public MainCategory Find(int id)
        {
            var unit = _categories.Find(id);
            return unit;
        }

        public IList<MainCategory> GetAll()
        {
            var list = _categories.ToList();
            return list;
        }
    }
}
