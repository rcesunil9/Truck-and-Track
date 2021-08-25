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
using Microsoft.AspNetCore.StaticFiles;

namespace TrucknDriver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : BaseController
    {
        #region
        private readonly TrucknDriver_LocalContext _dbContext;
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService, TrucknDriver_LocalContext dbContext)
        {
            _dbContext = dbContext;
            _driverService = driverService;
        }
        #endregion

        [HttpGet]
        [Route("GetDriverDetailsbyID")]
        public async Task<IActionResult> GetDriverDetailsbyID(long DriverID)
        {
            var result = await _driverService.GetDriverDetailsbyID(DriverID);
            return FromExecutionResult(result);
        }

        [HttpPost]
        [Route("UpdateDriver")]
        public async Task<IActionResult> UpdateDriver(DriverModel updatedriver)
        {
            var result = await _driverService.UpdateDriver(updatedriver);
            return FromExecutionResult(result);
        }

        [HttpPost]
        [Route("DeleteDriver")]
        public async Task<IActionResult> DeleteDriver(long DriverID, long DeletedBy)
        {
            var result = await _driverService.DeleteDriver(DriverID, DeletedBy);
            return FromExecutionResult(result);
        }

        [HttpGet]
        [Route("GetAllDriverDetails")]
        public async Task<IActionResult> GetAllDriverDetails(long CompanyID, string DriverName, int StartRow, int NoofRows)
        {
            var result = await _driverService.GetAllDriverDetails(CompanyID, DriverName, StartRow, NoofRows);
            return FromExecutionResult(result);
        }
        [HttpGet]
        [Route("GetDriverDocumentsforAdmin")]
        public async Task<IActionResult> GetDriverDocumentsforAdmin(long DriverID)
        {
            var result = await _driverService.GetDriverDocumentsforAdmin(DriverID);
            return FromExecutionResult(result);
        }

        [HttpPost]
        [Route("AddDriverDocumentsforAdmin")]
        public async Task<IActionResult> AddDriverDocumentsforAdmin([FromForm] AddAdminDocumentModel objAddAdminDocumentModel)
        {
            var result = await _driverService.AddDriverDocumentsforAdmin(objAddAdminDocumentModel);
            return FromExecutionResult(result);
        }

        [HttpPost]
        [Route("UpdateDriverDocumentsforAdmin")]
        public async Task<IActionResult> UpdateDriverDocumentsforAdmin(IFormFile DocumentFile, long DriverDocumentID, long UpdatedBy)
        {
            var result = await _driverService.UpdateDriverDocumentsforAdmin(DocumentFile, DriverDocumentID, UpdatedBy);
            return FromExecutionResult(result);
        }

        [HttpDelete]
        [Route("DeleteDriverDocumentsforAdmin")]
        public async Task<IActionResult> DeleteDriverDocumentsforAdmin(long DriverDocumentID, long DeletedBy)
        {
            var result = await _driverService.DeleteDriverDocumentsforAdmin(DriverDocumentID, DeletedBy);
            return FromExecutionResult(result);
        }

        [HttpGet]
        [Route("GetAllDriverNames")]
        public async Task<IActionResult> GetAllDriverNames(long CompanyID)
        {
            var result = await _driverService.GetAllDriverNames(CompanyID);
            return FromExecutionResult(result);
        }

        /// <summary>
        /// Download file from path
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("downloadfile")]
        public async Task<IActionResult> Download(string file)
        {
            try
            {
                var fullPath = Path.GetFullPath(file);
                if (!System.IO.File.Exists(fullPath))
                {
                    return NotFound();
                }
                var memory = new MemoryStream();
                using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                return File(memory, GetContentType(fullPath), file);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }

        [HttpGet]
        [Route("GetDriverDocumentsByCode")]
        public async Task<IActionResult> GetDriverDocumentsByCode(long DriverID, string DocumentCode)
        {
            var result = await _driverService.GetDriverDocumentsByCode(DriverID, DocumentCode);
            return FromExecutionResult(result);
        }
    }
}
