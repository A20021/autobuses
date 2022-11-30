using autobuses.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace autobuses.Controllers
{
    public class RutaController : Controller
    {
        // GET: Ruta
        public ActionResult Index(){
            List<Ruta> rutas = Ruta.GetAllRutas();
            return View(rutas);
        }

        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult Guardar(String descripcion, int idEstado, int idPasajero, int idDestino, int idPartida)
        {
            Ruta.Guardar(descripcion, idEstado, idPasajero, idDestino, idPartida);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(String descripcion, int idEstado, int idPasajero, int idDestino, int idPartida, int id)
        {
            Ruta.Editar(descripcion, idEstado, idPasajero, idDestino, idPartida, id);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            Autobus.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}