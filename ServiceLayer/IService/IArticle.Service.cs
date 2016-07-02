using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;

namespace ServiceLayer.IService
{
    public interface IArticle
    {
        void AddOrUpdate(Article article);
        void Delete(Article article);
        Article Find(int id);
        IList<Article> GetAll();

    }
}
