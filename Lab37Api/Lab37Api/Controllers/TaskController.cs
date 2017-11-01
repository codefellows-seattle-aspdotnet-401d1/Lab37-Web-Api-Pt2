using Lab37Api.Data;
using Lab37Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab37Api.Controllers
{
    [Route("api/[Controller]")]
    public class TaskController : ControllerBase
    {
        private readonly BirthdayPlanDbContext _context;

        public TaskController(BirthdayPlanDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var result = _context.BirthdayPlan.FirstOrDefault(c => c.ID == id);
            return Ok(result);
        }

        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<BirthdayPlan> Get()
        {
            return _context.BirthdayPlan;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BirthdayPlan plan)
        {
            await _context.AddAsync(plan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = plan.ID }, plan);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] BirthdayPlan plan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Put = _context.BirthdayPlan.FirstOrDefault(p => p.ID == id);
            if (Put != null)
            {
                Put.Task = plan.Task;
                Put.IsComplete = plan.IsComplete;
                _context.Update(Put);

                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult>Delete(int id)
        {
            var result = _context.BirthdayPlan.FirstOrDefault(d => d.ID == id);

            if(result != null)
            {
                _context.BirthdayPlan.Remove(result);

                await _context.SaveChangesAsync();

                return Ok();
            }
            return BadRequest();
        }

    }
}
