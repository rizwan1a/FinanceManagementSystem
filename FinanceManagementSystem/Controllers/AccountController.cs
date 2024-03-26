using D2Soft.Application.Business.AccountMediator.Commands;
using D2Soft.Application.Business.AccountMediator.Queries;
using D2Soft.Application.DTOs;
using D2Soft.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinanceManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Route("/GetAllActiveAccounts")]
        [HttpGet]
        public async Task<IActionResult> GetAllActiveAccounts()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllActiveAccountsQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("/AddAccount")]
        [HttpPost]
        public async Task<IActionResult> AddAccount(AccountDTO account)
        {
            try
            {
                var command = new AddAccountCommand() { Account = account };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("/DeleteAccount/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            try
            {
                var command = new DeleteAccountCommand() { Id = id };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
