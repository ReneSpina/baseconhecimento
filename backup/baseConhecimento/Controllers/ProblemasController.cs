using baseConhecimento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace baseConhecimento.Controllers
{
    public class ProblemasController : Controller
    {
        // GET: Problemas
        public ActionResult Index()
        {
            Context db = new Context();
            return View(db.retornadados_problema());
        }
    }
}