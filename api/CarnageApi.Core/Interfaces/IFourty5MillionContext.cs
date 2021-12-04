using System;
using System.Collections.Generic;
using System.Text;
using CarnageApi.Core.Models;

namespace CarnageApi.Core.Interfaces
{
	public class IFourty5MillionContext
	{
		IRepository<Permission> permission { get; }
		IRepository<Site> site { get; }
		IRepository<User> user { get; }
		IRepository<UserSiteRoll> userSiteRoll { get; }
	}
}
