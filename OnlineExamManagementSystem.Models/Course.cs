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
      
        public virtual Organization Organizations { get; set; }
        [Display(Name = "Organization")]
        public int OrganizationId { get; set; }

        public string Name { get; set; }
        public string Code { get; set; }

        [Required]
        public string CourseDuration { get; set; }
       
        public int Credit { get; set; }
        [AllowHtml]
        [Required]
        [StringLength(500)]
        public string Outline { get; set; }

        public ICollection<CourseTag> CourseTags { get; set; }

        

        



        

        





    }
}
