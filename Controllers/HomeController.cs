using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models;


public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {

        var events = await _context.Events
            .FromSqlRaw("SELECT TOP 3 * FROM Events WHERE EventDate >= GETDATE() ORDER BY EventDate ASC")
            .ToListAsync();

        return View(events);
    }
}
