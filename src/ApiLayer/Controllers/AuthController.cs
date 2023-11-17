using ApplicationLayer.Commands.Users;
using ApplicationLayer.Requests.Users;
using DomainLayer.Enums.UserEnum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Services.Commands.Abstract;
using Shared.Services.Queries.Abstract;

namespace Api.Controllers
{
    [Route("/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICommandHandler<UserRegistration> _createAccount;
        private readonly IQueryHandler<UserLogin, string> _loginUser;

        public UserController(ICommandHandler<UserRegistration> createAccount, IQueryHandler<UserLogin, string> loginUser)
        {
            _createAccount = createAccount;
            _loginUser = loginUser;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterMember([FromBody] UserRegistration command)
        {
            try { 
            
                await _createAccount.HandleAsync(command);
                return new OkObjectResult("You can now log into the system");

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
                //return _handler.Handle(ex);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginMember([FromBody] UserLogin command)
        {
            try
            {
                var token = await _loginUser.HandleAsync(command);
                return new OkObjectResult(token);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
                //return _handler.Handle(ex);
            }
        }
    }
}