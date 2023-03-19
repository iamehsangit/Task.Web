using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task.Infrastructure.DbContexts;
using task.Infrastructure.Repositories;

namespace task.Infrastructure.UnitOfWork
{
    public class ApplicationUnitOfWork : UniteOfWork, IApplicationUnitOfWork
    {
        public ICourseRepository Courses { get; private set; }
        public ApplicationUnitOfWork(IApplicationDbContext dbContext,
            ICourseRepository courseRepository) : base((DbContext)dbContext)
        {
            Courses = courseRepository;
        }
    }
}
