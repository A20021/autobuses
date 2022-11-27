﻿using autobuses.core.Entidades;
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
    }
}