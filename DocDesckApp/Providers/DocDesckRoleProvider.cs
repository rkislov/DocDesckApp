﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Helpers;
using System.Web.WebPages;
using Microsoft.Internal.Web.Utils;
using DocDesckApp.Models;

namespace DocDesckApp.Providers
{
    public class DocDesckRoleProvider : RoleProvider
    {
        public override string[] GetRolesForUser(string login)
        {
            string[] role = new string[] { };
            using (DocDeskContext _db = new DocDeskContext())
            {
                try
                {
                    //получаем пользователя
                    User user = (from u in _db.Users
                                 where u.Login == login
                                 select u).FirstOrDefault();

                    if (user !=null)
                    {
                        Role userRole = _db.Roles.Find(user.RoleId);

                        if (userRole !=null)
                        {
                            role = new string[] { userRole.Name };
                        }
                    }
                }
                catch
                {
                    role = new string[] { };
                }
            }
            return role;
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            bool outputResult = false;
            //находим пользователя
            using (DocDeskContext _db = new DocDeskContext())
            {
                try
                {
                    User user = (from u in _db.Users
                                 where u.Login == username
                                 select u).FirstOrDefault();
                    if(user !=null)
                    {
                        //получаем роль
                        Role userRole = _db.Roles.Find(user.RoleId);
                        
                        // Сравнение
                        if(userRole !=null &&  userRole.Name == roleName )
                        {
                            outputResult = true;
                        }
                    }
                }
                catch
                {
                    outputResult = false;
                }
                
            }
            return outputResult;
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }
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
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
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