using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaDeCarros.Models;

namespace LojaDeCarros.Controllers
{
    public class ClientesController : Controller
    {
        private ApplicationDbContext _context;

        public ClientesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Clientes
        public ActionResult Index()
        {
            var clientes = _context.Clientes.ToList();

            if (User.IsInRole(RoleName.CanManageCustomers))
                return View(clientes);

            return View("ReadOnlyIndex", clientes);
        }

        public ActionResult New()
        {
            var cliente = new Cliente();

            return View("ClienteForm", cliente);
        }

        [HttpPost] 

        public ActionResult Save(Cliente cliente)
        {

            if (!ModelState.IsValid)
            {
                return View("ClienteForm", cliente);
            }

            if (cliente.Id == 0)
            {
               
                _context.Clientes.Add(cliente);
            }
            else
            {
                var clienteInDb = _context.Clientes.Single(c => c.Id == cliente.Id);

                clienteInDb.Nome = cliente.Nome;
                clienteInDb.Cpf = cliente.Cpf;

            }

           
            _context.SaveChanges();
           
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var cliente = _context.Clientes.SingleOrDefault(c => c.Id == id);

            if (cliente == null)
                return HttpNotFound();


            return View("ClienteForm", cliente);
        }

        public ActionResult Delete(int id)
        {
            var cliente = _context.Clientes.SingleOrDefault(c => c.Id == id);

            if (cliente == null)
                return HttpNotFound();

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            return new HttpStatusCodeResult(200);
        }
    }
}