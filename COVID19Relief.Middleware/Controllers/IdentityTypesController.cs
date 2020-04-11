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
    public class IdentityTypesController : ControllerBase
    {
        private readonly COVONENINEContext _context;

        public IdentityTypesController(COVONENINEContext context)
        {
            _context = context;
        }

        // GET: api/IdentityTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentityTypes>>> GetIdentityTypes()
        {
            return await _context.IdentityTypes.ToListAsync();
        }

        // GET: api/IdentityTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IdentityTypes>> GetIdentityTypes(int id)
        {
            var identityTypes = await _context.IdentityTypes.FindAsync(id);

            if (identityTypes == null)
            {
                return NotFound();
            }

            return identityTypes;
        }

        // PUT: api/IdentityTypes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdentityTypes(int id, IdentityTypes identityTypes)
        {
            if (id != identityTypes.IdentityTypesId)
            {
                return BadRequest();
            }

            _context.Entry(identityTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdentityTypesExists(id))
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

        // POST: api/IdentityTypes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<IdentityTypes>> PostIdentityTypes(IdentityTypes identityTypes)
        {
            _context.IdentityTypes.Add(identityTypes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIdentityTypes", new { id = identityTypes.IdentityTypesId }, identityTypes);
        }

        // DELETE: api/IdentityTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IdentityTypes>> DeleteIdentityTypes(int id)
        {
            var identityTypes = await _context.IdentityTypes.FindAsync(id);
            if (identityTypes == null)
            {
                return NotFound();
            }

            _context.IdentityTypes.Remove(identityTypes);
            await _context.SaveChangesAsync();

            return identityTypes;
        }

        private bool IdentityTypesExists(int id)
        {
            return _context.IdentityTypes.Any(e => e.IdentityTypesId == id);
        }
    }
}
