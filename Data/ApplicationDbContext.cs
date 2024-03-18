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
    public DbSet<Address> addresses { get; set; }
    public DbSet<CourseOffering> CourseOfferings { get; set; }
    public DbSet<Registeration> Registerations { get; set; }
    public DbSet<StudentDetails> StudentDetails { get; set; }
}