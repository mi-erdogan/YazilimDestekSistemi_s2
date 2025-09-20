using Microsoft.AspNetCore.Mvc;

namespace YazilimDestekSistemi.WebServis.Controllers
{
    [ApiController]
    [Route("health")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok(new { status = "ok" });
    }
}

