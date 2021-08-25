using TrucknDriver.CommonModels;
using TrucknDriver.Entities.Models;
using TrucknDriver.Services.ServiceInterface;
using TrucknDriver.Utilities.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TrucknDriver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        #region
        private readonly TrucknDriver_LocalContext _dbContext;
        private readonly IAuthService _authService;
        private readonly UserManager<AspNetUserModel> userManager;
        private readonly IAccountService _accountService;

        public AccountController(IAuthService authService, UserManager<AspNetUserModel> userManager, IAccountService accountService, TrucknDriver_LocalContext dbContext)
        {
            _dbContext = dbContext;
            _accountService = accountService;
            _authService = authService;
            this.userManager = userManager;
        }
        #endregion
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Login")]

        public async Task<IActionResult> Login(string Username, string PasswordHash)
        {
            var result = await _accountService.Login(Username, PasswordHash);
            return FromExecutionResult(result);
        }

        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(UserServiceModel userModel)//,IFormFile uploadFile1)
        {
            var result = await _accountService.AddUser(userModel);//, uploadFile1);
            return FromExecutionResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        //[HttpGet]
        //[Route("SendMail")]
        //public async Task<IActionResult> SendMail(string EmailAddress)
        //{
        //    var result = await _accountService.SendMailToUser(EmailAddress);
        //    return FromExecutionResult(result);
        //}

        [HttpGet]
        [Route("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(string EmailId)
        {
            var result = await _accountService.ForgetPassword(EmailId);
            return FromExecutionResult(result);
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="EmailId"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(int UserID, string Password,string From)
        {
            var result = await _accountService.ChangePassword(UserID, Password,From);
            return FromExecutionResult(result);
        }

        [HttpGet]
        [Route("GetUserDetailsByID")]
        public async Task<IActionResult> GetUserDetailsByID(string UserID)
        {
            var result = await _accountService.GetUserDetailsByID(UserID);
            return FromExecutionResult(result);
        }

        [HttpPost]
        [Route("AddDriver")]
        public async Task<IActionResult> AddDriver(DriverModel DriverModel)
        {
            var result = await _accountService.AddDriver(DriverModel);
            return FromExecutionResult(result);
        }
        [HttpPost]
        [Route("SaveDriverPhoto")]
        public async Task<IActionResult> SaveDriverPhoto([FromForm] FileDetailModel FileDetailModel)
        {
            FileDetailModel.PhotoType = "driver";
            var result = await _accountService.SavePhoto(FileDetailModel);
            return FromExecutionResult(result);
        }
        [HttpPost]
        [Route("SaveAdminPhoto")]
        public async Task<IActionResult> SaveAdminPhoto([FromForm] FileDetailModel FileDetailModel)
        {
            FileDetailModel.PhotoType = "admin";
            var result = await _accountService.SavePhoto(FileDetailModel);
            return FromExecutionResult(result);
        }
    }
}
