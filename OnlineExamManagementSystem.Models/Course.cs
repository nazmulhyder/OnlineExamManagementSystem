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
        public int Batch { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public String Code { get; set; }

        [Required]
        public string CourseDuration { get; set; }
       
        public int Credit { get; set; }

        [AllowHtml]
        [Required]
        [StringLength(500)]
        public string Outline { get; set; }

        public int CourseTrainerId { get; set; }
        public CourseTrainer CourseTrainer { get; set; }
        public int CourseOrganizationId { get; set; }
        public CourseOrganization CourseOrganization { get; set; }
        public List<Exam> ListOfExams { get; set; }

        public int CourseTagsId { get; set; }

        public CourseTags CourseTags { get; set; }
        public List<Batch> ListOfBatches { get; set; }

        





    }
}
