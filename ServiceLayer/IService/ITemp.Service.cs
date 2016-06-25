using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;

namespace ServiceLayer.IService
{
    /// <summary>
    /// سرویس مربوط به 
    /// </summary>

    public interface ITemp:IDisposable
    {
        void AddOrUpdate(Temp temp);
        void Delete(Temp temp);
        Temp Find(int id);
        IList<Temp> GetAll();

    }
}
