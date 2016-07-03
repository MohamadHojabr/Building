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
    public class EfArticle:IArticle
    {
        IUnitOfWork _ouw;
        IDbSet<Article> _articles;

        public EfArticle(IUnitOfWork ouw)
        {
            _ouw = ouw;
            _articles = _ouw.Set<Article>();
        }

        public void AddOrUpdate(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }
            _articles.AddOrUpdate(article);
        }

        public void Delete(Article article)
        {
            _articles.Remove(article);
        }

        public Article Find(int id)
        {
            var unit = _articles.Find(id);
            return unit;
        }

        public IList<Article> GetAll()
        {
            var list = _articles.ToList();
            return list;
        }
    }
}
