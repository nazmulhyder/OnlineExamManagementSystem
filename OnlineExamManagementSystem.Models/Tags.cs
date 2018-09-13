using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamManagementSystem.Models
{
    public class Tags
    {
      public int Id { get; set; }
      [Required]
      public string Name { get; set; }
      public List<CourseTags> CourseTags { get; set; }
        //public int CourseTagId { get; set; }
        //public CourseTags CourseTags { get; set; }

    }
}
