using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CarnageApi.Core.DTOs;
using System.Linq;
using CarnageApi.Core.Models;

namespace CarnageApi.Core.DTOs
{
    public class UserSiteRollDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SiteId { get; set; }
        public int PermissionId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

    }
}
