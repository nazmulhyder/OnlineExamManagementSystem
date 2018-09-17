using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineExamManagementSystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public Organization Organizations { get; set; }

        public int  OrganizationId { get; set; }

        public string Name { get; set; }
        public string Code { get; set; }

        [Required]
        public string CourseDuration { get; set; }
       
        public int Credit { get; set; }
        [AllowHtml]
        [Required]
        [StringLength(500)]
        public string Outline { get; set; }

        public List<CourseTrainer> CourseTrainers { get; set; }
        public List<CourseTags> CourseTags { get; set; }

        

        





    }
}
