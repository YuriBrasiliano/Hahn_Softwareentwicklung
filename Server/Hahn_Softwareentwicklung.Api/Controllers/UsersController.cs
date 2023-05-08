using Hahn_Softwareentwicklung.Application.Common.Interfaces.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Hahn_Softwareentwicklung.Api.Controllers;


[Route("[controller]")]
public class UsersController : ApiController
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        return Ok(_userRepository.GetAllUsers());
    }
}