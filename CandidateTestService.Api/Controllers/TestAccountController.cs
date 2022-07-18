using CandidateTestService.Core.Entities;
using CandidateTestService.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CandidateTestService.Api.Controllers
{
    [Route("api/testaccount")]
    [ApiController]
    public class TestAccountController : ControllerBase
    {
        protected ITestAccountService _testAccountService;

        public TestAccountController(ITestAccountService testAccountService)
        {
            _testAccountService = testAccountService;
        }

        [HttpPost("assignTestToAccount")]
        public IActionResult AssignTestToAccount([FromQuery] Guid candidateId, [FromQuery] Guid testId)
        {
            var serviceResult = _testAccountService.Add(new TestAccount { TestId = testId, AccountId = candidateId });
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [HttpPost("updateTestAccount")]
        public IActionResult UpdateTestAccount([FromBody] UpdateTestAccountModel updateTestAccountModel)
        {
            var serviceResult = _testAccountService.UpdateTestAccount(updateTestAccountModel);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }
    }
}
