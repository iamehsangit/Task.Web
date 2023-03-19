using task.Infrastructure.Repositories;

namespace task.Infrastructure.UnitOfWork
{
    public interface IApplicationUnitOfWork :IUnitOfWork
    {
        ICourseRepository Courses { get; }
    }
}