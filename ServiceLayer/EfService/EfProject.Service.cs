using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Models;
using ServiceLayer.IService;

namespace ServiceLayer.EfService
{
    public class EfProject:IProject
    {
        public void AddOrUpdate(Project project)
        {
            throw new NotImplementedException();
        }

        public void Delete(Project project)
        {
            throw new NotImplementedException();
        }

        public Project Find(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Project> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
