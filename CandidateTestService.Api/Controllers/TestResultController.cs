using CandidateTestService.Core.Entities;
using CandidateTestService.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CandidateTestService.Api.Controllers
{
    [Route("api/testresult")]
    [ApiController]
    public class TestResultController : ControllerBase
    {
        protected ITestResultService _testResultService;

        public TestResultController(ITestResultService testResultService)
        {
            _testResultService = testResultService;
        }

        [HttpPost]
        public IActionResult SubmitTest([FromBody] TestResult testResult)
        {
            var serviceResult = _testResultService.SubmitTest(testResult);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [HttpGet]
        public IActionResult GetTestResultsOfCandidate([FromQuery] Guid candidateId)
        {
            var serviceResult = _testResultService.GetTestResultsOfCandidate(candidateId);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [HttpGet("byTestId")]
        public IActionResult GetTestResultsOfTest([FromQuery] Guid testId)
        {
            var serviceResult = _testResultService.GetTestResultsOfTest(testId);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [HttpPut("{id}")]
        public IActionResult ChamBaiThi([FromBody] TestResult testResult, [FromRoute] Guid id)
        {
            var serviceResult = _testResultService.Update(testResult, id);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }
    }
}
