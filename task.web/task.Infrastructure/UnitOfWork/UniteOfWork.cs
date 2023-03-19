using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task.Infrastructure.UnitOfWork
{
    public abstract class UniteOfWork :IUnitOfWork
    {
        protected readonly DbContext _dbContext;

        public UniteOfWork(DbContext dbContext) => _dbContext = dbContext;

        public virtual void Dispose() => _dbContext?.Dispose();
        public virtual void Save() => _dbContext?.SaveChanges();
    }
}
