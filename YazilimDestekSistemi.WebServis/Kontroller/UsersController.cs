using Microsoft.AspNetCore.Mvc;

namespace YazilimDestekSistemi.WebServis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(new[] { new { id = 1, name = "Test User" } });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(new { id, name = $"Test User {id}" });
        }

        [HttpPost]
        public IActionResult Create(object body)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, body);
        }
    }
}

