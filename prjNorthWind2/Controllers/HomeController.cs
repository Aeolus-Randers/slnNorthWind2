using Microsoft.AspNetCore.Mvc;
using prjNorthWind2.Models;
namespace prjNorthWind2.Controllers
{
    public class HomeController : Controller
    {
        ICustomerRepository _repository;
        public HomeController(ICustomerRepository repository) 
        {
            _repository= repository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }
        //[HttpPost]
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
