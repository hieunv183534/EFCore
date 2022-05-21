using CandidateTestService.Core.Entities;
using CandidateTestService.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CandidateTestService.Api.Controllers
{
    [Authorize]
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Add([FromBody] Test test)
        {
            var serviceResult = _testService.Add(test);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        public IActionResult GetByIdAdmin([FromRoute] Guid id)
        {
            var serviceResult = _testService.GetTest(id, false);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult GetTestsAdmin([FromQuery] int index, [FromQuery] int count, [FromQuery] string searchTerms)
        {
            var serviceResult = _testService.GetTests(index, count, searchTerms, false);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }


        [Authorize(Roles = "candidate")]
        [HttpGet("candidate/{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var serviceResult = _testService.GetTest(id, true);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [Authorize(Roles = "candidate")]
        [HttpGet("candidate")]
        public IActionResult GetTests([FromQuery] int index, [FromQuery] int count, [FromQuery] string searchTerms)
        {
            var serviceResult = _testService.GetTests(index, count, searchTerms, true);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

    }
}
