using Autofac;
using task.Infrastructure.Services;
using task.web.Models;

namespace task.web.Areas.Admin.Models
{
    public class CourseListModel :BaseModel 
    {
        private ICourseServices? _courseServices;

        public CourseListModel()
        {

        }
        public CourseListModel(ICourseServices courseServices)
        {
            _courseServices = courseServices;
        }

        public override void ResolveDependency(ILifetimeScope scope)
        {
            base.ResolveDependency(scope);
            _courseServices= _scope.Resolve<ICourseServices>();
        }
        internal object? GetPagedCourses(DataTablesAjaxRequestModel model)
        {
            var data = _courseServices.GetCourses(
                model.PageIndex,
                model.PageSize,
                model.SearchText,
                model.GetSortText(new string[] { "Title", "Fees", "ClassStartDate" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Name,
                                record.Fees.ToString(),
                                record.ClassStartDate.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }
    }
}
