using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Data;

public class IdentityDbContext : DbContext
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
    {

    }
}