using autobuses.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace autobuses.Controllers
{
    public class PasajeroController : Controller
    {
        // GET: Pasajero
        public ActionResult Index(){
            List<Pasajero> pasajeros = Pasajero.GetAllPasajeros();
            return View(pasajeros);
        }

        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult Guardar(int idBoleto, int numeroAsiento)
        {
            Pasajero.Guardar(idBoleto, numeroAsiento);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int idBoleto, int numeroAsiento, int id)
        {
            Pasajero.Editar( idBoleto,  numeroAsiento,  id);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            Autobus.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}