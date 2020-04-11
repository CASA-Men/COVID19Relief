using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COVID19Relief.Middleware.Model;

namespace COVID19Relief.Middleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateLocalGovernmentsController : ControllerBase
    {
        private readonly COVONENINEContext _context;

        public StateLocalGovernmentsController(COVONENINEContext context)
        {
            _context = context;
        }

        // GET: api/StateLocalGovernments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StateLocalGovernment>>> GetStateLocalGovernment()
        {
            return await _context.StateLocalGovernment.ToListAsync();
        }

        // GET: api/StateLocalGovernments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StateLocalGovernment>> GetStateLocalGovernment(short id)
        {
            var stateLocalGovernment = await _context.StateLocalGovernment.FindAsync(id);

            if (stateLocalGovernment == null)
            {
                return NotFound();
            }

            return stateLocalGovernment;
        }

        
        [HttpGet]
        [Route("GetStateLocalGovernmentByStateId")]
        public async Task<ActionResult<IEnumerable<StateLocalGovernment>>> GetStateLocalGovernmentByStateId(int id)
        {
            var stateLocalGovernment = await _context.StateLocalGovernment.Where(x=>x.StateId == id).ToListAsync();

            if (stateLocalGovernment == null)
            {
                return NotFound();
            }

            return stateLocalGovernment;
        }

        // PUT: api/StateLocalGovernments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStateLocalGovernment(short id, StateLocalGovernment stateLocalGovernment)
        {
            if (id != stateLocalGovernment.StateLocalGovernmentId)
            {
                return BadRequest();
            }

            _context.Entry(stateLocalGovernment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StateLocalGovernmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StateLocalGovernments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<StateLocalGovernment>> PostStateLocalGovernment(StateLocalGovernment stateLocalGovernment)
        {
            _context.StateLocalGovernment.Add(stateLocalGovernment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StateLocalGovernmentExists(stateLocalGovernment.StateLocalGovernmentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStateLocalGovernment", new { id = stateLocalGovernment.StateLocalGovernmentId }, stateLocalGovernment);
        }

        // DELETE: api/StateLocalGovernments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StateLocalGovernment>> DeleteStateLocalGovernment(short id)
        {
            var stateLocalGovernment = await _context.StateLocalGovernment.FindAsync(id);
            if (stateLocalGovernment == null)
            {
                return NotFound();
            }

            _context.StateLocalGovernment.Remove(stateLocalGovernment);
            await _context.SaveChangesAsync();

            return stateLocalGovernment;
        }

        private bool StateLocalGovernmentExists(short id)
        {
            return _context.StateLocalGovernment.Any(e => e.StateLocalGovernmentId == id);
        }
    }
}
