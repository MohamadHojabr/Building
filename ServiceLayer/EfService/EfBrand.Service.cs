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
    public class EfBrand:IBrand
    {
        IUnitOfWork _ouw;
        IDbSet<Brand> _brands;

        public EfBrand(IUnitOfWork ouw)
        {
            _ouw = ouw;
            _brands = _ouw.Set<Brand>();
        }

        public void AddOrUpdate(Brand brand)
        {
            if (brand == null)
            {
                throw new ArgumentNullException(nameof(brand));
            }
            _brands.AddOrUpdate(brand);
        }

        public void Delete(Brand brand)
        {
            _brands.Remove(brand);
        }

        public Brand Find(int id)
        {
            var unit = _brands.Find(id);
            return unit;
        }

        public IList<Brand> GetAll()
        {
            var list = _brands.ToList();
            return list;
        }
    }
}
