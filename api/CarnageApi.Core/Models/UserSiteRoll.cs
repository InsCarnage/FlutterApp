using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CarnageApi.Core.DTOs;
using System.Linq;

namespace CarnageApi.Core.Models
{
    public class UserSiteRoll : BaseModel
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

        public virtual User User { get; set;}
        public virtual Site Site { get; set; }
        public virtual Permission Permission { get; set; }

        public UserSiteRollDTO UserSiteRollDTO => new UserSiteRollDTO 
        {
            Id = this.Id,
            UserId = this.UserId,
            SiteId = this.SiteId,
            PermissionId = this.PermissionId,
            IsActive = this.IsActive,
            CreatedOn = this.CreatedOn,
            CreatedBy = this.CreatedBy,
            ModifiedBy = this.ModifiedBy,
            ModifiedOn = this.ModifiedOn

        };

    }
}
