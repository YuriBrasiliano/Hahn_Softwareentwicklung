using Microsoft.AspNetCore.Mvc;

namespace Hahn_Softwareentwicklung.Api.Controllers;


[Route("[controller]")]
public class TasksController : ApiController
{
    [HttpGet]
    public IActionResult ListTasks()
    {
        return Ok(Array.Empty<string>());
    }
}