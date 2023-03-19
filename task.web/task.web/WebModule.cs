using Autofac;
using task.web.Areas.Admin.Models;
using task.web.Models;

namespace task.web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CourseCreateModel>().AsSelf();
            builder.RegisterType<CourseListModel>().AsSelf();
            base.Load(builder);
        }
    }
}
 