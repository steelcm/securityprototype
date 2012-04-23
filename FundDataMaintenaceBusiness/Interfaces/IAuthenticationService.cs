using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FundDataMaintenaceBusiness.Models;

namespace FundDataMaintenaceBusiness.Interfaces
{
    public interface IAuthenticationService
    {
        bool PasswordMatches(UserSM user, string password);
    }
}
