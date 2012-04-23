using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.DirectoryServices;
using FundDataMaintenaceBusiness.Interfaces;
using FundDataMaintenaceBusiness.Models;

namespace FundDataMaintenaceBusiness.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IActiveDirectorySettings _adSettings;

        public AuthenticationService(IActiveDirectorySettings activeDirectorySettings)
        {
            _adSettings = activeDirectorySettings;
        }

        public bool PasswordMatches(UserSM user, string password)
        {
            var authenticated = false;
            var domainAndUsername = _adSettings.DomainName + "\\" + user.Username;
            var entry = new DirectoryEntry("LDAP://" + _adSettings.LdapPath, domainAndUsername, password);
            try
            {
                var bindToNativeObjectToForceAuthentication = entry.NativeObject;
                authenticated = true;
            }
            catch (COMException)
            {
            }
            return authenticated;
        }

    }
}
