using LMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Course> Courses => Set<Course>();
}
