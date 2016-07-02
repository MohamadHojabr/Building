using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;
using ServiceLayer.IService;

namespace ServiceLayer.EfService
{
    public class EfImageGallery:IImageGallery
    {
        public void AddOrUpdate(ImageGallery imageGallery)
        {
            throw new NotImplementedException();
        }

        public void Delete(ImageGallery imageGallery)
        {
            throw new NotImplementedException();
        }

        public ImageGallery Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ImageGallery> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
