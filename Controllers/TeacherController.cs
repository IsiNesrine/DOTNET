using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models;

public class TeacherController : Controller
{
    private readonly ApplicationDbContext _context;

    public TeacherController(ApplicationDbContext context)
    {
        _context = context;
    }

    public ActionResult Index()
    {
        var teachers = _context.Accounts;
        return View(teachers);
    }
    public async Task<IActionResult> ShowDetails(string? id)
    {
        if (id == null) return NotFound();

        var teacher = await _context.Accounts
            .FirstOrDefaultAsync(m => m.Id == id);
        if (teacher == null) return NotFound();

        return View();
    }

    // GET: /Add
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }


    // POST: /Add
    [HttpPost]
    public async Task<IActionResult> Add(Teacher teacher)
    {
        if (!ModelState.IsValid)
        {
            _context.Add(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(teacher);
    }

    // GET: /Delete/Id
    public async Task<IActionResult> Delete(string? id)
    {
        if (id == null) return NotFound();

        var teacher = await _context.Accounts
            .FirstOrDefaultAsync(m => m.Id == id);
        if (teacher == null) return NotFound();

        return View();
    }

    // POST: Students/Delete/Id
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var teacher = await _context.Accounts.FindAsync(id);
        _context.Accounts.Remove(teacher);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: Students/Edit/Id
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var teacher = await _context.Accounts.FindAsync(id);
        if (teacher == null) return NotFound();

        return View();
    }

    // POST: Students/Edit/ID
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, Teacher teacher)
    {
        if (id != teacher.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(teacher);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(teacher.Id)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(teacher);
    }

    private bool TeacherExists(string id)
    {
        return _context.Accounts.Any(e => e.Id == id);
    }
}

