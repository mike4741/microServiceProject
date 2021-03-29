using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {

        private  readonly IWebHostEnvironment _env;
        public EventController(IWebHostEnvironment env)
        {
            _env = env;  
        }

        [HttpGet("{id}")]
        public IActionResult GetImage( int id)
        {
            var webroot = _env.WebRootPath;
            var path = Path.Combine($"{webroot}/Pics/", $"___{id}.Jpg");
            var  buffer = System.IO.File.ReadAllBytes(path);
            return File(buffer, "image/jpeg");

        }
      
    }
}
