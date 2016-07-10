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
    public class EfUseLocation:IUseLocation
    {

        IUnitOfWork _ouw;
        IDbSet<UseLocation> _useLocations;

        public EfUseLocation(IUnitOfWork ouw)
        {
            _ouw = ouw;
            _useLocations = _ouw.Set<UseLocation>();
        }

        public void AddOrUpdate(UseLocation useLocation)
        {
            if (useLocation == null)
            {
                throw new ArgumentNullException(nameof(useLocation));
            }
            _useLocations.AddOrUpdate(useLocation);
        }

        public void Delete(UseLocation useLocation)
        {
            _useLocations.Remove(useLocation);
        }

        public UseLocation Find(int id)
        {
            var unit = _useLocations.Find(id);
            return unit;
        }

        public IList<UseLocation> GetAll()
        {
            var list = _useLocations.ToList();
            return list;
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
