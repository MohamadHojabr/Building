using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;

namespace ServiceLayer.IService
{
    public interface IVideoGallery
    {
        void AddOrUpdate(VideoGallery videoGallery);
        void Delete(VideoGallery videoGallery);
        VideoGallery Find(int id);
        IList<VideoGallery> GetAll();

    }
}
