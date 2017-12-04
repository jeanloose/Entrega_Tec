using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaDeCarros.Models;

namespace LojaDeCarros.Controllers
{
    public class CarrosController : Controller
    {
        // GET: Carros
        public ViewResult Random()
        {
            var carro = new Carro() {
                id = 10,
                marca = "HONDA",
                modelo = "CIVIC",
                ano = "2017"
            };

            return View(carro);
        }
    }
}