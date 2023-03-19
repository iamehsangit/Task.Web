using Autofac;
using Microsoft.AspNetCore.Mvc;
using task.web.Areas.Admin.Models;
using task.web.Models;

namespace task.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger _logger;
        public CourseController(ILogger<CourseController> logger,ILifetimeScope scope)
        {
            _scope = scope;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            CourseCreateModel model = _scope.Resolve<CourseCreateModel>();
            return View(model);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseCreateModel model)
        {
            if (ModelState.IsValid)
            {
                model.ResolveDependency(_scope);
                await model.CreateCourse();
            }
            return View(model);
        }

         public JsonResult GetCourseData()
        {
            var dataTableModel = new DataTablesAjaxRequestModel(Request);
            var model = _scope.Resolve<CourseListModel>();
            return Json(model.GetPagedCourses(dataTableModel));
        }
    }
}
