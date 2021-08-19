using JohnWebApp1.Data;
using JohnWebApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JohnWebApp1.Controllers
{
    public class PoemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PoemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Poems
        public async Task<IActionResult> Index()
        {
            return View(await _context.Poem.ToListAsync());
        }

        // GET: Poems/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poem = await _context.Poem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poem == null)
            {
                return NotFound();
            }

            return View(poem);
        }

        // GET: Poems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Poems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PeomTitle,peom")] Poem poem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(poem);
        }

        // GET: Poems/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poem = await _context.Poem.FindAsync(id);
            if (poem == null)
            {
                return NotFound();
            }
            return View(poem);
        }

        // POST: Poems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,PeomTitle,peom")] Poem poem)
        {
            if (id != poem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoemExists(poem.Id))
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
            return View(poem);
        }

        // GET: Poems/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poem = await _context.Poem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poem == null)
            {
                return NotFound();
            }

            return View(poem);
        }

        // POST: Poems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var poem = await _context.Poem.FindAsync(id);
            _context.Poem.Remove(poem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoemExists(string id)
        {
            return _context.Poem.Any(e => e.Id == id);
        }
    }
}
