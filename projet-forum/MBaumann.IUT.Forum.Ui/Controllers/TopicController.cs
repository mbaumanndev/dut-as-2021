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
    public class TopicController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TopicController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Topic
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Topic.Include(t => t.Categorie);
            return View(await applicationDbContext.ToListAsync());
        }

        [Route("categorie/{cleCat}/{cleTop}")]
        public async Task<IActionResult> Afficher(
            string cleCat,
            string cleTop,
            int page = 1,
            int itemsPerPage = 20)
        {
            if (String.IsNullOrWhiteSpace(cleCat)
                || String.IsNullOrWhiteSpace(cleTop))
                return NotFound();

            if (page < 1) page = 1;
            if (itemsPerPage < 10) itemsPerPage = 10;

            var topic = await _context.Topic
                .Include(t => t.Categorie)
                .FirstOrDefaultAsync(t =>
                    t.Cle == cleTop
                    && t.Categorie.Cle == cleCat
                );

            if (topic == null)
                return NotFound();

            var baseQuery = _context.Sujet.Where(
                s => s.TopicId == topic.Id
             );

            var totalPages = Math.Ceiling(baseQuery.Count() / (double)itemsPerPage);

            if (page > totalPages)
                return NotFound();

            var sujets = baseQuery
                .OrderBy(s => s.Id)
                .Skip((page -1) * itemsPerPage)
                .Take(itemsPerPage);

            var model = new TopicViewModel
            {
                Topic = topic,
                Sujets = sujets.ToList(),
            };

            return View(model);
        }

        // GET: Topic/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topic
                .Include(t => t.Categorie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        // GET: Topic/Create
        public IActionResult Create()
        {
            ViewData["CategorieId"] = new SelectList(_context.Categorie, "Id", "Cle");
            return View();
        }

        // POST: Topic/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategorieId,Nom,Description,Cle,Ordre,Creation,Modification")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(topic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategorieId"] = new SelectList(_context.Categorie, "Id", "Cle", topic.CategorieId);
            return View(topic);
        }

        // GET: Topic/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topic.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }
            ViewData["CategorieId"] = new SelectList(_context.Categorie, "Id", "Cle", topic.CategorieId);
            return View(topic);
        }

        // POST: Topic/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategorieId,Nom,Description,Cle,Ordre,Creation,Modification")] Topic topic)
        {
            if (id != topic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(topic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopicExists(topic.Id))
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
            ViewData["CategorieId"] = new SelectList(_context.Categorie, "Id", "Cle", topic.CategorieId);
            return View(topic);
        }

        // GET: Topic/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topic
                .Include(t => t.Categorie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        // POST: Topic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var topic = await _context.Topic.FindAsync(id);
            _context.Topic.Remove(topic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TopicExists(int id)
        {
            return _context.Topic.Any(e => e.Id == id);
        }
    }
}
