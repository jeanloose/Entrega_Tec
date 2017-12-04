using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LojaDeCarros.Models;

namespace LojaDeCarros.Controllers
{
    public class UsuariosController : Controller
    {
        private ApplicationDbContext _context;

        public UsuariosController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ActionResult Index()
        {
            var usuarios = _context.Usuarios.ToList();
            return View(usuarios);
        }
        public ActionResult Details(int id)
        {
            var usuario = _context.Usuarios.SingleOrDefault(c => c.Id == id);
            if (usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);
        }

        public ActionResult New()
        {
            var usuario = new Usuario();

            return View("UsuarioForm", usuario);
        }

        [HttpPost] 

        public ActionResult Save(Usuario usuario)
        {

            if (!ModelState.IsValid)
            {
                return View("UsuarioForm", usuario);
            }

            if (usuario.Id == 0)
            {
               
                _context.Usuarios.Add(usuario);
            }
            else
            {
                var usuarioInDb = _context.Usuarios.Single(c => c.Id == usuario.Id);

                usuarioInDb.Nome = usuario.Nome;
                usuarioInDb.Email = usuario.Email;
                usuarioInDb.Senha = usuario.Senha;

            }

            
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var usuario = _context.Usuarios.SingleOrDefault(c => c.Id == id);

            if (usuario == null)
                return HttpNotFound();


            return View("UsuarioForm", usuario);
        }

        public ActionResult Delete(int id)
        {
            var usuario = _context.Usuarios.SingleOrDefault(c => c.Id == id);

            if (usuario == null)
                return HttpNotFound();

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            return new HttpStatusCodeResult(200);
        }
    }
}