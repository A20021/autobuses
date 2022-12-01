using autobuses.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace autobuses.Controllers
{
    public class MunicipioController : Controller
    {
        // GET: Municipio
        public ActionResult Index(){
            List<Municipio> municipios = Municipio.GetAllMunicipios();
            return View(municipios);
        }

        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult Guardar(String nombre, int idEstado)
        {
            Municipio.Guardar(nombre, idEstado);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(String nombre, int idEstado, int id)
        {
            Municipio.Editar(nombre, idEstado, id);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            Autobus.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}