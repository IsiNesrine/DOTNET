using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models;

namespace mvc.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;


        // Constructeur 
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ShowDetails(int? id)
        {
            if (id == null) return NotFound();
            var student = _context.Accounts.Find(id);
            if (student == null) return NotFound();

            return View(student);
        }

        // GET: Students/Add
        public IActionResult Add()
        {
            return View();
        }


        // POST: Students/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/Id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var student = _context.Accounts.Find(id);
            if (student == null) return NotFound();

            return View(student);
        }

        // POST: Students/Delete/Id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Accounts.FindAsync(id);
            _context.Accounts.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Students/Edit/Id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Accounts.FindAsync(id);
            if (student == null) return NotFound();

            return View(student);
        }

        // POST: Students/Edit/ID
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        private bool StudentExists(int id)
        {
            var student = _context.Accounts.Find(id);
            return _context.Accounts.Any(e => e.Id == student.Id);
        }

        // Get students
        public async Task<ActionResult> Index()
        {
            return View(await _context.Accounts.ToListAsync());
        }

    }
}
