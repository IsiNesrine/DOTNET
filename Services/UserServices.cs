using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models;

namespace mvc.Services
{
    public class UserService
    {
        private readonly UserManager<Account> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;

        public UserService(UserManager<Account> userManager, IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public async Task<bool> IsTeacherAsync()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            if (user == null)
            {
                return false;
            }

            return user?.UserType == AllowedLevel.TEACHER;
        }


        public async Task<bool> IsUserInscribedAsync(int eventId)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            if (user == null)
            {
                return false;
            }
            return await _context.Inscriptions.AnyAsync(i => i.EventId == eventId && i.StudentId == user.Id);
        }

        public async Task<List<Student>> GetStudentsInscribedAsync(int eventId)
        {
            return await _context.Inscriptions
                .Include(i => i.student)
                .Where(i => i.EventId == eventId)
                .Select(i => i.student)
                .ToListAsync();
        }

    }
}
