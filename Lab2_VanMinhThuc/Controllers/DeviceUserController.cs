using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab2_VanMinhThuc.Models;

namespace Lab2_VanMinhThuc.Controllers
{
    public class DeviceUserController : Controller
    {
        private readonly DeviceDbContext _context;

        public DeviceUserController(DeviceDbContext context)
        {
            _context = context;
        }

        // GET: DeviceUser
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeviceUser.ToListAsync());
        }

        // GET: DeviceUser/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceUser = await _context.DeviceUser
                .FirstOrDefaultAsync(m => m.User_ID == id);
            if (deviceUser == null)
            {
                return NotFound();
            }

            return View(deviceUser);
        }

        // GET: DeviceUser/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeviceUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("User_ID,User_Name,User_Email,User_Phone")] DeviceUser deviceUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deviceUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deviceUser);
        }

        // GET: DeviceUser/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceUser = await _context.DeviceUser.FindAsync(id);
            if (deviceUser == null)
            {
                return NotFound();
            }
            return View(deviceUser);
        }

        // POST: DeviceUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("User_ID,User_Name,User_Email,User_Phone")] DeviceUser deviceUser)
        {
            if (id != deviceUser.User_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deviceUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceUserExists(deviceUser.User_ID))
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
            return View(deviceUser);
        }

        // GET: DeviceUser/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceUser = await _context.DeviceUser
                .FirstOrDefaultAsync(m => m.User_ID == id);
            if (deviceUser == null)
            {
                return NotFound();
            }

            return View(deviceUser);
        }

        // POST: DeviceUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deviceUser = await _context.DeviceUser.FindAsync(id);
            if (deviceUser != null)
            {
                _context.DeviceUser.Remove(deviceUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceUserExists(int id)
        {
            return _context.DeviceUser.Any(e => e.User_ID == id);
        }
    }
}
