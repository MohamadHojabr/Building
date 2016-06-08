using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using DomainClasses.Models;
using ServiceLayer.IService;

namespace ServiceLayer.EfService
{
    public class EfCategoryService : ICategoryService
    {
        IUnitOfWork _ouw;
        readonly IDbSet<Category> _category;

        public EfCategoryService(IUnitOfWork ouw)
        {
            _ouw = ouw;
            _category = _ouw.Set<Category>();
        }

        public IEnumerable<Category> GetAllCategory()
        {
            var list = _category;
            return list;
        }
    }
}
