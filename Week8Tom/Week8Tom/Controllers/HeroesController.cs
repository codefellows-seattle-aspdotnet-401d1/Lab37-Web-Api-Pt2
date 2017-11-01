﻿using Microsoft.AspNetCore.Mvc;
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

        //Gets all heroes in the database
        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<HeroStats> Get()
        {
            return _context.HeroStats;

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
        public async Task<IActionResult> Post([FromBody]HeroStats stat)
        {
            await _context.AddAsync(stat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = stat.Id }, stat);
        }

        //PUT
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody]HeroStats stat)
        {
            var check = _context.HeroStats.FirstOrDefault(p => p.Id == id);
            if (check != null)
            {
                //checks to see if stats are the same and updates
                check.Alias = stat.Alias;
                check.Name = stat.Name;
                _context.Update(check);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }


        //DELETE
    }
}
