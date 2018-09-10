using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineExamManagement.DatabaseContext;
using OnlineExamManagementSystem.Models;

namespace OnlineExamManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        private ExamManagementDBContext db = new ExamManagementDBContext();

        // GET: Course
        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.CourseOrganization).Include(c => c.CourseTags).Include(c => c.CourseTrainer);
            return View(courses.ToList());
        }

        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            ViewBag.CourseOrganizationId = new SelectList(db.CourseOrganizations, "Id", "Id");
            ViewBag.CourseTagsId = new SelectList(db.CourseTagses, "Id", "Id");
            ViewBag.CourseTrainerId = new SelectList(db.CourseTrainers, "Id", "Id");
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Batch,Name,Code,CourseDuration,Credit,Outline,CourseTrainerId,CourseOrganizationId,CourseTagsId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseOrganizationId = new SelectList(db.CourseOrganizations, "Id", "Id", course.CourseOrganizationId);
            ViewBag.CourseTagsId = new SelectList(db.CourseTagses, "Id", "Id", course.CourseTagsId);
            ViewBag.CourseTrainerId = new SelectList(db.CourseTrainers, "Id", "Id", course.CourseTrainerId);
            return View(course);
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseOrganizationId = new SelectList(db.CourseOrganizations, "Id", "Id", course.CourseOrganizationId);
            ViewBag.CourseTagsId = new SelectList(db.CourseTagses, "Id", "Id", course.CourseTagsId);
            ViewBag.CourseTrainerId = new SelectList(db.CourseTrainers, "Id", "Id", course.CourseTrainerId);
            return View(course);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Batch,Name,Code,CourseDuration,Credit,Outline,CourseTrainerId,CourseOrganizationId,CourseTagsId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseOrganizationId = new SelectList(db.CourseOrganizations, "Id", "Id", course.CourseOrganizationId);
            ViewBag.CourseTagsId = new SelectList(db.CourseTagses, "Id", "Id", course.CourseTagsId);
            ViewBag.CourseTrainerId = new SelectList(db.CourseTrainers, "Id", "Id", course.CourseTrainerId);
            return View(course);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
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
