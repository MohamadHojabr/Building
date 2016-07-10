using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;

namespace ServiceLayer.IService
{
    /// <summary>
    /// سرویس مربوط به پروفایل ها 
    /// </summary>

    public interface IProfile : IDisposable
    {
        void AddOrUpdate(Profile Profile);
        void Delete(Profile Profile);
        Profile Find(int id);
        IList<Profile> GetAll();

    }
}
