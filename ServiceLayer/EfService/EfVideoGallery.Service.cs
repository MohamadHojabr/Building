using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;
using ServiceLayer.IService;

namespace ServiceLayer.EfService
{
    public class EfVideoGallery:IVideoGallery
    {
        public void AddOrUpdate(VideoGallery videoGallery)
        {
            throw new NotImplementedException();
        }

        public void Delete(VideoGallery videoGallery)
        {
            throw new NotImplementedException();
        }

        public VideoGallery Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<VideoGallery> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
