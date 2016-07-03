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
    public class EfVideoGallery:IVideoGallery
    {
        IUnitOfWork _ouw;
        IDbSet<VideoGallery> _videoGalleries;

        public EfVideoGallery(IUnitOfWork ouw)
        {
            _ouw = ouw;
            _videoGalleries = _ouw.Set<VideoGallery>();
        }

        public void AddOrUpdate(VideoGallery videoGallery)
        {
            if (videoGallery == null)
            {
                throw new ArgumentNullException(nameof(videoGallery));
            }
            _videoGalleries.AddOrUpdate(videoGallery);
        }

        public void Delete(VideoGallery videoGallery)
        {
            _videoGalleries.Remove(videoGallery);
        }

        public VideoGallery Find(int id)
        {
            var unit = _videoGalleries.Find(id);
            return unit;
        }

        public IList<VideoGallery> GetAll()
        {
            var list = _videoGalleries.ToList();
            return list;
        }
    }
}
