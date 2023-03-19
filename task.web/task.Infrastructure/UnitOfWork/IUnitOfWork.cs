using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace task.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}