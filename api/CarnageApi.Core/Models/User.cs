using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CarnageApi.Core.DTOs;
using System.Linq;

namespace CarnageApi.Core.Models
{
    public class User : BaseModel
    {
        public int Id { get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string DisplayName{ get; set; }
        public string Email{ get; set; }
        public string PasswordHash{ get; set; }
        public bool IsActive{ get; set; }

        public virtual List<UserSiteRoll> UserSiteRoll { get; set; }



    }
}
