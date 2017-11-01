using lab36_miya.Data;
using lab36_miya.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab36_miya.Controllers
{
    //below is a route token inside of attribute routing - curly braces make the routing more dynamic
    //we are using ControllerBase instead of Controller here because this will not be a front-facing app
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly Lab36DbContext _context;

        public CoursesController(Lab36DbContext context)
        {
            _context = context;
        }

        ////Get
        //below is an example of model binding with id constraints which are optional
        [HttpGet ("{id:int?}")]
        public IActionResult Get(int id)
        {
            //storing a LINQ query containing a lambda statement within an anonymous variable
            var result = _context.RequiredCoursework.FirstOrDefault(h => h.ID == id);
            //returning a good status code (200)
            return Ok(result);
        }

        //Post - creates a resource
        //from body in a form of model binding that controls requirements added to the database
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RequiredCoursework requirement)
        {
            await _context.AddAsync(requirement);
            await _context.SaveChangesAsync();


            //this will return a get URL that references the new requirement added
            return CreatedAtAction("Get", new {id = requirement.ID }, requirement);
        }

        //Put - updates something to the resource or creates resource

        //Delete
    }
}
