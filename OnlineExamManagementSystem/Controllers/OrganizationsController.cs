using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineExamManagement.DatabaseContext;
using OnlineExamManagementSystem.Models;

namespace OnlineExamManagementSystem.Controllers
{
    public class OrganizationsController : Controller
    {
        private ExamManagementDBContext db = new ExamManagementDBContext();

        // GET: Organizations
        public ActionResult Index(string searchString,string searchString2,string searchString3,string searchString4)
        {
            var taken = from model in db.Organizations
                select model;

            if (!String.IsNullOrEmpty(searchString))
            {
                taken = taken.Where(s =>s.Name.Contains(searchString));
            }
            else if (!String.IsNullOrEmpty(searchString2))
            {
                taken = taken.Where(m => m.Address.Contains(searchString2));
            }
            else if (!String.IsNullOrEmpty(searchString3))
            {
                taken = taken.Where(m => m.Code.Contains(searchString3));
            }
            else if (!String.IsNullOrEmpty(searchString4))
            {
                taken = taken.Where(m => m.ContactNo.Contains(searchString4));
            }
            // return View(db.Organizations.ToList());
            return View(taken);
        }

        
        // GET: Organizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // GET: Organizations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Organization organization)
        {
            if (ModelState.IsValid)
            {
                AddImg(organization);
                db.Organizations.Add(organization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organization);
        }

        public void AddImg(Organization organization)
        {
            string fileName = Path.GetFileNameWithoutExtension(organization.Logo.FileName);
            string extension = Path.GetExtension(organization.Logo.FileName);
            fileName = fileName + DateTime.Now.ToString("yy-MM-dd") + extension;
            organization.ImgPath = "/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("/Images/"), fileName);
            organization.Logo.SaveAs(fileName);
        }

        // GET: Organizations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: Organizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Code,Address,ContactNo,ImgPath,About")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organization);
        }

        // GET: Organizations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: Organizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organization organization = db.Organizations.Find(id);
            db.Organizations.Remove(organization);
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

        //public ActionResult Search(Organization organization)
        //{
        //    return View("Search");
        //}

    }
}
