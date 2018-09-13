using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExamManagement.DatabaseContext;
using OnlineExamManagementSystem.Models;

namespace OnlineExamManagementSystem.Repository
{
    public class CourseRepository
    {

        ExamManagementDBContext db = new ExamManagementDBContext();

        public bool Add(Course entity)
        {
            db.Courses.Add(entity);
            return db.SaveChanges() > 0;
        }

        public bool Update(Course entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public List<Course> GetAll()
        {
            return db.Courses.ToList();
        }

        public Course GetCourseById(int Id)
        {
            return db.Courses.FirstOrDefault(model => model.Id == Id);
        }

        public bool Delete(Course course)
        {
            db.Courses.Remove(course);
            return db.SaveChanges() > 0;

        }


    }
}
