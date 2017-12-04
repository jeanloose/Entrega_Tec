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
        private ApplicationDbContext _context;

        public CarrosController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var carros = _context.Carros.ToList();

            return View(carros);
        }
        public ActionResult Details(int id)
        {
            var carros = _context.Carros.SingleOrDefault(c => c.Id == id);
            if (carros == null)
            {
                return HttpNotFound();
            }

            return View(carros);
        }

        public ActionResult New()
        {
            var carros = new Carro();

            return View("CarroForm", carros);
        }

        [HttpPost] 

        public ActionResult Save(Carro carros)
        {

            if (!ModelState.IsValid)
            {
                return View("CarroForm", carros);
            }

            if (carros.Id == 0)
            {
                
                _context.Carros.Add(carros);
            }
            else
            {
                var carrosInDb = _context.Carros.Single(c => c.Id == carros.Id);

                carrosInDb.Marca = carros.Marca;
                carrosInDb.Modelo = carros.Modelo;
                carrosInDb.Ano = carros.Ano;

            }

            
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var carros = _context.Carros.SingleOrDefault(c => c.Id == id);

            if (carros == null)
                return HttpNotFound();


            return View("CarroForm", carros);
        }

        public ActionResult Delete(int id)
        {
            var carros = _context.Carros.SingleOrDefault(c => c.Id == id);

            if (carros == null)
                return HttpNotFound();

            _context.Carros.Remove(carros);
            _context.SaveChanges();

            return new HttpStatusCodeResult(200);
        }
    }
}