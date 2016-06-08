using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;

namespace ServiceLayer.IService
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategory();
    }
}
