using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LawApp.Bll.Services;

namespace LawApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }


        /// <summary>
        /// Add default questions in DB
        /// </summary>
        /// <response code="200">Test questions added to database</response>
        [HttpGet]
        public async Task<IActionResult> PopulateData()
        {
            await _adminService.PopulateDbAsync();
            return Ok();
        }
    }
}
