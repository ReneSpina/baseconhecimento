using baseConhecimento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace baseConhecimento.Controllers
{
    public class ProblemasController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            return View(db.retornadados_problemas());
        }

        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            problema problema = db.retornavalor_problemas(id);
            db.somaranking_problemas(id);
            if (problema == null)
            {
                return HttpNotFound();
            }
            return View(problema);
        }

        // GET: Problemas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: problemas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_problema,nome,descricao,imagem, ranking, id_ic")] problema problema)
        {
            if (ModelState.IsValid)
            {
                db.inseredados_problemas(problema);
                return RedirectToAction("Index");
            }

            return View(problema);
        }
        // GET: Items/Edit/5
        public ActionResult Edit(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            problema problema = db.retornavalor_problemas(id);
            if (problema.nome == "")
            {
                return HttpNotFound();
            }
            return View(problema);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_problema,nome,descricao,ranking,imagem, id_ic")] problema problema)
        {
            if (ModelState.IsValid)
            {
                db.alteradados_problemas(problema);
                return RedirectToAction("Index");
            }
            return View(problema);
        }
        // GET: Items/Delete/5
        public ActionResult Delete(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db.deletadados_problemas(id);
            return RedirectToAction("Index");
        }

        /*// POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.deletadados(id);
            return RedirectToAction("Index");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}