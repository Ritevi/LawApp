using System.Collections.Generic;
using System.Threading.Tasks;
using LawApp.Common.Models.Domain;
using LawApp.Common.Services;
using Microsoft.AspNetCore.Mvc;

namespace LawApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        /// <summary>
        /// Gets tag list
        /// </summary>
        /// <returns>List of tags</returns>
        ///
        [HttpGet("tags")]
        public async Task<ActionResult<List<Tag>>> GetTags()
        {
            var tags = await _tagService.GetTagsAsync();
            
            return Ok(tags);
        }
    }
}