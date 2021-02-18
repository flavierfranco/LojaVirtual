using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlueModas.Controllers
{
    public class ErroController : Controller
    {
        [Route("/Erro/Erro{numero}")]
        public IActionResult ErroGenerico(int numero)
        {
            return View(numero);
        }
        public IActionResult Erro404()
        {
            return View();
        }
        public IActionResult Erro403()
        {
            return View();
        }
        public IActionResult Erro500()
        {
            return View();
        }
    }
}