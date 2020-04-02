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
    public class StatesTablesController : ControllerBase
    {
        private readonly COVONENINEContext _context;

        public StatesTablesController(COVONENINEContext context)
        {
            _context = context;
        }

        // GET: api/StatesTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatesTable>>> GetStatesTable()
        {
            return await _context.StatesTable.ToListAsync();
        }

        // GET: api/StatesTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatesTable>> GetStatesTable(byte id)
        {
            var statesTable = await _context.StatesTable.FindAsync(id);

            if (statesTable == null)
            {
                return NotFound();
            }

            return statesTable;
        }

        // PUT: api/StatesTables/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatesTable(byte id, StatesTable statesTable)
        {
            if (id != statesTable.StateId)
            {
                return BadRequest();
            }

            _context.Entry(statesTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatesTableExists(id))
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

        // POST: api/StatesTables
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<StatesTable>> PostStatesTable(StatesTable statesTable)
        {
            _context.StatesTable.Add(statesTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StatesTableExists(statesTable.StateId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStatesTable", new { id = statesTable.StateId }, statesTable);
        }

        // DELETE: api/StatesTables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StatesTable>> DeleteStatesTable(byte id)
        {
            var statesTable = await _context.StatesTable.FindAsync(id);
            if (statesTable == null)
            {
                return NotFound();
            }

            _context.StatesTable.Remove(statesTable);
            await _context.SaveChangesAsync();

            return statesTable;
        }

        private bool StatesTableExists(byte id)
        {
            return _context.StatesTable.Any(e => e.StateId == id);
        }
    }
}
