
using DomainLayer.Enums.ApplicationEnum;
using DomainLayer.Excepetions.Users;
using Microsoft.AspNetCore.Mvc;
using Shared.Services.Auth.Exceptions;


namespace ApiLayer.ExceptionHandling
{
    public class ExceptionHandler : IExceptionHandler { 
    public IActionResult Handle(Exception exception)
    {
        switch (exception)
        {
            case NoUserFoundException ex:
                return new NotFoundObjectResult(ex.Message);
            case UnsecurePasswordException ex:
                return new BadRequestObjectResult(ex.Message);
            case PasswordIsNotSecureException ex:
                return new BadRequestObjectResult(ex.Message);
            case UserAccountIsNoLongerActive ex:
                return new ForbidResult(ex.Message);
            case UserExistsException ex:
                return new ConflictObjectResult(ex.Message);
            case UserPasswordDoesNotMatchException ex:
                return new ForbidResult(ex.Message);
            case CannotFindCountryVisasException ex:
                 return new NotFoundObjectResult(ex.Message);
            case CannotFindVisaException ex:
                  return new NotFoundObjectResult(ex.Message);
            case NoSuggestionThatMeetsCriteriaException ex:
                  return new NotFoundObjectResult(ex.Message);
            default:
                return new BadRequestObjectResult("An unexpected error occurred."); // Or any other appropriate status code
        }
    }
   }
}
