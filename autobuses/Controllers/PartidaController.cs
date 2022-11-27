﻿using autobuses.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace autobuses.Controllers
{
    public class PartidaController : Controller
    {
        // GET: Partida
        public ActionResult Index(){
            List<Partida> partidas = Partida.GetAllPartidas();
            return View(partidas);
        }
    }
}