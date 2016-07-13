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
    public class EfProfile:IProfile
    {
        IUnitOfWork _ouw;
        IDbSet<Profile> _profiles;
        private IUsersManager UsersManager;

        public EfProfile(IUnitOfWork ouw, IUsersManager usersManager)
        {
            _ouw = ouw;
            UsersManager = usersManager;
            _profiles = _ouw.Set<Profile>();
        }

        public void AddOrUpdate(Profile profile)
        {
            if (profile == null)
            {
                throw new ArgumentNullException(nameof(profile));
            }
            _profiles.AddOrUpdate(profile);
        }

        public void Delete(Profile profile)
        {
            _profiles.Remove(profile);
        }

        public Profile Find(int id)
        {
            var unit = _profiles.Find(id);
            return unit;
        }

        public IList<Profile> GetAll()
        {
            var list = _profiles.Include(p=>p.RelatedUser).ToList();
            var relatedUser = UsersManager.GetAllUsers();
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
