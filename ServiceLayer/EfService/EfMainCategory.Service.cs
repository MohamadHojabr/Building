﻿using System;
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
            if (HasChild(mainCategory.MainCategoryId))
            {
                foreach (var child in mainCategory.Children)
                {
                    child.MarkAsDelete = true;
                    //child.ParentId = null;
                    _categories.AddOrUpdate(child);
                }
            }
            mainCategory.MarkAsDelete = true;
            //mainCategory.ParentId = null;
        }

        public MainCategory Find(Guid id)
        {
            var unit = _categories.Find(id);
            return unit;
        }

        public IList<MainCategory> GetAll()
        {
            var list = _categories.ToList();
            return list;
        }

        public bool HasChild(Guid id)
        {
            var model = _categories.Find(id);
            if (model.Children.Any())
            {
                return true;
            }
            return false;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _ouw.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
