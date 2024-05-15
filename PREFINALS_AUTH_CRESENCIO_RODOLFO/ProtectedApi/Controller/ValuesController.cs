using Microsoft.AspNetCore.Mvc;
using System;

namespace ProtectedApi
{
    [ApiController]
    [Route("[controller]")]
    public class ValueController : ControllerBase
    {
        private readonly string _owner = "Cresencio Rodolfo";
        private readonly Random _random = new Random();
        private readonly string[] _thingsAboutOwner = new[]
        {
            "I love twice",
            "I have cat named macy",
            "I play volleyball",
            "I love watching anime",
            "My name is Rodolfo Mae",
            "I love bean",
            "I love coffee",
            "I love bini",
            "I'm 24 y/o",
            "I love Aerica Mae",
        };

        [HttpGet("about/me")]
        public IActionResult AboutMe()
        {
            var thing = _thingsAboutOwner[_random.Next(_thingsAboutOwner.Length)];
            return Ok(thing);
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            return Ok(_owner);
        }

        [HttpPost("about")]
        public IActionResult About([FromBody] NameModel model)
        {
            return Ok($"Hi {model.Name} from {_owner}");
        }
    }

    public class NameModel
    {
        public string? Name { get; set; }
    }
}