using CandidateTestService.Core.Entities;
using CandidateTestService.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace CandidateTestService.Api.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] Test test)
        {
            var serviceResult = _testService.Add(test);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }


        [HttpGet("{id}")]
        public IActionResult GetByIdAdmin([FromRoute] Guid id)
        {
            var serviceResult = _testService.GetTest(id, false);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [HttpGet]
        public IActionResult GetTestsAdmin([FromQuery] int index, [FromQuery] int count, [FromQuery] string searchTerms)
        {
            var serviceResult = _testService.GetTests(index, count, searchTerms, false);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }



        [HttpGet("candidate/{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var serviceResult = _testService.GetTest(id, true);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }


        [HttpGet("candidate")]
        public IActionResult GetTests([FromQuery] int index, [FromQuery] int count, [FromQuery] string searchTerms)
        {
            var serviceResult = _testService.GetTests(index, count, searchTerms, true);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }


        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Test test, [FromRoute] Guid id)
        {
            var serviceResult = _testService.Update(test, id);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [HttpGet("getCandidatesOfTest/{testId}")]
        public IActionResult GetCandidatesOfTest([FromRoute] Guid testId)
        {
            var serviceResult = _testService.GetCandidatesOfTest(testId);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [HttpGet("getTestsAssignToMe")]
        public IActionResult GetTestsAssignToMe([FromQuery] Guid myId)
        {
            //Guid myId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            var serviceResult = _testService.GetTestsAssignToMe(myId);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [HttpDelete("{testId}")]
        public IActionResult DeleteTest([FromRoute] Guid testId)
        {
            var serviceResult = _testService.Delete(testId);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        } 
    }
}
