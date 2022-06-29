using DockerAPI.Data;
using DockerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DockerAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PlatformController : ControllerBase
{
    private readonly IPlatformRepo _repo;
    private readonly ILogger<PlatformController> _logger;

    public PlatformController(ILogger<PlatformController> logger,
    IPlatformRepo repo)
    {
        _repo = repo;
        _logger = logger;
    }

    [HttpGet("{id}", Name = "GetPlatformById")]
    public ActionResult<Platform> GetPlatformById(string id)
    {
        var platform = _repo.GetPlatformById(id);
        if (platform != null)
        {
            return Ok(platform);
        }
        return NotFound();
    }

    [HttpPost]
    public ActionResult<Platform> CreatePlatform([FromBody] Platform platform)
    {
        _repo.CreatePlatform(platform);
        return CreatedAtRoute(nameof(GetPlatformById), new { Id = platform.Id }, platform);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Platform>> GetAllPlatforms()
    {
        return Ok(_repo.GetAllPlatforms());
    }
}