using Microsoft.AspNetCore.Mvc;

namespace Crud_Pessoas_Cidades_WebAPI;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    [HttpGet]
    public string hello()
    {
        return "hello";
    }
}
