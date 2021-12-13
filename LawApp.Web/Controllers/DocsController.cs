using System.Collections.Generic;
using System.Threading.Tasks;
using LawApp.Common.Models.Domain;
using LawApp.Common.Models.Dto;
using LawApp.Common.Services;
using Microsoft.AspNetCore.Mvc;

namespace LawApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocsController : ControllerBase
    {
        private readonly IDocService _docService;

        public DocsController(IDocService docService)
        {
            _docService = docService;
        }

        
        /// <summary>
        /// Gets doc list by tag
        /// </summary>
        /// <returns>List of docs</returns>
        ///
        [HttpGet("tag/{tag}")]
        public async Task<ActionResult<List<DocViewModel>>> GetDocsByTag(string tag)
        {
            var docs = await _docService.GetByTagAsync(tag);
            
            return Ok(docs);
        }
        
        /// <summary>
        /// Gets doc list by tags ids
        /// </summary>
        /// <returns>List of docs</returns>
        [HttpPost("tags")]
        public async Task<ActionResult<List<DocViewModel>>> GetDocsByTag([FromBody] List<TagViewModel> tags)
        {
            var docs = await _docService.GetByTagsAsync(tags);
            
            return Ok(docs);
        }
    }
}