using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamManagementSystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Organization { get; set; }

        [Required]
        public int Batch { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public String Code { get; set; }

        [Required]
        public string CourseDuration { get; set; }
       
        public int Credit { get; set; }
        [Required]
        [StringLength(500)]
        public string Outline { get; set; }
        public string Tags { get; set; }
        public List<Trainer> Trainers { get; set; }
       
    }
}
