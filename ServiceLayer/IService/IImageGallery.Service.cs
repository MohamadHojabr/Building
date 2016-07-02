using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;

namespace ServiceLayer.IService
{
    public interface IImageGallery
    {
        void AddOrUpdate(ImageGallery imageGallery);
        void Delete(ImageGallery imageGallery);
        ImageGallery Find(int id);
        IList<ImageGallery> GetAll();

    }
}
