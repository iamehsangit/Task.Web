﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task.Infrastructure.DbContexts;
using task.Infrastructure.Entities;

namespace task.Infrastructure.Repositories
{
    public class CourseRepository : Repository<Course, Guid>,ICourseRepository
    {
        public CourseRepository(IApplicationDbContext context) : base((DbContext)context)
        {

        }

        public (IList<Course> data, int total, int totalDisplay) GetCourses(int pageIndex, int pageSize, string searchText, string orderby)
        {
            (IList<Course> data, int total, int totalDisplay) results =
                GetDynamic(x => x.Title.Contains(searchText), orderby,
                "", pageIndex, pageSize, true);

            return results;
        }
    }
}
