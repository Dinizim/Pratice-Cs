using EmployeeManeger.Application.Service;
using EmployeeManeger.Domain.Models.EmployeeAggregate;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManeger.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : Controller
{
    [HttpPost]
    public IActionResult Auth(string username, string password)
    {
        if (username == "nick" && password == "123456")
        {
            var token = TokenService.GenerateToken(new Employee(username, 14, null));
            return Ok(token);
        }

        return BadRequest("username or password invalid");
    }
}