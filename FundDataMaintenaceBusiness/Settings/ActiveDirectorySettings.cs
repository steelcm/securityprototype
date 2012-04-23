using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundDataMaintenaceBusiness.Interfaces;

namespace FundDataMaintenaceBusiness.Settings
{
    public class ActiveDirectorySettings : IActiveDirectorySettings
    {
        #region Implementation of IActiveDirectorySettings

        public string DomainName
        {
            get { return "CGUSER"; }
        }

        public string LdapPath
        {
            get { return "DC=cguser,DC=capgroup,DC=com"; }
        }

        #endregion
    }
}
