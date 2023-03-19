using Microsoft.EntityFrameworkCore;
using task.Infrastructure.Entities;

namespace task.Infrastructure.DbContexts
{
    public interface IApplicationDbContext
    {
        DbSet<Course> Courses { get; set; }
    }
}