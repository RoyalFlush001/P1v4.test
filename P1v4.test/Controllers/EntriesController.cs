using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P1v4.test.Data;
using P1v4.test.Models;

namespace P1v4.test.Controllers
{
    public class EntriesController : Controller
    {
        private readonly P1v4testContext _context;

        public EntriesController(P1v4testContext context)
        {
            _context = context;
        }

        // GET: Entries
        public async Task<IActionResult> Index()
        {
            var p1v4testContext = _context.Entry.Include(e => e.User);
            return View(await p1v4testContext.ToListAsync());
        }

        // GET: Entries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entry
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.EntryID == id);
            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // GET: Entries/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "UserID");
            return View();
        }

        // POST: Entries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntryID,Fecha,HE,HE_A,HS_A,HS,UserID")] Entry entry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "UserID", entry.UserID);
            return View(entry);
        }

        // GET: Entries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entry.FindAsync(id);
            if (entry == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "UserID", entry.UserID);
            return View(entry);
        }

        // POST: Entries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EntryID,Fecha,HE,HE_A,HS_A,HS,UserID")] Entry entry)
        {
            if (id != entry.EntryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntryExists(entry.EntryID))
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
            ViewData["UserID"] = new SelectList(_context.User, "UserID", "UserID", entry.UserID);
            return View(entry);
        }

        // GET: Entries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entry
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.EntryID == id);
            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // POST: Entries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entry = await _context.Entry.FindAsync(id);
            _context.Entry.Remove(entry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntryExists(int id)
        {
            return _context.Entry.Any(e => e.EntryID == id);
        }
    }
}
