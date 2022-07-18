using CandidateTestService.Core.Entities;
using CandidateTestService.Core.Enums;
using CandidateTestService.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CandidateTestService.Api.Controllers
{
    [Route("api/question")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public IActionResult GetQuestions([FromQuery] int index, [FromQuery] int count, [FromQuery] string searchTerms, [FromQuery] QuestionTypeEnum type, [FromQuery] QuestionCategoryEnum category)
        {
            var serviceResult = _questionService.GetQuestions(index, count, searchTerms, type, category);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [HttpGet("{questionId}")]
        public IActionResult GetById([FromRoute] Guid questionId)
        {
            var serviceResult = _questionService.GetById(questionId);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Question question)
        {
            var serviceResult = _questionService.Add(question);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [HttpPut("{questionId}")]
        public IActionResult Update([FromBody] Question question, [FromRoute] Guid questionId)
        {
            var serviceResult = _questionService.Update(question, questionId);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [HttpDelete("{questionId}")]
        public IActionResult Delete([FromRoute] Guid questionId)
        {
            var serviceResult = _questionService.Delete(questionId);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }
    }
}
