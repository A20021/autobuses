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

        public ActionResult Guardar(int idMunicipio)
        {
            Destino.Guardar(idMunicipio);
            return RedirectToAction("Index");
        }
    }
}