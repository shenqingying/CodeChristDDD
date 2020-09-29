using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chirst3D.Appilcation.Interfaces;
using Chirst3D.Appilcation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Christ3D.UI.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentAppService _studentService;
        public StudentController(IStudentAppService studentAppService)
        {
            _studentService = studentAppService;
        }
        public IActionResult Index()
        {
            var test = _studentService.GetAll();
            return View(_studentService.GetAll());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel studentViewModel)
        {
            try 
            {
                // 视图模型验证
                if (!ModelState.IsValid)
                    return View(studentViewModel);
                // 执行添加方法
                _studentService.Register(studentViewModel);
                ViewBag.success = "Studen Registered";
                return View(studentViewModel);
            }
            catch(Exception e) 
            {
                return View(e.Message);
            }
        }
    }
}
