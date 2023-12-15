using ApiLayer.ExceptionHandling;
using ApplicationLayer.Commands.Users;
using ApplicationLayer.Requests.Users;
using DomainLayer.Enums.UserEnum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Services.Commands.Abstract;
using Shared.Services.Queries.Abstract;
using System.Diagnostics;

namespace Api.Controllers
{
    [Route("/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICommandHandler<UserRegistration> _createAccount;
        private readonly IQueryHandler<UserLogin, string> _loginUser;
        private readonly IExceptionHandler _exceptionHandler;

        public UserController(ICommandHandler<UserRegistration> createAccount, IQueryHandler<UserLogin, string> loginUser, IExceptionHandler handler)
        {
            _createAccount = createAccount;
            _loginUser = loginUser;
            _exceptionHandler = handler;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterMember([FromBody] UserRegistration command)
        {
            
            try {
                Stopwatch stopwatch = Stopwatch.StartNew();
                await _createAccount.HandleAsync(command);
                Console.WriteLine("\n Time Taken To Execute Registeration " + stopwatch.Elapsed);
                return new OkObjectResult("You can now log into the system");

            }
            catch (Exception ex)
            {
                return _exceptionHandler.Handle(ex);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginMember([FromBody] UserLogin command)
        {
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                var token = await _loginUser.HandleAsync(command);
                Console.WriteLine("\n Time Taken To Execute Login" + stopwatch.Elapsed);
                return new OkObjectResult(token);

            }
            catch (Exception ex)
            {
                return _exceptionHandler.Handle(ex);
            }
        }
    }
}