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
    [ApiController]
    [Route("api/[controller]/question")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        /// <summary>
        /// Get questions from DB
        /// </summary>
        /// <returns>List of questions</returns>
        /// <response code="200">List of questions</response>
        [HttpGet]
        public async Task<ActionResult<List<Question>>> GetFirst([FromQuery] QuestionPagingDto context)
        {
            return await _questionService.GetFirstQuestionsAsync(context);
        }

        /// <summary>
        /// Get questions by answers
        /// </summary>
        /// <returns>List of questions fro answer</returns>
        /// <response code="200">List of questions answer</response>
        [HttpPost]
        public async Task<ActionResult<List<Question>>> GetByAnswers([FromBody] QuestionsByAnswersDto context)
        {
            return await _questionService.GetByAnswersAsync(context);
        }
    }
}
