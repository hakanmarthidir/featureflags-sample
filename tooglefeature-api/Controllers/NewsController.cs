using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;

namespace tooglefeature_api.Controllers;

[ApiController]
[Route("api/[controller]")]
[FeatureGate("NewsAPI")]
public class NewsController : ControllerBase
{
    private readonly ILogger<NewsController> _logger;
    private readonly IFeatureManager _featureManager;

    public NewsController(ILogger<NewsController> logger, IFeatureManager featureManager)
    {
        _logger = logger;
        _featureManager = featureManager;
    }

    [FeatureGate("SportAPI")]
    [HttpGet]
    [Route("[action]")]
    public IActionResult SportNews()
    {
        return Ok(new string[] { "SportNews 1", "SportNews 2", "SportNews 3" });

    }

    [FeatureGate("WeatherAPI")]
    [HttpGet]
    [Route("[action]")]
    public IActionResult WeatherNews()
    {
        return Ok(new string[] { "Weather News Berlin", "Weather News Stuttgart", "Weather News Esslingen" });

    }

    //[FeatureGate("EconomyAPI")]
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> EconomyNews()
    {

        if (await _featureManager.IsEnabledAsync("EconomyAPI"))
        {
            return Ok(new string[] { "Money News", "Crypto News", "Gold News" });
        }

        return BadRequest();
    }

    [FeatureGate("MagazineAPI")]
    [HttpGet]
    [Route("[action]")]
    public IActionResult MagazineNews()
    {
        return Ok(new string[] { "BradPitt News", "Angelina Jolie News" });

    }

    [FeatureGate("WeekendNewsAPI")]
    [HttpGet]
    [Route("[action]")]
    public IActionResult WeekendNews()
    {
        return Ok(new string[] { "Weekend Special News" });

    }
}

