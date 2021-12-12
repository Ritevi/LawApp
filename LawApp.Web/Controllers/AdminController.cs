using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LawApp.Bll.Services;
using Microsoft.AspNetCore.Authorization;

namespace LawApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        [Authorize]
        public async Task<IActionResult> PopulateData()
        {
            await _adminService.PopulateDbAsync();
            return Ok();
        }
    }
}
