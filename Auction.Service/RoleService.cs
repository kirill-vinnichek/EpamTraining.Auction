using Auction.Data.Infrastructure;
using Auction.Data.Repository;
using Auction.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Service
{
    public interface IRoleService
    {
        Role GetById(int id);
        Role GetRole(string name);
        void AddRole(Role role);
        IEnumerable<Role> GetRoles();
    }

    public class RoleService : IRoleService
    {
        IRoleRepository roleRepository;
        IUnitOfWork uof;
        public RoleService(IUnitOfWork uof,IRoleRepository roleRepository)
        {
            this.uof = uof;
            this.roleRepository = roleRepository;
        }


        public Role GetById(int id)
        {
            return roleRepository.GetById(id);
        }

        public void AddRole(Role role)
        {
            roleRepository.Add(role);
            Save();
        }

        public void Save()
        {
            uof.Commit();
        }

        public IEnumerable<Role> GetRoles()
        {
            return roleRepository.GetAll();
        }

        public Role GetRole(string name)
        {
            return roleRepository.Get(r => r.Name == name);
        }
    }
}
