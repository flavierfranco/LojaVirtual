using Microsoft.AspNetCore.Mvc;

namespace BlueModas.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult CarrinhoCompras()
        {
            return View();
        }
    }
}