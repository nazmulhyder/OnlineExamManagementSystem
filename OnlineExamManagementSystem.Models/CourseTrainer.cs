using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamManagementSystem.Models
{
    public class CourseTrainer
    {
        public int Id { get; set; }
        public List<Course> ListOfCourses { get; set; }
        public List<Trainer> ListOfTrainers { get; set; }
    }
}
