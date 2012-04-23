﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Security;
using FundDataMaintenanceData;
using FundDataMaintenanceRepository.Interfaces;
using System.DirectoryServices.AccountManagement;
using FundDataMaintenanceRepository.Repositories;
using Microsoft.Practices.ServiceLocation;

namespace FundDataMaintenaceBusiness.Providers
{
    class AuthenticationRoleProvider : RoleProvider
    {
        private readonly IReferenceRepository _referenceRepository;

        public AuthenticationRoleProvider()
        {
            this._referenceRepository = new ReferenceRepository();
        }

        public AuthenticationRoleProvider(IReferenceRepository referenceRepository)
        {
            this._referenceRepository = referenceRepository;
        }

        #region Overrides of RoleProvider

        public override bool IsUserInRole(string username, string roleName)
        {
            var adRoles = ADRolesByAppRole(roleName);
            var returnBool = false;
            using (var context = new PrincipalContext(ContextType.Domain))
            {
                using (var user = UserPrincipal.FindByIdentity(context, username))
                {
                    if (user != null)
                    {
                        returnBool = user.GetGroups().Any(g => adRoles.Contains(g.Name));
                    }
                }
            }
            return returnBool;
        }

        public override string[] GetRolesForUser(string username)
        {
            
            return this._referenceRepository.GetAll<SECURITY_GROUP_ROLE_TYPE>().Select(o => o.NAME).Distinct().ToList().Where(o => IsUserInRole(username, o)).ToArray();
            //var adRoles = ADRolesByUsername(username);
            //var securityGroups = this._referenceRepository.GetAll<SECURITY_GROUP>().Where(o => adRoles.Contains(o.NAME)).Join(this._referenceRepository.GetAll<SECURITY_GROUP_ROLE>().Where(r => r.ACTIVE_IND.Equals("Y")), o => o.SECURITY_GROUP_ID, r => r.SECURITY_GROUP_ID, (o, r) => r.SECURITY_GROUP_ROLE_TYPE_ID).Join(this._referenceRepository.GetAll<SECURITY_GROUP_ROLE_TYPE>(), o => o, t => t.SECURITY_GROUP_ROLE_TYPE_ID, (o, t) => t.NAME);
            //return securityGroups.ToArray();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        #endregion

        private List<string> ADRolesByAppRole(string appRole)
        {
            return this._referenceRepository.GetAll<SECURITY_GROUP_ROLE_TYPE>().Where(o => o.NAME.Equals(appRole)).Join(this._referenceRepository.GetAll<SECURITY_GROUP_ROLE>().Where(r => r.ACTIVE_IND.Equals("Y")), o => o.SECURITY_GROUP_ROLE_TYPE_ID, r => r.SECURITY_GROUP_ROLE_TYPE_ID, (o, r) => r.SECURITY_GROUP_ID).Join(this._referenceRepository.GetAll<SECURITY_GROUP>(), o => o, t => t.SECURITY_GROUP_ID, (o, t) => t.NAME).ToList();
        }

        private static List<string> ADRolesByUsername(string username)
        {
            var roleList = new List<string>();
            using (var context = new PrincipalContext(ContextType.Domain))
            {
                using (var user = UserPrincipal.FindByIdentity(context, username))
                {
                    if (user != null)
                    {
                        var ADgroups = user.GetGroups();
                        if (ADgroups.Count() > 0)
                        {
                            var i = 0;
                            var rs = new List<string>();
                            while (i < ADgroups.Count())
                            {
                                try
                                {
                                    var role = ADgroups.ElementAt(i);
                                    if (role != null && role.Name != null)
                                        rs.Add(role.Name.ToUpper());
                                }
                                catch (Exception e)
                                {

                                }
                                i++;
                            }
                            roleList = rs.ToList();
                        }
                    }
                }
            }
            return roleList;   
        }
    }
}
