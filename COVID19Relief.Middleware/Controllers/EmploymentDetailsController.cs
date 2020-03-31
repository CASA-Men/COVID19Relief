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
    public class EmploymentDetailsController : Controller
    {
        private readonly COVONENINEContext _context;

        public EmploymentDetailsController(COVONENINEContext context)
        {
            _context = context;
        }

        // GET: EmploymentDetails
        public async Task<IActionResult> Index()
        {
            var cOVONENINEContext = _context.EmploymentDetails.Include(e => e.Users);
            return View(await cOVONENINEContext.ToListAsync());
        }

        // GET: EmploymentDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employmentDetails = await _context.EmploymentDetails
                .Include(e => e.Users)
                .FirstOrDefaultAsync(m => m.EmploymentDetailsId == id);
            if (employmentDetails == null)
            {
                return NotFound();
            }

            return View(employmentDetails);
        }

        // GET: EmploymentDetails/Create
        public IActionResult Create()
        {
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "AccountNumber");
            return View();
        }

        // POST: EmploymentDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmploymentDetailsId,UsersId,OrganizationName,OrganizationAddress,OrganizationType,PositionHeld,EmploymentType,EmploymentStatus,EmploymentDate,LastDayAtJob,Stateid,CreatedOn")] EmploymentDetails employmentDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employmentDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "AccountNumber", employmentDetails.UsersId);
            return View(employmentDetails);
        }

        // GET: EmploymentDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employmentDetails = await _context.EmploymentDetails.FindAsync(id);
            if (employmentDetails == null)
            {
                return NotFound();
            }
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "AccountNumber", employmentDetails.UsersId);
            return View(employmentDetails);
        }

        // POST: EmploymentDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmploymentDetailsId,UsersId,OrganizationName,OrganizationAddress,OrganizationType,PositionHeld,EmploymentType,EmploymentStatus,EmploymentDate,LastDayAtJob,Stateid,CreatedOn")] EmploymentDetails employmentDetails)
        {
            if (id != employmentDetails.EmploymentDetailsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employmentDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmploymentDetailsExists(employmentDetails.EmploymentDetailsId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "AccountNumber", employmentDetails.UsersId);
            return View(employmentDetails);
        }

        // GET: EmploymentDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employmentDetails = await _context.EmploymentDetails
                .Include(e => e.Users)
                .FirstOrDefaultAsync(m => m.EmploymentDetailsId == id);
            if (employmentDetails == null)
            {
                return NotFound();
            }

            return View(employmentDetails);
        }

        // POST: EmploymentDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employmentDetails = await _context.EmploymentDetails.FindAsync(id);
            _context.EmploymentDetails.Remove(employmentDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmploymentDetailsExists(int id)
        {
            return _context.EmploymentDetails.Any(e => e.EmploymentDetailsId == id);
        }
    }
}
