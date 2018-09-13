using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamManagementSystem.Models
{
    public class CourseOrganization
    {
        public int Id { get; set; }
        //public List<Course> Course { get; set; }
        //public List<Organization> Organization { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public Organization Organization { get; set; }
        public int OrganizationId { get; set; }

    }
}