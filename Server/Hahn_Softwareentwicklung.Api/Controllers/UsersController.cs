using Microsoft.AspNetCore.Mvc;

namespace Hahn_Softwareentwicklung.Api.Controllers;


[Route("[controller]")]
public class UsersController : ApiController
{
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        return Ok(User.ToListAsync());
    }
}