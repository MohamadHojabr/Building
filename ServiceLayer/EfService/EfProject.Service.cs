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
    public class EfProject:IProject
    {
        IUnitOfWork _ouw;
        IDbSet<Project> _projects;

        public EfProject(IUnitOfWork ouw)
        {
            _ouw = ouw;
            _projects = _ouw.Set<Project>();
        }

        public void AddOrUpdate(Project project)
        {
            if (project == null)
            {
                throw new ArgumentNullException(nameof(project));
            }
            _projects.AddOrUpdate(project);
        }

        public void Delete(Project project)
        {
            _projects.Remove(project);
        }

        public Project Find(int id)
        {
            var unit = _projects.Find(id);
            return unit;
        }

        public IList<Project> GetAll()
        {
            var list = _projects.ToList();
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
