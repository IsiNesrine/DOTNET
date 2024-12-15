using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models;
using mvc.Services;

namespace mvc.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserService _userService;
        private readonly UserManager<Account> _userManager;

        public EventController(ApplicationDbContext context, UserService userService, UserManager<Account> userManager)
        {
            _context = context;
            _userService = userService;
            _userManager = userManager;
        }

        // Liste des événements
        public async Task<IActionResult> Index()
        {
            var events = await _context.Events.ToListAsync();
            return View(events);
        }

        // Détails d'un événement
        public async Task<IActionResult> ShowDetails(int id)
        {
            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem == null)
            {
                return NotFound();
            }

            var students = await _userService.GetStudentsInscribedAsync(id);
            ViewBag.Students = students;

            return View(eventItem);
        }

        // Ajouter un événement (GET)
        [Authorize(Roles = "Teacher")] // Autorisation réservée aux enseignants
        public IActionResult Add()
        {
            return View();
        }

        // Ajouter un événement (POST)
        [HttpPost]
        [Authorize(Roles = "Teacher")] // Autorisation réservée aux enseignants
        public async Task<IActionResult> Add(Event newEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(newEvent);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Événement créé avec succès.";
                return RedirectToAction("Index");
            }
            return View(newEvent);
        }

        // Supprimer un événement
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingEvent = await _context.Events.FindAsync(id);
            if (existingEvent == null)
            {
                return NotFound();
            }

            _context.Events.Remove(existingEvent);
            await _context.SaveChangesAsync();
            TempData["Message"] = "Événement supprimé avec succès.";
            return RedirectToAction("Index");
        }

        // Modifier un événement (GET)
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Update(int id)
        {
            var currentEvent = await _context.Events.FindAsync(id);
            if (currentEvent == null)
            {
                return NotFound();
            }

            return View(currentEvent);
        }

        // Modifier un événement (POST)
        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Update(Event currentEvent)
        {
            var eventToUpdate = await _context.Events.FindAsync(currentEvent.Id);
            if (eventToUpdate == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                eventToUpdate.Title = currentEvent.Title;
                eventToUpdate.Description = currentEvent.Description;
                eventToUpdate.EventDate = currentEvent.EventDate;
                eventToUpdate.MaxParticipants = currentEvent.MaxParticipants;
                eventToUpdate.Location = currentEvent.Location;

                await _context.SaveChangesAsync();
                TempData["Message"] = "Événement modifié avec succès.";
                return RedirectToAction("Index");
            }

            return View(currentEvent);
        }

        // Inscription à un événement
        [HttpPost]
        public async Task<IActionResult> Inscription(int eventId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var existingInscription = await _context.Inscriptions
                .FirstOrDefaultAsync(i => i.EventId == eventId && i.StudentId == user.Id);

            if (existingInscription == null)
            {
                // Ajouter une nouvelle inscription
                var inscription = new Inscription
                {
                    EventId = eventId,
                    StudentId = user.Id
                };

                _context.Inscriptions.Add(inscription);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Vous êtes inscrit à l'événement.";
            }
            else
            {
                TempData["Message"] = "Vous êtes déjà inscrit à cet événement.";
            }

            return RedirectToAction("Index");
        }


        // Désinscription d'un événement
        [HttpPost]
        public async Task<IActionResult> Desinscription(int eventId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var inscription = await _context.Inscriptions
                .FirstOrDefaultAsync(i => i.EventId == eventId && i.StudentId == user.Id);

            if (inscription != null)
            {
                _context.Inscriptions.Remove(inscription);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Vous êtes désinscrit de l'événement.";
            }
            else
            {
                TempData["Message"] = "Vous n'êtes pas inscrit à cet événement.";
            }

            return RedirectToAction("Index");
        }

    }
}
