using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab2_VanMinhThuc.Models;
using System.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Data.SqlClient;

namespace Lab2_VanMinhThuc.Controllers
{
    public class DeviceController : Controller
    {
        private readonly DeviceDbContext _context;

        public DeviceController(DeviceDbContext context)
        {
            _context = context;
        }

        // GET: Device
        public async Task<IActionResult> Index(String sortBy)
        {
            var devices = from d in _context.Device.Include(d => d.Category)
                          select d;
            switch (sortBy)
            {
                case "Device_ID":
                    devices = devices.OrderBy(d => d.Device_Code);  // Sắp xếp theo Status (từ nhỏ đến lớn)
                    break;
                case "Deivce_Name":
                    devices = devices.OrderBy(d => d.Device_Name);  // Sắp xếp theo Status (từ nhỏ đến lớn)
                    break;
                case "Status":
                    devices = devices.OrderBy(d => d.Status);  // Sắp xếp theo Status (từ nhỏ đến lớn)
                    break;
                case "Category":
                    devices = devices.OrderBy(d => d.Category.Category_Name);  // Sắp xếp theo Category (từ nhỏ đến lớn)
                    break;
                default:
                    devices = devices.OrderBy(d => d.Device_Code);  // Mặc định sắp xếp theo Device_Code
                    break;
            }

            return View(await devices.ToListAsync());

            //var sortedDevices = await _context.Device.Include(d => d.Category)
            //    .OrderBy(d => d.Category.Category_Name)
            //    .ToListAsync();

            //return View(sortedDevices);
        }
       [HttpPost]
        public async Task<IActionResult> Search(string optionChoose,string searchString)
        {
            if (searchString.IsNullOrEmpty())
            {
                return RedirectToAction(nameof(Index));
            }
            var devices = from d in _context.Device.Include(d => d.Category)
                          select d;

            var parInt = int.Parse(searchString);
            
            if (optionChoose.Equals("Search By Code"))
            {
                devices = devices.Where(d => d.Device_Code == (parInt));
            }
            else { devices = devices.Where(d => d.Device_Name.Contains(searchString)); }





            return View(await devices.ToListAsync());
        }

        // GET: Device/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["Category_ID"] = new SelectList(_context.Category, "Category_ID", "Category_Name");
            var device = await _context.Device
                .Include(d => d.Category)
                .FirstOrDefaultAsync(m => m.Device_Code == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // GET: Device/Create
        public IActionResult Create()
        {
            ViewData["StatusList"] = new SelectList(new[] { "In Use", "Broken", "Under maintenance" });
            ViewData["Category_ID"] = new SelectList(_context.Category, "Category_ID", "Category_Name");
            return View();

        }

        // POST: Device/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Device_Name,Category_ID,Status,Date_Of_Entry")] Device device)
        {
            //if (ModelState.IsValid)
            //{
                _context.Add(device);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            ViewData["Category_ID"] = new SelectList(_context.Category, "Category_ID", "Category_ID", device.Category_ID);
            return View(device);
        }

        // GET: Device/Edit/5
       public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Device.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }
            ViewData["StatusList"] = new SelectList(new[] { "In Use", "Broken", "Under maintenance" });
            ViewData["Category_ID"] = new SelectList(_context.Category, "Category_ID", "Category_Name", device.Category_ID);
            return View(device);
        }




        // POST: Device/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Device_Code,Device_Name,Category_ID,Status,Date_Of_Entry")] Device device)
        {
            if (id != device.Device_Code)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(device);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceExists(device.Device_Code))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            //}
            ViewData["Category_ID"] = new SelectList(_context.Category, "Category_ID", "Category_ID", device.Category_ID);
            return View(device);
        }

        // GET: Device/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Device
                .Include(d => d.Category)
                .FirstOrDefaultAsync(m => m.Device_Code == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // POST: Device/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var device = await _context.Device.FindAsync(id);
            if (device != null)
            {
                _context.Device.Remove(device);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceExists(int id)
        {
            return _context.Device.Any(e => e.Device_Code == id);
        }
    }
}
