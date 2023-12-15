using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.ExceptionHandling
{
    public interface IExceptionHandler
    {
        public IActionResult Handle(Exception exception);
    }
}
