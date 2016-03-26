using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using baseConhecimento.Models;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
//using System.Data.SqlServerCe;

namespace baseConhecimento.Controllers
{
    public class ItemsController : Controller
    {
        //private Context db = new Context();
        Context db = new Context();
        // GET: Items
        public ActionResult Index()
        {
            //Context db = new Context();
            //dados = db.conecta().;
            //MySqlConnection conn = db.conecta();
            //MySqlCommand cmd = new MySqlCommand("select *from ic",conn);
            //MySqlDataReader reader = cmd.ExecuteReader();
            return View(db.retornadados_item());
        }
        // GET: Items/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.retornavalor_itens(id);
            db.somaranking_itens(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_ic,nome,descricao,imagem")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.inseredados_itens(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }
        // GET: Items/Edit/5
        public ActionResult Edit(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.retornavalor_itens(id);
            if (item.nome == "")
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_ic,nome,descricao,ranking,imagem")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.alteradados_itens(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }
        // GET: Items/Delete/5
        public ActionResult Delete(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db.deletadados_itens(id);
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
