using System.Collections.Generic;

namespace CarnageApi.Core.Interfaces
{
    public interface IAuthInfo
    {
        int UserId { get; set; }
        string DisplayName { get; set; }
        List<string> Permissions { get; set; }
        int SiteId { get; set; }
    }
}