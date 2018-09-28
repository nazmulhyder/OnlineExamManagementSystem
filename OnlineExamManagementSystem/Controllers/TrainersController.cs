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
    public class TrainersController : Controller
    {
        private ExamManagementDBContext db = new ExamManagementDBContext();

        // GET: Trainers
        public ActionResult Index()
        {
            var trainers = db.Trainers.Include(t => t.Organizations);
            return View(trainers.ToList());
        }

        // GET: Trainers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // GET: Trainers/Create
        public ActionResult Create()
        {

            var defaultSelectListItem = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "",Text = "Select"}
            };
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name");
            ViewBag.CourseId = defaultSelectListItem;
            ViewBag.BatchId = defaultSelectListItem;
            return View();
        }

        // POST: Trainers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                AddImg(trainer);
                db.Trainers.Add(trainer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", trainer.OrganizationId);
            return View(trainer);
        }

        public void AddImg(Trainer trainer)
        {
            string fileName = Path.GetFileNameWithoutExtension(trainer.Image.FileName);
            string extension = Path.GetExtension(trainer.Image.FileName);
            fileName = fileName + DateTime.Now.ToString("yy-MM-dd") + extension;
            trainer.ImgPath = "/Images/Trainer/" + fileName;
            fileName = Path.Combine(Server.MapPath("/Images/Trainer/"), fileName);
            trainer.Image.SaveAs(fileName);
        }

        // GET: Trainers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", trainer.OrganizationId);
            return View(trainer);
        }

        // POST: Trainers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Batch,isLead,Name,ContactNumber,Email,Address,City,PostalCode,Country,Image,OrganizationId")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", trainer.OrganizationId);
            return View(trainer);
        }

        public JsonResult GetCourseBy(int organizationId)
        {
            var courses = db.Courses.Where(c => c.OrganizationId == organizationId);
            var jsonResult = courses.Select(c =>
                new {c.Id, c.Name, c.Code, c.CourseDuration, c.Outline, c.Credit, c.OrganizationId});
            return Json(jsonResult, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetBatchBy(int courseId)
        {
            var courses = db.Batches.Where(c => c.CourseId == courseId );
            var jsonResult = courses.Select(c =>
                new { c.Id, c.BatchNumber, c.Description, c.StartDate, c.EndDate, c.CourseId,c.ExamSchedules,c.Participants});
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        // GET: Trainers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trainer trainer = db.Trainers.Find(id);
            db.Trainers.Remove(trainer);
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
