using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CuaHangDoGiaDung.Data;
using CuaHangDoGiaDung.Models;

namespace CuaHangDoGiaDung.Controllers
{
    public class DoGiaDungsController : Controller
    {
        private readonly CuaHangDoGiaDungContext _context;

        public DoGiaDungsController(CuaHangDoGiaDungContext context)
        {
            _context = context;
        }

        // GET: DoGiaDungs
        public async Task<IActionResult> Index(string searchString)
        {
            var DoGiaDung = from b in _context.DoGiaDung
                        select b;
            if (!String.IsNullOrEmpty(searchString))
            {
                DoGiaDung = DoGiaDung.Where(s => s.Title!.Contains(searchString));
            }
            return View(await DoGiaDung.ToListAsync());
        }


        // GET: DoGiaDungs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doGiaDung = await _context.DoGiaDung
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doGiaDung == null)
            {
                return NotFound();
            }

            return View(doGiaDung);
        }

        // GET: DoGiaDungs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DoGiaDungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre,Price")] DoGiaDung doGiaDung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doGiaDung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doGiaDung);
        }

        // GET: DoGiaDungs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doGiaDung = await _context.DoGiaDung.FindAsync(id);
            if (doGiaDung == null)
            {
                return NotFound();
            }
            return View(doGiaDung);
        }

        // POST: DoGiaDungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,Price")] DoGiaDung doGiaDung)
        {
            if (id != doGiaDung.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doGiaDung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoGiaDungExists(doGiaDung.Id))
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
            return View(doGiaDung);
        }

        // GET: DoGiaDungs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doGiaDung = await _context.DoGiaDung
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doGiaDung == null)
            {
                return NotFound();
            }

            return View(doGiaDung);
        }

        // POST: DoGiaDungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doGiaDung = await _context.DoGiaDung.FindAsync(id);
            _context.DoGiaDung.Remove(doGiaDung);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoGiaDungExists(int id)
        {
            return _context.DoGiaDung.Any(e => e.Id == id);
        }
    }
}
