using autobuses.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace autobuses.Controllers
{
    public class BoletoController : Controller
    {
        // GET: Boleto
        public ActionResult Index(){
            List<Boleto> boletos = Boleto.GetAllBoletos();
            return View(boletos);
        }

        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult Guardar(int numeroBoleto)
        {
            Boleto.Guardar(numeroBoleto);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int numeroBoleto)
        {
            Boleto.Guardar(numeroBoleto);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            Autobus.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}