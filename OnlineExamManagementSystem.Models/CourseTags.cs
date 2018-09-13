using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamManagementSystem.Models
{
    public class CourseTags
    {
        public int Id { get; set; }
        //public List<Course> Courses { get; set; }
        //public  List<Tags> Tag { get; set; }

        public Course Course { get; set; }
        public int CourseId { get; set; }
        public Tags Tags { get; set; }
        public int TagId { get; set; }

    }
}
