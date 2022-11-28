using autobuses.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace autobuses.Controllers
{
    public class OperadorController : Controller
    {
        // GET: Operador
        public ActionResult Index()
        {
            List<Operador> operadores = Operador.GetAllOperadores();
            return View(operadores);
        }

        public ActionResult Guardar(String nombre, int edad)
        {
            Operador.Guardar(nombre, edad);
            return RedirectToAction("Index");
        }
    }
}