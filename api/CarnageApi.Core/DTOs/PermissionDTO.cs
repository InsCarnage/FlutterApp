using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CarnageApi.Core.DTOs;
using System.Linq;
using CarnageApi.Core.Models;

namespace CarnageApi.Core.DTOs
{
    public class PermissionDTO 
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
