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
            List<Autobus> autobuses = Autobus.GetAllAutobuses();
            return View(autobuses);
        }

        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult Guardar(String marca, String color, String placa, int matricula, int idRuta){
            Autobus.Guardar(marca, color, placa, matricula, idRuta);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(String marca, String color, String placa, int matricula, int idRuta, int id)
        {
            Autobus.Editar(marca, color, placa, matricula, idRuta, id);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            Autobus.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}