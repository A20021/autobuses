﻿using autobuses.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace autobuses.Controllers
{
    public class EstadoController : Controller
    {
        // GET: Estado
        public ActionResult Index(){
            List<Estado> estados = Estado.GetAllEstados();
            return View(estados);
        }

        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult Guardar(String nombre)
        {
            Estado.Guardar(nombre);
            return RedirectToAction("Index");
        }
    }
}