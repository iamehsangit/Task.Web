using Autofac;
using task.Infrastructure.BusinessObjects;
using task.Infrastructure.Services;

namespace task.web.Areas.Admin.Models
{
    public class CourseCreateModel : BaseModel
    {
        public string Title { get; set; }
        public double Fess { get; set; }
        public DateTime ClassStartDate { get; set; }

        private  ICourseServices? _courseServices;

        
        public CourseCreateModel() :base()
        {

        }
        public CourseCreateModel(ICourseServices courseServices)
        {
            _courseServices = courseServices;
        }

        public override void ResolveDependency(ILifetimeScope scope)
        {
           base.ResolveDependency(scope);
            _courseServices=_scope.Resolve<ICourseServices>();
        }
        internal async Task CreateCourse()
        {
            Course course = new Course();
            course.Name = Title;
            course.Fees = Fess;
            course.ClassStartDate = ClassStartDate;

            _courseServices.CreateCourse(course);

        }
    }
}
