﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;
using ServiceLayer.IService;

namespace ServiceLayer.EfService
{
    public class EfArticle:IArticle
    {
        public void AddOrUpdate(Article article)
        {
            throw new NotImplementedException();
        }

        public void Delete(Article article)
        {
            throw new NotImplementedException();
        }

        public Article Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Article> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
