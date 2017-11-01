using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week8Tom.Data;
using Week8Tom.Models;

namespace Week8Tom.Controllers
{
    //Route token & attribute routing
    [Route("api/[controller]")]
    public class HeroesController : ControllerBase
    {
        private readonly HeroStatsDbContext _context;

        //Dependency injection of context
        public HeroesController(HeroStatsDbContext context)
        {
            _context = context;
        }

        //GET
        //Id constraint
        [HttpGet("{id:int?}")]
        public IActionResult Get(int id)
        {
            //linq query using a lambda expression
            var result = _context.HeroStats.FirstOrDefault(h => h.Id == id);

            //returns 200 status code
            return Ok(result);
        }

        //POST
        //Model binding
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post([FromBody]HeroStats stat)
        {
            await _context.AddAsync(stat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = stat.Id }, stat);
        }

        //PUT

        //DELETE
    }
}
