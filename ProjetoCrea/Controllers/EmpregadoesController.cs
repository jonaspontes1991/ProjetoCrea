using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoCrea.Models;

namespace ProjetoCrea.Controllers
{
    public class EmpregadoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Empregadoes
        public ActionResult Index()
        {
            return View(db.Empregados.ToList());
        }

        // GET: Empregadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empregado empregado = db.Empregados.Find(id);
            if (empregado == null)
            {
                return HttpNotFound();
            }
            return View(empregado);
        }

        // GET: Empregadoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empregadoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "empregadoId,nome,sobrenome,dataEntrada")] Empregado empregado)
        {
            if (ModelState.IsValid)
            {
                db.Empregados.Add(empregado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empregado);
        }

        // GET: Empregadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empregado empregado = db.Empregados.Find(id);
            if (empregado == null)
            {
                return HttpNotFound();
            }
            return View(empregado);
        }

        // POST: Empregadoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "empregadoId,nome,sobrenome,dataEntrada")] Empregado empregado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empregado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empregado);
        }

        // GET: Empregadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empregado empregado = db.Empregados.Find(id);
            if (empregado == null)
            {
                return HttpNotFound();
            }
            return View(empregado);
        }

        // POST: Empregadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empregado empregado = db.Empregados.Find(id);
            db.Empregados.Remove(empregado);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
