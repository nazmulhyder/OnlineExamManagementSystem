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
    public class ExamsController : Controller
    {
        private ExamManagementDBContext db = new ExamManagementDBContext();

        // GET: Exams
        public ActionResult Index()
        {
            var exams = db.Exams.Include(e => e.Course);
            return View(exams.ToList());
        }

        // GET: Exams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: Exams/Create
        public ActionResult Create()
        {
            var defaultSelectListItem = new List<SelectListItem>()
            {
                new SelectListItem() {Value ="",Text ="Select"}
            };
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name");
           // ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name");
            

            //ViewBag.OrganizationId = defaultSelectListItem;
            ViewBag.CourseId = defaultSelectListItem;
            
           

            //var courses = db.Courses.ToList();
            //var courseSelectListItem = new SelectList(courses,"Id","Code",null);
            //ViewBag.Course = courseSelectListItem;

            //var defaultSelectListItems = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Value = " ",Text = "select"}
            //};
            //ViewBag.Organization = defaultSelectListItems;

           

            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind(Include = "Id,ExamType,Code,Topic,FullMarks,Duration,CourseId")]
        public ActionResult Create( Exam exam)
        {
            

            if (ModelState.IsValid)
            {
                db.Exams.Add(exam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           
            var defaultSelectListItem = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "",Text = "Select"}
            };
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name");
            //ViewBag.OrganizationId = defaultSelectListItem;
            ViewBag.CourseId = defaultSelectListItem;


            return View(exam);
        }

        //public JsonResult GetCourseBy(int organizationId)
        //{
        //    var courses = db.Courses.Where(x=>x.OrganizationId == organizationId);
        //    //var jsonResult =
        //    // courses.Select(c => new {c.Id, c.Name, c.Code, c.CourseDuration, c.OrganizationId, c.Credit});
        //    return Json(courses, JsonRequestBehavior.AllowGet);
        //}
        public JsonResult GetCourseBy(int organizationId)
        {
            var courses = db.Courses.Where(x => x.OrganizationId == organizationId);
            var jsonResult = courses.Select(c => new { c.Id, c.Name, c.Code, c.CourseDuration, c.Outline, c.Credit, c.OrganizationId });
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
        // GET: Exams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", exam.CourseId);
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ExamType,Code,Topic,FullMarks,Duration,CourseId")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", exam.CourseId);
            return View(exam);
        }

        // GET: Exams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam exam = db.Exams.Find(id);
            db.Exams.Remove(exam);
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
