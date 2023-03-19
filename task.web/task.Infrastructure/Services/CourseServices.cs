using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task.Infrastructure.UnitOfWork;
using CourseBO = task.Infrastructure.BusinessObjects.Course;
using CourseEO = task.Infrastructure.Entities.Course;

namespace task.Infrastructure.Services
{
    public class CourseServices : ICourseServices
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        public CourseServices(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }
        public void CreateCourse(CourseBO course)
        {
            CourseEO CourseEntity = new CourseEO();
            CourseEntity.Title = course.Name;
            CourseEntity.Fees = course.Fees;
            CourseEntity.ClassStartDate = course.ClassStartDate;

            _applicationUnitOfWork.Courses.Add(CourseEntity);
            _applicationUnitOfWork.Save();
        }

        public (int total,int totalDisplay,IList<CourseBO> records) GetCourses(int pageIndex,
            int pageSize,string searchText,string orderby)
        {
            (IList<CourseEO> data, int total, int totalDisplay) results = _applicationUnitOfWork.Courses.GetCourses(pageIndex, pageSize, searchText, orderby);
            IList<CourseBO> courses =new List<CourseBO>();
            foreach(CourseEO courseEO in results.data)
            {
                courses.Add(new CourseBO { 
                    Id=courseEO.Id,
                    Name=courseEO.Title,
                    Fees=courseEO.Fees,
                    ClassStartDate=courseEO.ClassStartDate
                });
            }
            return (results.total, results.totalDisplay, courses);
        }
    }
}
