using Auction.Data;
using Auction.Data.Repository;
using Auction.Model.Models;
using Auction.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Auction.UI.Providers
{
    public class AuctionRoleProvider : RoleProvider
    {
        public IUserService UserService
            => (IUserService)DependencyResolver.Current.GetService(typeof(IUserService));
        public IRoleService RoleService
         => (IRoleService)DependencyResolver.Current.GetService(typeof(IRoleService));



        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            var role = new Role() { Name = roleName };
            RoleService.AddRole(role);
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            var roles = new List<string>();
            var r = RoleService.GetRoles();
            foreach (var s in r)
            {
                roles.Add(s.Name);
            }
            return roles.ToArray();
        }

        public override string[] GetRolesForUser(string email)
        {
            var roles = new List<string>();
            var user = UserService.GetUserByEmail(email);
            if (user != null)
            {
                var role = user.Roles;
                foreach(var r in role)
                {
                    roles.Add(r.Name);
                }
                   
            }
            return roles.ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string email, string roleName)
        {
            User user = UserService.GetUserByEmail(email);

            if (user == null) return false;
            //TODO: Менял. Если не опадет система роле,смотреть тут
            Role userRole = user.Roles.FirstOrDefault(r => r.Name == roleName);

            if (userRole != null)
            {
                return true;
            }

            return false;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}