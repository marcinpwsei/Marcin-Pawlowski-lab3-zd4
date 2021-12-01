using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zad4.Data;
using Zad4.Models;

namespace Zad4.Controllers
{
    public class StorageListsController : Controller
    {
        private readonly Zad4Context _context;

        public StorageListsController(Zad4Context context)
        {
            _context = context;
        }

        // GET: StorageLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.StorageList.ToListAsync());
        }

        // GET: StorageLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storageList = await _context.StorageList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storageList == null)
            {
                return NotFound();
            }

            return View(storageList);
        }

        // GET: StorageLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StorageLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductName,ValidToDate,Weight,LockerName")] StorageList storageList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storageList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(storageList);
        }

        // GET: StorageLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storageList = await _context.StorageList.FindAsync(id);
            if (storageList == null)
            {
                return NotFound();
            }
            return View(storageList);
        }

        // POST: StorageLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,ValidToDate,Weight,LockerName")] StorageList storageList)
        {
            if (id != storageList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storageList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StorageListExists(storageList.Id))
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
            return View(storageList);
        }

        // GET: StorageLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storageList = await _context.StorageList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (storageList == null)
            {
                return NotFound();
            }

            return View(storageList);
        }

        // POST: StorageLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var storageList = await _context.StorageList.FindAsync(id);
            _context.StorageList.Remove(storageList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StorageListExists(int id)
        {
            return _context.StorageList.Any(e => e.Id == id);
        }
    }
}
