using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarnageApi.Core;
using CarnageApi.Core.DTOs;

namespace CarnageApi.Core.Interfaces
{
    public interface IEmailService
    {
        string SendEmail(MessageDTO message);
    }
}
