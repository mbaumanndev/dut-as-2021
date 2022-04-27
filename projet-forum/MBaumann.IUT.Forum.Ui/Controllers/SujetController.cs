#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MBaumann.IUT.Forum.Ui.Data;
using MBaumann.IUT.Forum.Ui.Models;

namespace MBaumann.IUT.Forum.Ui.Controllers
{
    public class SujetController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SujetController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sujet
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sujet.Include(s => s.Topic);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sujet/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sujet = await _context.Sujet
                .Include(s => s.Topic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sujet == null)
            {
                return NotFound();
            }

            return View(sujet);
        }

        // GET: Sujet/Create
        public IActionResult Create()
        {
            ViewData["TopicId"] = new SelectList(_context.Topic, "Id", "Cle");
            return View();
        }

        // POST: Sujet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TopicId,Nom,Suppression,Creation,Modification")] Sujet sujet)
        {
            if (ModelState.IsValid)
            {
                sujet.Id = Guid.NewGuid();
                _context.Add(sujet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TopicId"] = new SelectList(_context.Topic, "Id", "Cle", sujet.TopicId);
            return View(sujet);
        }

        // GET: Sujet/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sujet = await _context.Sujet.FindAsync(id);
            if (sujet == null)
            {
                return NotFound();
            }
            ViewData["TopicId"] = new SelectList(_context.Topic, "Id", "Cle", sujet.TopicId);
            return View(sujet);
        }

        // POST: Sujet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,TopicId,Nom,Suppression,Creation,Modification")] Sujet sujet)
        {
            if (id != sujet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sujet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SujetExists(sujet.Id))
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
            ViewData["TopicId"] = new SelectList(_context.Topic, "Id", "Cle", sujet.TopicId);
            return View(sujet);
        }

        // GET: Sujet/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sujet = await _context.Sujet
                .Include(s => s.Topic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sujet == null)
            {
                return NotFound();
            }

            return View(sujet);
        }

        // POST: Sujet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var sujet = await _context.Sujet.FindAsync(id);
            _context.Sujet.Remove(sujet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SujetExists(Guid id)
        {
            return _context.Sujet.Any(e => e.Id == id);
        }
    }
}
