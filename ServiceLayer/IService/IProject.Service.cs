using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;

namespace ServiceLayer.IService
{
    public interface IProject:IDisposable
    {
        void AddOrUpdate(Project project);
        void Delete(Project project);
        Project Find(int id);
        IList<Project> GetAll();

    }
}
