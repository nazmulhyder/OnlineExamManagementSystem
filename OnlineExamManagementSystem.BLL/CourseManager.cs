using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExamManagementSystem.Models;
using OnlineExamManagementSystem.Repository;

namespace OnlineExamManagementSystem.BLL
{
    public class CourseManager
    {
        CourseRepository _courseRepository = new CourseRepository();
        public bool Add(Course entity)
        {
           return _courseRepository.Add(entity);
        }

    }
}
