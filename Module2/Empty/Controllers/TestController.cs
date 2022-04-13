
using Empty.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("test")]
public class TestController : ControllerBase
{
    private ICounter _counter;
    private IHttpClientFactory _factory;

    public TestController(ICounter counter, IHttpClientFactory factory)
    {
        _counter = counter;
        _factory = factory;
    }

    [HttpGet("{nr:int}/{iets}")]
    public string Get(int nr, string iets="Mooi")
    {
        HttpClient clt = _factory.CreateClient("test");
        _counter.Increment();
        foreach(var item in RouteData.Values)
        {
           // System.Console.WriteLine(item);
        }
        return $"Hello {iets}" + nr;
    }

    // [Route("hoiii")]
    // [HttpGet()]
    // public async Task<IActionResult> GetAsync()
    // {
    //     return await Task.FromResult<IActionResult>(Content("Hello hoi"));
    // }

    [HttpPost]
    public IActionResult Post(string name, int age)
    {
        return Created($"/test/{age}/{name}", null);
    }
}