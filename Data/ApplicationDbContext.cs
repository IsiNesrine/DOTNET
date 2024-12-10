using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
}