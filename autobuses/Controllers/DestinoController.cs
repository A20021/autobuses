using autobuses.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace autobuses.Controllers
{
    public class DestinoController : Controller
    {
        // GET: Destino
        public ActionResult Index(){
            List<Destino> destinos = Destino.GetAllDestinos();
            return View(destinos);
        }

        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult Guardar(int idMunicipio)
        {
            Destino.Guardar(idMunicipio);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int idMunicipio, int id)
        {
            Destino.Editar(idMunicipio, id);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            Autobus.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}