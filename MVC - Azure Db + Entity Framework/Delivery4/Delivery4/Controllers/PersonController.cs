using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Delivery4.Controllers
{
    public class PersonController : Controller
    {
        private readonly ModelContainer db = new ModelContainer();

        ~PersonController()
        {
            db.Dispose();
        }

        // GET: Person
        public ActionResult Index()
        {
            return View(db.People);
        }

        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
            return CommonAction(id);
        }

        private ActionResult CommonAction(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Person person = db.People
                .Include(p => p.UploadedFiles)
                .Include(p => p.Subjects)
                .SingleOrDefault(p => p.IDPerson == id);

            if(person == null)
            {
                return HttpNotFound();
            }

            return View(person);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(Person person, IEnumerable<HttpPostedFileBase> files, string subject)
        {
            if (ModelState.IsValid)
            {
                person.UploadedFiles = new List<UploadedFile>();
                person.Subjects = new List<Subject>();
                AddFiles(person, files);
                AddSubject(person, subject);
                
                db.People.Add(person);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        private void AddSubject(Person person, string subject)
        {
            if (string.IsNullOrEmpty(subject))
            {
                return;
            }

            person.Subjects.Add(new Subject()
            {
                Name = subject,
                PersonIDPerson = person.IDPerson
            });
        }

        private void AddFiles(Person person, IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                if(file != null && file.ContentLength > 0)
                {
                    var picture = new UploadedFile
                    {
                        Name = file.FileName,
                        ContentType = file.ContentType
                    };
                    using(var reader = new System.IO.BinaryReader(file.InputStream))
                    {
                        picture.Content = reader.ReadBytes(file.ContentLength);
                    }
                    person.UploadedFiles.Add(picture);
                }
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {
            return CommonAction(id);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IEnumerable<HttpPostedFileBase> files)
        {
            Person person = db.People.Find(id);
            if (TryUpdateModel(person, "", new string[] 
            {
                nameof(Person.Address),
                nameof(Person.Contact),
                nameof(Person.FirstName),
                nameof(Person.LastName),
                nameof(Person.UploadedFiles)
            }))
            {
                AddFiles(person, files);
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int? id)
        {
            return CommonAction(id);
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            db.UploadedFiles.RemoveRange(db.UploadedFiles.Where(f => f.PersonIDPerson == id));
            db.Subjects.RemoveRange(db.Subjects.Where(s => s.PersonIDPerson == id));
            db.People.Remove(db.People.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
