using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarnageApi.Core;
using CarnageApi.Core.DTOs;
using CarnageApi.Core.Models;

namespace CarnageApi.Core.Interfaces
{
    public interface IAuthService
    {
        UserAuthDTO signIn(UserAuthDTO user);
        List<User> listUsers();
        List<Site> ListSite();
        List<Permission> ListPermission();
        List<UserSiteRollDTO> ListUserSiteRoll();
    }
}
