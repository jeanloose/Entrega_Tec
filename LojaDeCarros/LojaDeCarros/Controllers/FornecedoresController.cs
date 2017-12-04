using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaDeCarros.Models;

namespace LojaDeCarros.Controllers
{
    public class FornecedoresController : Controller
    {
        private ApplicationDbContext _context;

        public FornecedoresController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ActionResult Index()
        {
            var fornecedores = _context.Fornecedores.ToList();

            return View(fornecedores);
        }
        public ActionResult Details(int id)
        {
            var fornecedor = _context.Fornecedores.SingleOrDefault(c => c.Id == id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }

            return View(fornecedor);
        }

        public ActionResult New()
        {
            var fornecedor = new Fornecedor();

            return View("FornecedorForm", fornecedor);
        }

        [HttpPost] 

        public ActionResult Save(Fornecedor fornecedor)
        {

            if (!ModelState.IsValid)
            {
                return View("FornecedorForm", fornecedor);
            }

            if (fornecedor.Id == 0)
            {
                
                _context.Fornecedores.Add(fornecedor);
            }
            else
            {
                var fornecedorInDb = _context.Fornecedores.Single(c => c.Id == fornecedor.Id);

                fornecedorInDb.Nome = fornecedor.Nome;
                fornecedorInDb.Cnpj = fornecedor.Cnpj;
                fornecedorInDb.Linha = fornecedor.Linha;

            }

           
            _context.SaveChanges();
           
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var fornecedor = _context.Fornecedores.SingleOrDefault(c => c.Id == id);

            if (fornecedor == null)
                return HttpNotFound();


            return View("FornecedorForm", fornecedor);
        }

        public ActionResult Delete(int id)
        {
            var fornecedor = _context.Fornecedores.SingleOrDefault(c => c.Id == id);

            if (fornecedor == null)
                return HttpNotFound();

            _context.Fornecedores.Remove(fornecedor);
            _context.SaveChanges();

            return new HttpStatusCodeResult(200);
        }
    }
}