using autobuses.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace autobuses.Controllers
{
    public class AutobusController : Controller
    {
        // GET: Autobus
        public ActionResult Index(){
            List<Autobus> autbuses = Autobus.GetAllAutobuses();
            return View(autbuses);
        }

        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult Guardar(String marca, String color, String placa, int matricula, int idRuta){
            Autobus.Guardar(marca, color, placa, matricula, idRuta);
            return RedirectToAction("Index");
        }
    }
}