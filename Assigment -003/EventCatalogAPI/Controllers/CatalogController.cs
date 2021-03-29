using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly EventContext _context;
        private readonly IConfiguration _config;
        public CatalogController(EventContext context , IConfiguration config )
        {
            _context = context;
            _config = config;
        }
        [HttpGet("[action]")]
         public async Task<IActionResult> Events( 
            [FromQuery] int pageIndex = 0 , 
            [FromQuery] int pagesize = 6)
        {
            var events=  await _context.EventItems
                                 .OrderBy(c => c.EventName)
                                 .Skip(pagesize)
                                 .Take(pagesize)
                                 .ToListAsync();
            events = ChangePictureUrl(events);
            return Ok(events);
        }
        [HttpGet("[action]/Category/type")]
        public  async Task <IActionResult> Events(
                     [FromQuery]  int? eventCatagoryId , 
                     [FromQuery]  int? eventTypeId,
                     [FromQuery] int pageIndex = 0,
                     [FromQuery] int pagesize = 6)
        {
            var query = (IQueryable<EventItem>) _context.EventItems;
            if(eventCatagoryId.HasValue)
            {
                query = query.Where(e => e.CatagoryId == eventCatagoryId);
            }
             if(eventTypeId.HasValue)
            {
                query = query.Where(e => e.TypeId == eventTypeId);
            }
            var events = await query
                          .OrderBy(e => e.EventName)
                          .Skip(pagesize)
                          .Take(pagesize)
                          .ToListAsync();
            return Ok(events);

        }
        private List<EventItem> ChangePictureUrl(List<EventItem> events)
        {
            events.ForEach(e =>
             e.EventImageUrl =
             e.EventImageUrl.Replace(
                "____", _config["ExternalCatalogBaseUrl"]));
            return events ; 

    }
        [HttpGet("action")]
         public async Task<IActionResult> EventTypes()
        {
           var type =  await  _context.EventTypes.ToListAsync();
            return Ok(type);
        }
        [HttpGet("action")]
        public async Task<IActionResult> eventCatagory()
        {
            var catagory  = await _context.EventCategories.ToArrayAsync();
            return Ok(catagory);
        }
        [HttpGet("action")]
        public async Task<IActionResult> Organizer()
        {
            var address = await _context.EventOrganizers.ToArrayAsync();
            return Ok(address);
        }

    }
}
