using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.DTOs.QuestionDTOs;
using Application.Services.QuestionServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers.BrandAPI
{
    [Route("api/brand/questions")]
    public class QuestionController : Controller
    {
        private readonly ILogger<QuestionController> _logger;
        private readonly IQuestionServices _questionServices;

        public QuestionController(ILogger<QuestionController> logger, IQuestionServices questionServices)
        {
            _logger = logger;
            _questionServices = questionServices;
        }

        [HttpGet]
        [Route("questionSets")]
        public IActionResult GetQuestionSets()
        {
            var userId = User.FindFirstValue("userId");
            if (userId == null)
            {
                return Unauthorized();
            }
            var questionSets = _questionServices.GetQuestionSets(Guid.Parse(userId));
            return Ok(questionSets);
        }

        [HttpPost]
        [Route("questionSets")]
        public async Task<IActionResult> CreateQuestionSet([FromBody] QuestionSetDTO questionSetDTO)
        {
            var userId = User.FindFirstValue("userId");
            if (userId == null)
            {
                return Unauthorized();
            }
            var questionSet = await _questionServices.CreateQuestionSetAsync(questionSetDTO, Guid.Parse(userId));
            return Ok(questionSet);
        }
     
    }
}