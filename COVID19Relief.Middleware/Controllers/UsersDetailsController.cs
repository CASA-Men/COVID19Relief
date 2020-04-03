using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COVID19Relief.Middleware.Model;
using Microsoft.AspNetCore.Cors;

namespace COVID19Relief.Middleware.Controllers
{
    [EnableCors()]
    [Route("api/Users/")]
    [ApiController]
    public class UsersDetailsController : ControllerBase
    {
        private readonly COVONENINEContext _context;


        public UsersDetailsController(COVONENINEContext context)
        {
            _context = context;
        }

        [HttpGet]

        // GET: Users
        [Route("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/UsersDetails/5
        [HttpGet]
        [Route("GetUserDetails")]
        public async Task<ActionResult<Users>> GetUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // PUT: api/UsersDetails/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        [HttpPut]
        [Route("EditUser")]
        public async Task<IActionResult> PutUsers(int id, Users users)
        {
            if (id != users.UsersId)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        // POST: api/UsersDetails
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //EnableCors]
        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult<Users>> PostUsers(Users users)
        {
            try
            {
                _context.Users.Add(users);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetUsers", new { id = users.UsersId }, users);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        // DELETE: api/UsersDetails/5
        //[HttpDelete("{id}")]
        [HttpDelete]
        [Route("DeleteUser")]

        public async Task<ActionResult<Users>> DeleteUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return users;
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UsersId == id);
        }
    }
}
