using System;
using System.Collections.Generic;
using System.Text;
using CarnageApi.Core.Models;

namespace CarnageApi.Core.DTOs
{
    public class UserAuthDTO
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string ApiToken { get; set; }
        public bool IsAdmin { get; set; }
        public List<UserSiteRollDTO> SitePermissions { get; set; }
        public bool ValidUser { get; set; }
    }
}
