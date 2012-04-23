using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundDataMaintenaceBusiness.Interfaces
{
    public interface IActiveDirectorySettings
    {
        string DomainName { get; }
        string LdapPath { get; }
    }
}
