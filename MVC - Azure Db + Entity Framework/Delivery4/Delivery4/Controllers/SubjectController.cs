using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Delivery4.Controllers
{
    public class SubjectController : Controller
    {

        private readonly ModelContainer db = new ModelContainer();

        ~SubjectController()
        {
            db.Dispose();
        }

        // GET: Subject
        public ActionResult Index()
        {
            return View(db.Subjects);
        }

        // GET: Subject/Details/5
        public ActionResult Details(int? id)
        {
            return CommonAction(id);
        }

        // GET: Subject/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subject/Create
        [HttpPost]
        public ActionResult Create(Subject subject)
        {
            Person person = db.People.Find(subject.PersonIDPerson);

            if (ModelState.IsValid && person != null)
            {
                db.Subjects.Add(subject);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        // GET: Subject/Edit/5
        public ActionResult Edit(int? id)
        {
            return CommonAction(id);
        }

        // POST: Subject/Edit/5
        [HttpPost]
        public ActionResult Edit(int id)
        {
            Subject subject = db.Subjects.Find(id);

            try
            {
                if (TryUpdateModel(subject, "", new string[]
                {
                nameof(Subject.PersonIDPerson),
                nameof(Subject.Name),
                }))
                {
                    db.Entry(subject).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                //person does not exist!
                return View(subject);
                throw;
            }
            return View(subject);
        }

        private ActionResult CommonAction(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects
                .SingleOrDefault(s => s.IDSubject == id);

            if (subject == null)
            {
                return HttpNotFound();
            }

            return View(subject);
        }


        // GET: Subject/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Subject/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            db.Subjects.Remove(db.Subjects.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSubject(int id)
        {
            db.Subjects.Remove(db.Subjects.Find(id));
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.AbsolutePath);
        }
    }
}
