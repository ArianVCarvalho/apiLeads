using Microsoft.AspNetCore.Mvc;

namespace api.Apis;

public class HelloWorldApi : ControllerBase
{
    [HttpGet("/")]
    public async Task<IActionResult> Get() => Ok("Hello World!");
}