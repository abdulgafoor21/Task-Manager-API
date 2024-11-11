using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[EnableCors("AllowAll")]
public class BaseController : ControllerBase
{
    
}