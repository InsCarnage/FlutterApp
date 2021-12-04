using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CarnageApi.Core.DTOs;
using System.Linq;

namespace CarnageApi.Core.Models
{
    public class Permission : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<UserSiteRoll> UserSiteRoll { get; set; }
    }
}
