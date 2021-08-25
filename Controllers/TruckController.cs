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
    public class TruckController : BaseController
    {
        #region
        private readonly TrucknDriver_LocalContext _dbContext;
        private readonly ITruckService _truckService;

        public TruckController(ITruckService truckService, TrucknDriver_LocalContext dbContext)
        {
            _dbContext = dbContext;
            _truckService = truckService;
        }
        #endregion

        [HttpPost]
        [Route("AddTruck")]
        public async Task<IActionResult> AddTruck(TruckModel objTruckModel)
        {
            var result = await _truckService.AddTruck(objTruckModel);
            return FromExecutionResult(result);
        }

        [HttpPost]
        [Route("SaveTruckPhoto")]
        public async Task<IActionResult> SaveTruckPhoto([FromForm] FileDetailModel objFileDetailModel)
        {
            var result = await _truckService.SaveTruckPhoto(objFileDetailModel);
            return FromExecutionResult(result);
        }
        
    }
}
