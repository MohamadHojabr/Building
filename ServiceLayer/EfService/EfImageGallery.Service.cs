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
    public class EfImageGallery:IImageGallery
    {
        IUnitOfWork _ouw;
        IDbSet<ImageGallery> _imageGalleries;

        public EfImageGallery(IUnitOfWork ouw)
        {
            _ouw = ouw;
            _imageGalleries = _ouw.Set<ImageGallery>();
        }

        public void AddOrUpdate(ImageGallery imageGallery)
        {
            if (imageGallery == null)
            {
                throw new ArgumentNullException(nameof(imageGallery));
            }
            _imageGalleries.AddOrUpdate(imageGallery);
        }

        public void Delete(ImageGallery imageGallery)
        {
            _imageGalleries.Remove(imageGallery);
        }

        public ImageGallery Find(int id)
        {
            var unit = _imageGalleries.Find(id);
            return unit;
        }

        public IList<ImageGallery> GetAll()
        {
            var list = _imageGalleries.ToList();
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
