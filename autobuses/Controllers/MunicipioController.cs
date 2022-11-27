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
    }
}