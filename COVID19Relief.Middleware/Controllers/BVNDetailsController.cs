using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COVID19Relief.Middleware.Model;

namespace COVID19Relief.Middleware.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class BVNDetailsController : ControllerBase
    {
        private readonly COVONENINEContext _context;

        public BVNDetailsController(COVONENINEContext context)
        {
            _context = context;
        }

        // GET: BVNDetails
        [HttpGet]
        [Route("GetAllBVNDetails")]
        public async Task<IActionResult> Index()
        {
            var cOVONENINEContext = _context.Bvndetails.Include(b => b.User);
            return Ok(await cOVONENINEContext.ToListAsync());
        }

        // GET: BVNDetails/Details/5
        [HttpGet]
        [Route("GetBVNDetails")]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bvndetails = await _context.Bvndetails
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BvndetailsId == id);
            if (bvndetails == null)
            {
                return NotFound();
            }

            return Ok(bvndetails);
        }

        //// GET: BVNDetails/Create
        //public IActionResult Create()
        //{
        //    ViewData["UserId"] = new SelectList(_context.Users, "UsersId", "AccountNumber");
        //    return View();
        //}

        // POST: BVNDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("CreateBVNDetails")]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BvndetailsId,UserId,FirstName,MiddleName,LastName,DateOfBirth,RegistrationDate,EnrollmentBank,Email,PhoneNumber,Gender,LgaofOrigin,LgaofResidence,Nationality,PhoneNumberAlt,ResidentialAddress,StateOfOrigin,StateOfResidence,WatchListed,CreatedOn")] Bvndetails bvndetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bvndetails);
                await _context.SaveChangesAsync();
                return Ok(true);
            }
            //ViewData["UserId"] = new SelectList(_context.Users, "UsersId", "AccountNumber", bvndetails.UserId);
            return Ok(false);
        }

        //// GET: BVNDetails/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var bvndetails = await _context.Bvndetails.FindAsync(id);
        //    if (bvndetails == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Users, "UsersId", "AccountNumber", bvndetails.UserId);
        //    return View(bvndetails);
        //}

        // POST: BVNDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("EditBVNDetails")]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BvndetailsId,UserId,FirstName,MiddleName,LastName,DateOfBirth,RegistrationDate,EnrollmentBank,Email,PhoneNumber,Gender,LgaofOrigin,LgaofResidence,Nationality,PhoneNumberAlt,ResidentialAddress,StateOfOrigin,StateOfResidence,WatchListed,CreatedOn")] Bvndetails bvndetails)
        {
            if (id != bvndetails.BvndetailsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bvndetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BvndetailsExists(bvndetails.BvndetailsId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(true);
            }
            //ViewData["UserId"] = new SelectList(_context.Users, "UsersId", "AccountNumber", bvndetails.UserId);
            return Ok(false);
        }

        // GET: BVNDetails/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var bvndetails = await _context.Bvndetails
        //        .Include(b => b.User)
        //        .FirstOrDefaultAsync(m => m.BvndetailsId == id);
        //    if (bvndetails == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(bvndetails);
        //}

        // POST: BVNDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("DeleteBVNDetails")]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bvndetails = await _context.Bvndetails.FindAsync(id);
            _context.Bvndetails.Remove(bvndetails);
            await _context.SaveChangesAsync();
            return Ok(true);
        }

        private bool BvndetailsExists(int id)
        {
            return _context.Bvndetails.Any(e => e.BvndetailsId == id);
        }
    }
}
