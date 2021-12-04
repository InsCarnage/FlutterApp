using Microsoft.AspNetCore.Mvc;
using CarnageApi.Core.Services;
using CarnageApi.Core.DTOs;
using CarnageApi.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System;
using CarnageApi.Web.Filters;
using CarnageApi.Core.Models;
using System.Collections.Generic;

namespace CarnageApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IAuthService _authService;


        public AuthController(IAuthService authService) 
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("~/api/Authentication/SignIn")]
        [AllowAnonymous]
        public UserAuthDTO SignIn(UserAuthDTO user)
        {
            var serviceData = _authService.signIn(user);
            
            return serviceData;
        }


        [HttpGet]
        [Route("~/api/ListUsers")]
        //[AuthorizationFilter]
        [AuthorizationFilter]
        public List<User> ListUsers()
        {
            return _authService.listUsers();
        }

        [HttpGet]
        [Route("~/api/Sites")]
        //[AuthorizationFilter]
        [AuthorizationFilter]
        public List<Site> ListSites()
        {
            return _authService.ListSite();
        }

        [HttpGet]
        [Route("~/api/Permissions")]
        //[AuthorizationFilter]
        [AuthorizationFilter]
        public List<Permission> ListPermission()
        {
            return _authService.ListPermission();
        }

        [HttpGet]
        [Route("~/api/UserSiteRoll")]
        //[AuthorizationFilter]
        [AuthorizationFilter]
        public List<UserSiteRollDTO> ListUserSiteRoll()
        {
            return _authService.ListUserSiteRoll();
        }
    }
}
