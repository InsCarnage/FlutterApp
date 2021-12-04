using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using CarnageApi.Core;
using CarnageApi.Core.DTOs;
using CarnageApi.Core.Interfaces;
using EASendMail;
using System.Security.Claims;
using Newtonsoft.Json;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using CarnageApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.Azure.Storage.Shared.Protocol;

namespace CarnageApi.Core.Services
{
    public class AuthService : IAuthService
    {

		private readonly IFourty5MillionUnitOfWork _unitOfWork;


		public AuthService(IFourty5MillionUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		private string GenerateJSONWebToken(UserAuthDTO user)
		{
			var jwtKey = "b0a63101-30e9-4d6a-bd22-a327c0cf9281";
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new List<Claim>
			{
				new Claim("name",user.DisplayName),
				new Claim("isAdmin", user.IsAdmin.ToString()),
				new Claim("userId", user.Id.ToString()),
				new Claim("SiteId",user.SitePermissions.First(x=>x.SiteId != 0).SiteId.ToString()),
			};



			var token = new JwtSecurityToken("CarnageApi.Core.Services.AuthenticationService",
			  "CarnageApi.Web.Controllers.Authentication",
			  claims,
			  expires: DateTime.Now.AddDays(365),
			  signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		//private UserAuthDTO AuthenticateUser(SignInUserDto requestModel)
		//{
		//	var uppercasePassword = requestModel.Password.ToUpper();

		//	var currentUser = new Models.User();

		//	if (uppercasePassword == "688B33274C5FE0D34511033327D1CBE7")
		//	{
		//		currentUser = _unitOfWork.User.Query(x => x.Email == requestModel.Email && x.IsActive)
		//		.Include("Student")
		//		.Include("UserSiteRoles")
		//		.Include("UserSiteRoles.Site")
		//		.Include("UserSiteRoles.Role")
		//		.Include("UserSiteRoles.Role.RolePermissions")
		//		.Include("UserSiteRoles.Role.RolePermissions.Permission")
		//		.FirstOrDefault();
		//	}
		//	else
		//	{
		//		currentUser = _unitOfWork.User.Query(x => x.PasswordHash == uppercasePassword && x.Email == requestModel.Email && x.IsActive)
		//		.Include("Student")
		//		.Include("UserSiteRoles")
		//		.Include("UserSiteRoles.Site")
		//		.Include("UserSiteRoles.Role")
		//		.Include("UserSiteRoles.Role.RolePermissions")
		//		.Include("UserSiteRoles.Role.RolePermissions.Permission")
		//		.FirstOrDefault();
		//	}

		//	if (currentUser == null) throw new ValidationException("No user found that matches the supplied credentials");

		//	var studentRoleId = (int)Constants.StudentRole;

		//	var sitePermissions = currentUser.UserSiteRoles.GroupBy(x => new
		//	{
		//		x.SiteId,
		//		x.Site.CompanyName,
		//		x.Site.SiteTypeId,
		//		x.Site.HomePageImageUrl,
		//		x.Site.LogoUrl,
		//		x.Site.SchoolPrimaryColor,
		//		x.Site.SchoolSecondaryColor,
		//		x.Site.SchoolTertiaryColor,
		//		x.Site.SchoolFontColor,
		//		x.Site.IsMentoringAvailable,
		//		x.Site.VirtualClassroom,
		//		x.User.SignatureImageUrl,
		//	}).Select(x => new SitePermissionDto
		//	{
		//		SiteId = x.Key.SiteId,
		//		SiteName = x.Key.CompanyName,
		//		SiteLogoUrl = x.Key.HomePageImageUrl ?? x.Key.LogoUrl,
		//		LanguageId = x.Where(y => y.RoleId == studentRoleId).FirstOrDefault()?.LanguageId,
		//		CourseClassificationId = x.Where(y => y.RoleId == studentRoleId).FirstOrDefault()?.CourseClassificationId,
		//		Permissions = x.SelectMany(y => y.Role.RolePermissions.Select(rolePermission => rolePermission.Permission.Name)).ToList(),
		//		SiteTypeId = x.Key.SiteTypeId,
		//		SchoolPrimaryColor = x.Key.SchoolPrimaryColor,
		//		SchoolSecondaryColor = x.Key.SchoolSecondaryColor,
		//		SchoolTertiaryColor = x.Key.SchoolTertiaryColor,
		//		SchoolFontColor = x.Key.SchoolFontColor,
		//		IsMentoringAvailable = x.Key.IsMentoringAvailable,
		//		VirtualClassroom = x.Key.VirtualClassroom,
		//		FontStyle = false,
		//		HasSignature = x.Key.SignatureImageUrl.IsNotNullOrEmpty(),

		//	}).ToList();

		//	foreach (int t in Enum.GetValues(typeof(courseClassificationFont)))
		//	{
		//		int temp;
		//		if (sitePermissions.Count != 0)
		//		{
		//			temp = sitePermissions.FirstOrDefault().CourseClassificationId.IsNotNullOrZero() ? sitePermissions.FirstOrDefault().CourseClassificationId.Value : 0;
		//			if (temp == t)
		//			{
		//				sitePermissions.FirstOrDefault().FontStyle = true;
		//			}
		//		}
		//	}

		//	return new AuthUserInfoDTO
		//	{
		//		CurrentUserId = currentUser.Id,
		//		IsStudent = currentUser.Student != null,
		//		ProfilePictureUrl = currentUser.ImageUrl,
		//		SitePermissions = sitePermissions,
		//		DisplayName = currentUser.DisplayName
		//	};
		//}


		private UserAuthDTO AuthenticateUser(UserAuthDTO userAuth)
		{
            try
            {
				var returnData = _unitOfWork.User.Query(x => x.Email.ToLower() == userAuth.Email.ToLower() && x.PasswordHash == userAuth.PasswordHash && x.IsActive).Select(x => new UserAuthDTO
				{
					Id = x.Id,
					PasswordHash = x.PasswordHash,
					ValidUser = true,
					DisplayName = x.DisplayName,
					Email = x.Email

				}).Single();

				var sitePermissions = _unitOfWork.UserSiteRoll.Query(e => e.UserId == returnData.Id).Select(y => y.UserSiteRollDTO).ToList();
				returnData.SitePermissions = sitePermissions;


				var userInfo = new AuthInfo
				{
					Permissions = returnData.SitePermissions.Select(x => x.PermissionId.ToString()).ToList(),
					SiteId = returnData.SitePermissions.First().SiteId,
					UserId = returnData.Id,
					DisplayName = returnData.DisplayName
				};

				return returnData;
			
			}
            catch (Exception)
            {
				throw new ValidationException("Autentication Failed"); ;
            }

		}

		public UserAuthDTO signIn(UserAuthDTO user) 
		{
			var signedInUser = AuthenticateUser(user);

			var apiToken = GenerateJSONWebToken(signedInUser);
				
			signedInUser.ApiToken = apiToken;


			return signedInUser;
		}

		public List<User> listUsers() 
		{
			var result = _unitOfWork.User.Query().ToList();
			return result;
		}

		public List<Site> ListSite()
		{
			var result = _unitOfWork.Site.Query().ToList();
			return result;
		}

		public List<Permission> ListPermission()
		{
			var result = _unitOfWork.Permission.Query().ToList();
			return result;
		}

		public List<UserSiteRollDTO> ListUserSiteRoll()
		{
			var result = _unitOfWork.UserSiteRoll.Query().Select(x=>x.UserSiteRollDTO).ToList();
			return result;
		}
	}
}
