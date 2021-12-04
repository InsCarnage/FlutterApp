using System.Collections.Generic;
using CarnageApi.Core.Interfaces;

namespace CarnageApi.Core.Services
{
	public class AuthInfo : IAuthInfo
    {
        public int UserId { get; set; }
        public string DisplayName { get; set; }
        public List<string> Permissions { get; set; }
        public int SiteId { get; set; }
    }
}