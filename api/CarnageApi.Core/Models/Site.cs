using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CarnageApi.Core.DTOs;
using System.Linq;

namespace CarnageApi.Core.Models
{
    public class Site : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Primary { get; set; }
        public string Secondary { get; set; }
        public bool IsActive { get; set; }

        public virtual List<UserSiteRoll> UserSiteRoll { get; set; }


    }
}
