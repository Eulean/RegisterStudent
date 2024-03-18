using Microsoft.EntityFrameworkCore;
using StudentRegisteration.Models;

namespace StudentRegisteration.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
     : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
}