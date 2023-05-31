using Microsoft.AspNetCore.Mvc;
using prjNorthWind2.Controllers;
using prjNorthWind2.Models;

namespace prjNorthWind2.Controllers
{
    public class StdController : Controller
    {
        IEmpRepository _repository;

        public StdController(IEmpRepository repository) 
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }
        [HttpPost]
        public IActionResult Index(string keyword)
        {
            var students = _repository.GetAll()
                .Where(m => m.StdCClass.Contains(keyword) || m.StdCName.Contains(keyword) || m.StdEName.Contains(keyword))
                .OrderBy(m => m.StdCClass).ThenBy(m=>m.StdCNum);
            ViewBag.StdCount = $"學生共{students.Count()}筆";
            return View(students);
        }
    }
}
