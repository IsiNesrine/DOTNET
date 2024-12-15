
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Data;

public class ApplicationDbContext : IdentityDbContext<Account>
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Inscription> Inscriptions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Account>(entity => { entity.ToTable("Accounts"); });
        builder.Entity<Inscription>()
    .HasOne(i => i.student)
    .WithMany()
    .HasForeignKey(i => i.StudentId);

    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}

