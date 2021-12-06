using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LawApp.Common.Models.Domain;
using LawApp.Common.Models.Dto;
using LawApp.Common.Services;


namespace LawApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Question>>> GetFirst([FromQuery] QuestionPagingDto context)
        {
            return await _questionService.GetFirstQuestionsAsync(context);
        }

        [HttpPost]
        public async Task<ActionResult<List<Question>>> GetByAnswers([FromBody] QuestionsByAnswersDto context)
        {
            return await _questionService.GetByAnswersAsync(context);
        }
    }
}
