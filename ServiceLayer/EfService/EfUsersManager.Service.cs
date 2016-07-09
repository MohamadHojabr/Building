using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Context;
using DomainClasses.Models;
using ServiceLayer.IService;

namespace ServiceLayer.EfService
{
    public class EfUsersManager:IUsersManager
    {
        IUnitOfWork _ouw;
        IDbSet<ApplicationUser> _users;

        public EfUsersManager(IUnitOfWork ouw)
        {
            _ouw = ouw;
            _users = _ouw.Set<ApplicationUser>();
        }

        public IList<ApplicationUser> GetAllUsers()
        {
            var list = _users.ToList();
            return list;
        }

        public ApplicationUser FindUserById(string id)
        {
            var unit = _users.Find(id);
            return unit;
        }
    }
}
