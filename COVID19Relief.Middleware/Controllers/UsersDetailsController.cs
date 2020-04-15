using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COVID19Relief.Middleware.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using COVID19Relief.Middleware.Extensions;

namespace COVID19Relief.Middleware.Controllers
{
    [EnableCors()]
    [Route("api/Users/")]
    [ApiController]
    public class UsersDetailsController : ControllerBase
    {
        private readonly COVONENINEContext _context;
        private readonly ILogger<UsersDetailsController> _logger;


        public UsersDetailsController(COVONENINEContext context, ILogger<UsersDetailsController> Logger)
        {
            _context = context;
            _logger = Logger;
        }

        [HttpGet]

        // GET: Users
        [Route("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(string UserName, string Password)
        {
            try
            {
                var user = _context.Users.SingleOrDefault(x => x.Email == UserName);



                // check if username exists
                if (user == null)
                    return BadRequest("user does not exist");

                // check if password is correct
                if (!VerifyPasswordHash(Password, user.PasswordHash, user.PasswordSalt))
                    return BadRequest("user name and password error");

                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }

        }




        [AllowAnonymous]
        [HttpPost("GenerateOTP")]
        public ActionResult GenerateOTP(string email)
        {
            Random rnd = new Random();
            var randomNumber = rnd.Next(100000, 999999).ToString();

            _context.OtpTable.Add(new OtpTable { UserEmail = email, Code = randomNumber, DateInserted = DateTime.Now, IsActive = true });
            _context.SaveChanges();

            Email.Send(email, email, "Relief Register OTP", "verify your email with the code below <br><br>" + randomNumber);
            return Ok(true);
        }

        [AllowAnonymous]
        [HttpPost("VerifyOTP")]
        public ActionResult VerifyOTP(string email, string code)
        {
            var otp = _context.OtpTable.Where(x => x.UserEmail.Equals(email) && x.Code.Equals(code) && x.IsActive.Equals(true)).FirstOrDefault();

            if (otp != null)
            {

                otp.IsActive = false;
                otp.DateOtpverified = DateTime.Now;
                _context.Entry(otp).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(true);
            }
            else
            {
               return BadRequest(false);
            }
        }


        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
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

        // GET: api/UsersDetails/5
        [HttpGet]
        [Route("GetUserDetailsByEmail")]
        public async Task<ActionResult<Users>> GetUsersByEmail(string email)
        {
            var users = await _context.Users.Where(x=>x.Email==email).FirstOrDefaultAsync();

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

        // PUT: api/UsersDetails/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        [HttpPut]
        [Route("EditUserByEmail")]
        public async Task<IActionResult> PutUsersByEmail(string email, Users users)
        {
            if (email != users.Email)
            {
                return BadRequest();
            }

            if (!UsersExistsByEmail(email))
            {
                return BadRequest("User does not exist");

            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExistsByEmail(email))
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




        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        // POST: api/UsersDetails
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //EnableCors]
        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult<Users>> PostUsers(Users users, string password)
        {
            try
            {
                _logger.LogInformation($" got users {Newtonsoft.Json.JsonConvert.SerializeObject(users)}");

                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                _context.Users.Add(users);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetUsers", new { id = users.UsersId }, users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
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

        private bool UsersExistsByEmail(string email)
        {
            return _context.Users.Any(e => e.Email == email);
        }
    }
}
