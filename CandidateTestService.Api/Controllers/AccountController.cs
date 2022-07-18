using CandidateTestService.Api.Authentication;
using CandidateTestService.Core.Entities;
using CandidateTestService.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CandidateTestService.Api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Delare

        protected ITokenAccountService _tokenAccountService;
        protected IAccountService _accountService;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;

        #endregion

        public AccountController(ITokenAccountService tokenAccountService, IAccountService accountService, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _tokenAccountService = tokenAccountService;
            _accountService = accountService;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Account account)
        {
            var token = _jwtAuthenticationManager.Authenticate(account.UserName, account.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(new ResponseModel(1000, "OK", token));
        }

        [HttpPost("logout")]
        public IActionResult Logout([FromHeader] string Authorization)
        {
            var serviceResult = _tokenAccountService.DeleteTokenByToken(Authorization);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }


        [HttpPost]
        public IActionResult Add([FromBody] Account account)
        {
            account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            var serviceResult = _accountService.Add(account);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [HttpPut("{accountId}")]
        //[AllowAnonymous]
        public IActionResult Update([FromBody] Account account, [FromRoute] Guid accountId)
        {
            account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            var serviceResult = _accountService.Update(account, accountId);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [HttpGet("{accountId}")]
        public IActionResult GetAccount([FromRoute] Guid accountId)
        {
            var serviceResult = _accountService.GetById(accountId);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [HttpDelete("{accountId}")]
        public IActionResult Delete([FromRoute] Guid accountId)
        {
            var serviceResult = _accountService.Delete(accountId);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }

        [HttpGet]
        public IActionResult GetAccounts([FromQuery] int index, [FromQuery] int count, [FromQuery] string searchTerms, [FromQuery] string role)
        {
            var serviceResult = _accountService.GetAccounts(index, count, searchTerms, role);
            return StatusCode(serviceResult.StatusCode, serviceResult.Response);
        }
    }
}
