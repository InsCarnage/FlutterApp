using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading;
using System.Web;
using CarnageApi.Core.Interfaces;
using CarnageApi.Web.Controllers;
using CarnageApi.Core.DTOs;
using Newtonsoft.Json;
using Castle.Core.Internal;

namespace CarnageApi.Web.Filters
{
	public class AuthorizationFilterAttribute : ActionFilterAttribute
	{
		private string _permission;

		public AuthorizationFilterAttribute(string permission)
		{
			_permission = permission;
		}

		public AuthorizationFilterAttribute()
		{

		}

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			// Get the site Id from the request header
			var siteIdHeader = context.HttpContext.Request.Headers.FirstOrDefault(x => x.Key.ToLower() == "siteid");
			var siteId = Convert.ToInt32(siteIdHeader.Value);

			// Get all of the user's claims from the HTTP Context
			var userClaimskeys = context.HttpContext.Request.Headers;

			var userId = Convert.ToInt32(userClaimskeys.First(x=>x.Key.Contains("userid")).Value);
			var displayName = (userClaimskeys.First(x=>x.Key.Contains("name")).Value).ToString();


			//var userId = Convert.ToInt32(userClaims.First(x => x.Type.ToLower() == "userid").Value);
			//var displayName = userClaims.First(x => x.Type.ToLower() == "name").Value;


			// If the user does not have the appropriate permissions, deny access
			//if (currentSitePermissionList != null && (!(currentSitePermissionList.Any(x => x == _permission) || _permission.IsNullOrEmpty())))
			//{
			//	context.Result = new UnauthorizedResult();
			//	return;
			//}

			//((IAuthInfo)context.HttpContext.RequestServices.GetService(typeof(IAuthInfo))).Permissions = currentSitePermissionList;
			((IAuthInfo)context.HttpContext.RequestServices.GetService(typeof(IAuthInfo))).DisplayName = displayName;
			((IAuthInfo)context.HttpContext.RequestServices.GetService(typeof(IAuthInfo))).UserId = userId;
			((IAuthInfo)context.HttpContext.RequestServices.GetService(typeof(IAuthInfo))).SiteId = siteId;
		}
	}
}
