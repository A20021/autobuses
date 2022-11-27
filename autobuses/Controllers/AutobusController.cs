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
    }
}