using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Forum.Models
{
    public class UsersRoleProvider : RoleProvider

    {
        private Entities entity = new Entities();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            var userRole = (from a in entity.Roles
                           join b in entity.UserRoles
                           on a.roleId equals b.roleid
                           join c in entity.UserRegistrations
                           on b.userid equals c.userId
                           where c.userName == username
                           select a.roleName).ToArray();                       
                                
                return userRole;        
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var inRole = (from a in entity.UserLogins
                          join b in entity.UserRoles
                          on a.userId equals b.userid
                          join c in entity.Roles
                          on b.roleid equals c.roleId
                          where a.userName.ToLower() == username && c.roleName.ToLower() == roleName
                          select a.userId)
                         .Any(); 
                
                return inRole;
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