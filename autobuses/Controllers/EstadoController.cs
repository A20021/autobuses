using autobuses.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace autobuses.Controllers
{
    public class EstadoController : Controller
    {
        // GET: Estado
        public ActionResult Index(){
            List<Estado> estados = Estado.GetAllEstados();
            return View(estados);
        }

        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult Guardar(String nombre)
        {
            Estado.Guardar(nombre);
            return RedirectToAction("Index");
        }

<<<<<<< HEAD
        public ActionResult Registro()
        {
            return View();
=======
        public ActionResult Editar(String nombre, int id)
        {
            Estado.Editar(nombre, id);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            Autobus.Eliminar(id);
            return RedirectToAction("Index");
>>>>>>> f0521eebefe06badea62e36eeee3d1df5494c6bb
        }
    }
}