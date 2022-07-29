
using Microsoft.AspNetCore.Mvc;
using POSSolution.Core.Models;
using POSSolution.Infrastructure;


namespace POSSolution.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : BaseController<User>
{
    public UserController(POSContext context) : base(context)
    {

    }
}

